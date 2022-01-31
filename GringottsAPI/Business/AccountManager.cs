using Gringotts.Data.Entities;
using Gringotts.Data.Repositories;
using GringottsAPI.Mappers;
using GringottsAPI.Models;
using GringottsAPI.Validations;
using System.Security.Claims;

namespace GringottsAPI.Business
{
    /// <summary>
    /// Business manager for customer account processes
    /// </summary>
    public class AccountManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Account manager constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="accountRepository"></param>
        /// <param name="customerRepository"></param>
        public AccountManager(IHttpContextAccessor httpContextAccessor, IAccountRepository accountRepository, ICustomerRepository customerRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Get account info with account number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<GetAccountOutputModel> GetAccount(long accountNumber)
        {
            var account = await _accountRepository.Get(accountNumber);

            if (account == null)
                return new GetAccountOutputModel() { IsSucceeded = false, Messages = new List<string> { "No account found with this account number." } };

            return AccountMapper.MapAccountOutputModel(account);
        }

        /// <summary>
        /// Get all accounts of customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        public async Task<GetAllAccountsOfCustomerOutputModel> GetAllAccountsOfCustomer(int customerNumber)
        {
            List<Account> accountsList = await _accountRepository.GetAll(customerNumber);

            if (accountsList == null || accountsList.Count == 0)
                return new GetAllAccountsOfCustomerOutputModel() { IsSucceeded = false, Messages = new List<string> { "No account found for this customer." } };

            return AccountMapper.MapAllAccountsOfCustomerOutputModel(accountsList);
        }

        /// <summary>
        /// Add new account for customer
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public async Task<AddAccountOutputModel> AddAccount(AddAccountInputModel inputModel)
        {
            AddAccountOutputModel output = AccountValidator.ValidateAddAccountInputModel(inputModel);

            if (!output.IsSucceeded)
                return output;

            var account = await _accountRepository.Get(inputModel.AccountNumber);

            if (account != null)
            {
                output.Messages = new List<string>() { "The account with this account number already exists." };
                output.IsSucceeded = false;
                return output;
            }

            var customer = await _customerRepository.Get(inputModel.CustomerNumber);

            if (customer == null)
            {
                output.Messages = new List<string>() { "The customer with entered customer number is not found." };
                output.IsSucceeded = false;
                return output;
            }

            string? userName = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            Account newAccount = AccountMapper.MapAccountInputModel(inputModel, userName);
            output.AccountId = await _accountRepository.Add(newAccount);
            output.CreateDate = newAccount.CreatedOn;

            return output;
        }
    }
}
