using Gringotts.Data.Entities;
using GringottsAPI.Models;

namespace GringottsAPI.Mappers
{
    /// <summary>
    /// Mapper class for account objects
    /// </summary>
    public static class AccountMapper
    {
        /// <summary>
        /// Map account output model
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static GetAccountOutputModel MapAccountOutputModel(Account account)
        {
            GetAccountOutputModel outputModel = new()
            {
                IsSucceeded = true,
                Account = account
            };

            return outputModel;
        }

        /// <summary>
        /// Map account history model
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static AccountHistory MapAccountHistory(Account account)
        {
            AccountHistory accountHistory = new()
            {
                AccountName = account.AccountName,
                AccountNumber = account.AccountNumber,
                AccountType = account.AccountType,
                Balance = account.Balance,
                BeginBalance = account.BeginBalance,
                CreatedBy = account.CreatedBy,
                CreatedOn = account.CreatedOn,
                Currency = account.Currency,
                CustomerNumber = account.CustomerNumber,
                DateClosed = account.DateClosed,
                DateOpened = account.DateOpened,    
                Description = account.Description,
                IsActive = account.IsActive,
                LastUpdatedBy = account.LastUpdatedBy,
                LastUpdatedOn = account.LastUpdatedOn,  
                LoggedOn = DateTime.Now
            };

            return accountHistory;
        }

        /// <summary>
        /// Map all accounts for the customer output model
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static GetAllAccountsOfCustomerOutputModel MapAllAccountsOfCustomerOutputModel(List<Account> accounts)
        {
            GetAllAccountsOfCustomerOutputModel outputModel = new()
            {
                IsSucceeded = true,
                Accounts = accounts
            };

            return outputModel;
        }

        /// <summary>
        /// Map account input model
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Account MapAccountInputModel(AddAccountInputModel inputModel, string? userName)
        {
            Account newAccount = new()
            {
                CustomerNumber = inputModel.CustomerNumber,
                AccountNumber = inputModel.AccountNumber,
                AccountName = inputModel.AccountName,  
                AccountType = inputModel.AccountType,   
                BeginBalance = inputModel.BeginBalance,
                Balance = inputModel.BeginBalance,
                Currency = inputModel.Currency,
                Description = inputModel.Description,      
                DateOpened = inputModel.DateOpened > DateTime.Now ? inputModel.DateOpened : DateTime.Now,        
                CreatedBy = userName ?? "System",
                CreatedOn = DateTime.Now
            };

            return newAccount;
        }
    }
}
