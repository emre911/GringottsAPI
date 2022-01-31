using Gringotts.Data.Entities;
using GringottsAPI.Models;

namespace GringottsAPI.Mappers
{
    /// <summary>
    /// Mapper class for transaction objects
    /// </summary>
    public static class TransactionMapper
    {
        /// <summary>
        /// Map transaction input model
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="account"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Transaction MapTransactionInputModel(AddTransactionInputModel inputModel, Account account, string? userName)
        {
            Transaction newTransaction = new()
            {
                CustomerNumber = account.CustomerNumber,
                AccountNumber = inputModel.AccountNumber,
                Type = inputModel.TransactionType.ToString(),
                Currency = inputModel.Currency,
                Amount = inputModel.Amount,
                OldBalance = account.Balance,
                CreatedBy = userName ?? "System",
                CreatedOn = DateTime.Now
            };

            newTransaction.NewBalance = newTransaction.Type == "D" ? (newTransaction.OldBalance + inputModel.Amount) : (newTransaction.OldBalance - inputModel.Amount);

            return newTransaction;
        }
    }
}
