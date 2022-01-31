using Gringotts.Data.Entities;
using GringottsAPI.Models;

namespace GringottsAPI.Validations
{
    /// <summary>
    /// Transaction validations
    /// </summary>
    public static class TransactionValidator
    {
        private static readonly List<string> Currencies = new List<string>() { "TRY", "USD", "EUR", "CAD" };
        private static readonly List<char> TransactionTypes = new List<char>() { 'D', 'W' };

        /// <summary>
        /// Validate list transactions of customer input model
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public static ListTransactionsOfCustomerOutputModel ValidateListTransactionsOfCustomerInputModel(ListTransactionsOfCustomerInputModel inputModel)
        {
            ListTransactionsOfCustomerOutputModel output = new ListTransactionsOfCustomerOutputModel() { Messages = new List<string>() };

            if (inputModel == null)
            {
                output.Messages.Add("ListTransactionsOfCustomerInputModel can not be null.");
                return output;
            }

            if (inputModel.CustomerNumber.ToString().Length != 10)
                output.Messages.Add("The customer number must be 10 digits.");

            if(inputModel.StartDate > inputModel.EndDate)
                output.Messages.Add("StartDate can not be greater than EndDate");

            if (output.Messages.Count > 0)
                output.IsSucceeded = false;
            else
                output.IsSucceeded = true;

            return output;
        }

        /// <summary>
        /// Validate new transaction input model
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public static AddTransactionOutputModel ValidateAddTransactionInputModel(AddTransactionInputModel inputModel)
        {
            AddTransactionOutputModel output = new AddTransactionOutputModel() { Messages = new List<string>() };

            if (inputModel == null)
            {
                output.Messages.Add("Add new transaction model can not be null.");
                return output;
            }

            if (inputModel.AccountNumber.ToString().Length != 16)
                output.Messages.Add("The account number must be 16 digits.");

            if (char.IsWhiteSpace(inputModel.TransactionType) || !TransactionTypes.Contains(inputModel.TransactionType))
                output.Messages.Add("The transaction type is not valid. It should be 'D' (Deposit money) or 'W' (Withdraw money).");

            if (string.IsNullOrWhiteSpace(inputModel.Currency) || !Currencies.Contains(inputModel.Currency))
                output.Messages.Add("Currency is not valid.");

            if (inputModel.Amount < 0 || inputModel.Amount > 1000000)
                output.Messages.Add("Transaction amount should be between 0 and 1,000,000.00");

            if (output.Messages.Count > 0)
                output.IsSucceeded = false;
            else
                output.IsSucceeded = true;

            return output;
        }

        /// <summary>
        /// Check account is eligible for the transaction
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static AddTransactionOutputModel CheckAccountForTransaction(AddTransactionInputModel inputModel, Account account)
        {
            AddTransactionOutputModel output = new AddTransactionOutputModel() { Messages = new List<string>() };

            if (account == null)
            {
                output.Messages = new List<string>() { "The account number can not be find for this transaction." };
                output.IsSucceeded = false;
                return output;
            }

            if (account.DateOpened > DateTime.Now)
            {
                output.Messages.Add("Account is not open yet.");
            }

            if (!account.IsActive || (account.DateClosed != null && account.DateClosed < DateTime.Now))
            {
                output.Messages.Add("Account has been closed. No transactions can be made on the account.");
            }

            if (inputModel.TransactionType == 'W' && inputModel.Amount > account.Balance)
            {
                output.Messages.Add("Insufficient account balance.");
            }

            if (inputModel.TransactionType == 'D' && (inputModel.Amount + account.Balance) > 10000000)
            {
                output.Messages.Add("Total account balance cannot exceed 10,000,000.00");
            }

            if (inputModel.Currency != account.Currency)
            {
                output.Messages.Add("The transaction currency and the account currency do not match.");
            }

            if (output.Messages.Count > 0)
                output.IsSucceeded = false;
            else
                output.IsSucceeded = true;

            return output;
        }

        
    }
}
