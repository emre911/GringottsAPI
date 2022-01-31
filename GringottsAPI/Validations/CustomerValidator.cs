using GringottsAPI.Helpers;
using GringottsAPI.Model;

namespace GringottsAPI.Validations
{
    /// <summary>
    /// Validation methods for the customer processes
    /// </summary>
    public static class CustomerValidator
    {
        private static readonly List<char> Genders = new List<char>() { 'F', 'M'};

        /// <summary>
        /// Validate new customer input model
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public static AddCustomerOutputModel ValidateAddCustomerInputModel(AddCustomerInputModel inputModel)
        {
            AddCustomerOutputModel output = new AddCustomerOutputModel() { Messages = new List<string>() };

            if (inputModel == null)
            {
                output.Messages.Add("AddCustomer model can not be null.");
                return output;
            }

            if (inputModel.CustomerNumber.ToString().Length != 10)
                output.Messages.Add("The customer number must be 10 digits.");

            if (string.IsNullOrWhiteSpace(inputModel.FirstName) || string.IsNullOrWhiteSpace(inputModel.LastName))
                output.Messages.Add("FirstName and LastName of Customer can not be null.");

            if (char.IsWhiteSpace(inputModel.Gender) || !Genders.Contains(inputModel.Gender))
                output.Messages.Add("Gender should be F or M.");

            if (inputModel.YearBirth < 1850 || inputModel.YearBirth > DateTime.Now.Year)
                output.Messages.Add("The customer's year of birth must be between 1850 and " + DateTime.Now.Year + ".");

            if (!StringHelper.IsValidPhone(inputModel.Phone))
                output.Messages.Add("The customer phone number must be entered correctly.");

            if(!StringHelper.IsValidEmail(inputModel.Email))
                output.Messages.Add("The customer email is not valid.");

            if(!string.IsNullOrWhiteSpace(inputModel.MiddleName) && inputModel.MiddleName.Length > 100)
                output.Messages.Add("The customer middle name cannot exceed 100 characters");

            if (!string.IsNullOrWhiteSpace(inputModel.Country) && inputModel.Country.Length > 100)
                output.Messages.Add("The customer country cannot exceed 100 characters");

            if (!string.IsNullOrWhiteSpace(inputModel.City) && inputModel.City.Length > 100)
                output.Messages.Add("The customer city cannot exceed 100 characters");

            if (!string.IsNullOrWhiteSpace(inputModel.Zip) && inputModel.City.Length > 10)
                output.Messages.Add("The customer zip code cannot exceed 10 characters");

            if (output.Messages.Count > 0)
                output.IsSucceeded = false;
            else
                output.IsSucceeded = true;

            return output;
        }
    }
}
