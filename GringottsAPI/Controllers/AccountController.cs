using Gringotts.Data;
using Gringotts.Data.Repositories;
using GringottsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using GringottsAPI.Business;

namespace GringottsAPI.Controllers
{
    /// <summary>
    /// Used for transactions related to customer accounts 
    /// </summary>
    [ApiController]
    [Route("api/Account/[action]")]
    public class AccountController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor for AccountController
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="accountRepository"></param>
        /// <param name="customerRepository"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="gringottsDataContext"></param>
        public AccountController(IHttpContextAccessor httpContextAccessor, IAccountRepository accountRepository, ICustomerRepository customerRepository, ILogger<CustomerController> logger, IConfiguration configuration, IGringottsDataContext gringottsDataContext) : base(logger, configuration, gringottsDataContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Get account info with the account number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("{accountNumber}")]
        [ActionName("GetAccount")]
        public async Task<IActionResult> GetAccount(long accountNumber)
        {
            GetAccountOutputModel response = await new AccountManager(_httpContextAccessor, _accountRepository, _customerRepository).GetAccount(accountNumber);

            return Ok(response);
        }

        /// <summary>
        /// Get all accounts of the customer with the customer number
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [HttpGet("{customerNumber}")]
        [ActionName("GetAllAccountsOfCustomer")]
        public async Task<IActionResult> GetAllAccountsOfCustomer(int customerNumber)
        {
            GetAllAccountsOfCustomerOutputModel response = await new AccountManager(_httpContextAccessor, _accountRepository, _customerRepository).GetAllAccountsOfCustomer(customerNumber);

            return Ok(response);
        }

        /// <summary>
        /// Add new account for customer
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddAccount")]
        public async Task<IActionResult> AddAccount(AddAccountInputModel inputModel)
        {
            AddAccountOutputModel response = await new AccountManager(_httpContextAccessor, _accountRepository, _customerRepository).AddAccount(inputModel);

            return Ok(response);
        }
    }
}
