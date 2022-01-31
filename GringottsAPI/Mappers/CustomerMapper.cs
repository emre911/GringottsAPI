using Gringotts.Data.Entities;
using GringottsAPI.Model;

namespace GringottsAPI.Mappers
{
    /// <summary>
    /// Customer object mapper class
    /// </summary>
    public static class CustomerMapper
    {
        /// <summary>
        /// Map customer output model
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static GetCustomerOutputModel MapCustomerOutputModel(Customer customer)
        {
            GetCustomerOutputModel outputModel = new()
            {
                IsSucceeded = true,
                CustomerNumber = customer.CustomerNumber,
                Country = customer.Country,
                City = customer.City,
                Zip = customer.Zip,
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Gender = customer.Gender,
                YearBirth = customer.YearBirth,
                CreatedOn = customer.CreatedOn,
                CreatedBy = customer.CreatedBy,
                LastUpdatedOn = customer.LastUpdatedOn,
                LastUpdatedBy = customer.LastUpdatedBy
            };

            return outputModel;
        }

        /// <summary>
        /// Map customer input model
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Customer MapCustomerInputModel(AddCustomerInputModel inputModel, string? userName)
        {
            Customer newCustomer = new()
            {
                CustomerNumber = inputModel.CustomerNumber,
                FirstName = inputModel.FirstName,
                MiddleName = inputModel.MiddleName,
                LastName = inputModel.LastName,
                YearBirth = inputModel.YearBirth,
                Gender = inputModel.Gender.ToString(),
                Country = inputModel.Country,
                City = inputModel.City,
                Zip = inputModel.Zip,
                Phone = inputModel.Phone,
                Email = inputModel.Email,
                CreatedBy = userName ?? "System",
                CreatedOn = DateTime.Now
            };

            return newCustomer;
        }
    }
}
