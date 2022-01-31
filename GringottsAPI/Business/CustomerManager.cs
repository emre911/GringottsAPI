using Gringotts.Data;
using Gringotts.Data.Entities;
using Gringotts.Data.Repositories;
using GringottsAPI.Mappers;
using GringottsAPI.Model;
using GringottsAPI.Validations;
using System.Security.Claims;

namespace GringottsAPI.Business
{
    /// <summary>
    /// Business manager for customer processes
    /// </summary>
    public class CustomerManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICustomerRepository _customerRepository;
        /// <summary>
        /// Customer manager constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="customerRepository"></param>
        public CustomerManager(IHttpContextAccessor httpContextAccessor, ICustomerRepository customerRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Get customer with customer number
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        public async Task<GetCustomerOutputModel> GetCustomer(int customerNumber)
        {
            var customer = await _customerRepository.Get(customerNumber);

            if (customer == null)
                return new GetCustomerOutputModel() { IsSucceeded = false, Messages = new List<string> { "No customer found with this customer number." } };

            return CustomerMapper.MapCustomerOutputModel(customer);
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public async Task<AddCustomerOutputModel> AddCustomer(AddCustomerInputModel inputModel)
        {
            AddCustomerOutputModel output = CustomerValidator.ValidateAddCustomerInputModel(inputModel);

            if (!output.IsSucceeded)
                return output;

            var customer = await _customerRepository.Get(inputModel.CustomerNumber);

            if (customer != null)
            {
                output.Messages = new List<string>() { "The customer with this customer number already exists." };
                output.IsSucceeded = false;
                return output;
            }

            string? userName = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            Customer newCustomer = CustomerMapper.MapCustomerInputModel(inputModel, userName);
            output.CustomerId = await _customerRepository.Add(newCustomer);
            output.CreateDate = newCustomer.CreatedOn;

            return output;
        }
    }
}
