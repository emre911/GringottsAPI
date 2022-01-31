using Gringotts.Data;
using Gringotts.Data.Repositories;
using GringottsAPI.Business;
using GringottsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GringottsAPI.Controllers
{
    /// <summary>
    /// Used for processes related to customer account transactions 
    /// </summary>
    [ApiController]
    [Route("api/Transaction/[action]")]
    public class TransactionController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor for TransactionController
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="transactionRepository"></param>
        /// <param name="accountRepository"></param>
        /// <param name="customerRepository"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="gringottsDataContext"></param>
        public TransactionController(IHttpContextAccessor httpContextAccessor, ITransactionRepository transactionRepository, IAccountRepository accountRepository, ICustomerRepository customerRepository, ILogger<CustomerController> logger, IConfiguration configuration, IGringottsDataContext gringottsDataContext) : base(logger, configuration, gringottsDataContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Add new transaction for a customer account
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddTransaction")]
        public async Task<IActionResult> AddTransaction(AddTransactionInputModel inputModel)
        {
            AddTransactionOutputModel response = await new TransactionManager(_httpContextAccessor, _transactionRepository, _accountRepository, _customerRepository).AddTransaction(inputModel);

            return Ok(response);
        }

        /// <summary>
        /// Get all transactions of an account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("{accountNumber}")]
        [ActionName("ListTransactionsOfAccount")]
        public async Task<IActionResult> ListTransactionsOfAccount(long accountNumber)
        {
            ListTransactionsOfAccountOutputModel response = await new TransactionManager(_httpContextAccessor, _transactionRepository, _accountRepository, _customerRepository).ListTransactionsOfAccount(accountNumber);

            return Ok(response);
        }

        /// <summary>
        /// Get all transactions of a customer between a time period
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ListTransactionsOfCustomer")]
        public async Task<IActionResult> ListTransactionsOfCustomer(ListTransactionsOfCustomerInputModel inputModel)
        {
            ListTransactionsOfCustomerOutputModel response = await new TransactionManager(_httpContextAccessor, _transactionRepository, _accountRepository, _customerRepository).ListTransactionsOfCustomer(inputModel);

            return Ok(response);
        }
    }
}
