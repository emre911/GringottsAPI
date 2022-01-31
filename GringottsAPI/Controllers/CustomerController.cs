using Gringotts.Data;
using Gringotts.Data.Repositories;
using GringottsAPI.Business;
using GringottsAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GringottsAPI.Controllers
{
    /// <summary>
    /// Used for transactions related to customers 
    /// </summary>
    [ApiController]
    [Route("api/Customer/[action]")]
    public class CustomerController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor for CustomerController
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="customerRepository"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="gringottsDataContext"></param>
        public CustomerController(IHttpContextAccessor httpContextAccessor, ICustomerRepository customerRepository, ILogger<CustomerController> logger, IConfiguration configuration, IGringottsDataContext gringottsDataContext) : base(logger, configuration, gringottsDataContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Get customer info with the customer number
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [HttpGet("{customerNumber}")]
        [ActionName("GetCustomer")]
        public async Task<IActionResult> GetCustomer(int customerNumber)
        {
            GetCustomerOutputModel response = await new CustomerManager(_httpContextAccessor, _customerRepository).GetCustomer(customerNumber);

            return Ok(response);
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerInputModel inputModel)
        {
            AddCustomerOutputModel response = await new CustomerManager(_httpContextAccessor, _customerRepository).AddCustomer(inputModel);

            return Ok(response);
        }
    }
}
