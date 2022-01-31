using Gringotts.Data.Entities;

namespace Gringotts.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> Get(long accountNumber);
        Task<List<Account>> GetAll(int customerNumber);

        Task<int> Add(Account account);
        Task<long> AddHistory(AccountHistory accountHistory);

        Task Delete(long accountNumber);

        Task Update(Account account);
    }
}
