using GringottsAPI.Models;

namespace GringottsAPI.Validations
{
    /// <summary>
    /// Validation methods for the account processes
    /// </summary>
    public static class AccountValidator
    {
        private static readonly List<string> Currencies = new List<string>() { "TRY", "USD", "EUR", "CAD" };
        private static readonly List<int> AccountTypes = new List<int>() { 1, 2 };

        /// <summary>
        /// Validate new account input model
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public static AddAccountOutputModel ValidateAddAccountInputModel(AddAccountInputModel inputModel)
        {
            AddAccountOutputModel output = new AddAccountOutputModel() { Messages = new List<string>() };

            if (inputModel == null)
            {
                output.Messages.Add("Add new account model can not be null.");
                return output;
            }

            if (inputModel.CustomerNumber.ToString().Length != 10)
                output.Messages.Add("The customer number must be 10 digits.");

            if (inputModel.AccountNumber.ToString().Length != 16)
                output.Messages.Add("The account number must be 16 digits.");

            if (!AccountTypes.Contains(inputModel.AccountType))
                output.Messages.Add("The account type is not valid. It should be 1(Checking Account) or 2(Deposit Account).");

            if(inputModel.BeginBalance < 0 || inputModel.BeginBalance > 10000000)
                output.Messages.Add("The Begin Balance should be between 0 and 10,000,000.00.");

            if (string.IsNullOrWhiteSpace(inputModel.AccountName))
                output.Messages.Add("AccountName can not be null.");

            if (string.IsNullOrWhiteSpace(inputModel.Currency) || !Currencies.Contains(inputModel.Currency))
                output.Messages.Add("Currency is not valid.");

            if (output.Messages.Count > 0)
                output.IsSucceeded = false;
            else
                output.IsSucceeded = true;

            return output;
        }
    }
}
