using Gringotts.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gringotts.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IGringottsDataContext _context;
        public AccountRepository(IGringottsDataContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return account.Id;
        }

        public async Task<long> AddHistory(AccountHistory accountHistory)
        {
            accountHistory.LoggedOn = DateTime.Now;
            _context.AccountHistory.Add(accountHistory);
            await _context.SaveChangesAsync();

            return accountHistory.Id;
        }

        public async Task Delete(long id)
        {
            var accountToDelete = await _context.Account.FindAsync(id);

            if (accountToDelete == null)
                throw new NullReferenceException();

            _context.Account.Remove(accountToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> Get(long accountNumber)
        {
            return await _context.Account.Where(c => c.AccountNumber == accountNumber).FirstOrDefaultAsync();
        }

        public async Task<List<Account>> GetAll(int customerNumber)
        {
            return await _context.Account.Where(c => c.CustomerNumber == customerNumber).ToListAsync();
        }

        public async Task Update(Account account)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var accountToUpdate = await _context.Account.FindAsync(account.Id);

                    if (accountToUpdate == null)
                        throw new NullReferenceException();

                    accountToUpdate.AccountName = account.AccountName;
                    accountToUpdate.DateOpened = account.DateOpened;
                    accountToUpdate.DateClosed = account.DateClosed;
                    accountToUpdate.Description = account.Description;
                    accountToUpdate.LastUpdatedOn = DateTime.Now;
                    accountToUpdate.LastUpdatedBy = account.LastUpdatedBy;
                    accountToUpdate.Balance = account.Balance;

                    _context.Account.Update(accountToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                transaction.Commit();
            }       
        }
    }
}
