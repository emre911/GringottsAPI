using Gringotts.Data.Entities;
using Gringotts.Data.Repositories;
using GringottsAPI.Mappers;
using GringottsAPI.Models;
using GringottsAPI.Validations;
using System.Security.Claims;

namespace GringottsAPI.Business
{
    /// <summary>
    /// Business manager for transaction processes
    /// </summary>
    public class TransactionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Transaction manager constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="transactionRepository"></param>
        /// <param name="accountRepository"></param>
        /// <param name="customerRepository"></param>
        public TransactionManager(IHttpContextAccessor httpContextAccessor, ITransactionRepository transactionRepository, IAccountRepository accountRepository, ICustomerRepository customerRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Add new account for customer
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public async Task<AddTransactionOutputModel> AddTransaction(AddTransactionInputModel inputModel)
        {
            AddTransactionOutputModel output = TransactionValidator.ValidateAddTransactionInputModel(inputModel);

            if (!output.IsSucceeded)
                return output;

            var account = await _accountRepository.Get(inputModel.AccountNumber);

            output = TransactionValidator.CheckAccountForTransaction(inputModel, account);

            if (!output.IsSucceeded)
                return output;

            string? userName = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            Transaction newTransaction = TransactionMapper.MapTransactionInputModel(inputModel, account, userName);
            output.TransactionId = await _transactionRepository.Add(newTransaction);
            output.CreateDate = newTransaction.CreatedOn;

            AccountHistory accountHistory = AccountMapper.MapAccountHistory(account);
            await _accountRepository.AddHistory(accountHistory);

            if (inputModel.TransactionType == 'D')
            {
                account.Balance += inputModel.Amount;
            }
            else if (inputModel.TransactionType == 'W')
            {
                account.Balance -= inputModel.Amount;
            }
            account.LastUpdatedBy = userName;

            await _accountRepository.Update(account);

            return output;
        }

        /// <summary>
        /// List transactions of the account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<ListTransactionsOfAccountOutputModel> ListTransactionsOfAccount(long accountNumber)
        {
            ListTransactionsOfAccountOutputModel output = new ListTransactionsOfAccountOutputModel();
            
            if (accountNumber.ToString().Length != 16)
            {
                output.Messages = new List<string>() {"The account number must be 16 digits." };
                output.IsSucceeded = false;
                return output;
            }

            var account = await _accountRepository.Get(accountNumber);

            if (account == null)
            {
                output.Messages = new List<string>() { "The account for the accountNumber can not be found." };
                output.IsSucceeded = false;
                return output;
            }

            List<Transaction> transactions = await _transactionRepository.ListWithAccountNumber(accountNumber);
            output.Transactions = transactions;
            output.IsSucceeded = true;

            return output;
        }

        /// <summary>
        /// List transactions of the customer between a time period
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public async Task<ListTransactionsOfCustomerOutputModel> ListTransactionsOfCustomer(ListTransactionsOfCustomerInputModel inputModel)
        {
            ListTransactionsOfCustomerOutputModel output = TransactionValidator.ValidateListTransactionsOfCustomerInputModel(inputModel);

            if (!output.IsSucceeded)
                return output;

            var customer = await _customerRepository.Get(inputModel.CustomerNumber);

            if (customer == null)
            {
                output.Messages = new List<string>() { "The customer with the customerNumber entered can not be found." };
                output.IsSucceeded = false;
                return output;
            }

            List<Transaction> transactions = await _transactionRepository.ListWithCustomerTimeline(customer.CustomerNumber, inputModel.StartDate, inputModel.EndDate);
            output.Transactions = transactions;
            output.IsSucceeded = true;

            return output;
        }
    }
}
