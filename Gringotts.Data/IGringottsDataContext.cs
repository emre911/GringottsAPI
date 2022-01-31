using Gringotts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Gringotts.Data
{
    public interface IGringottsDataContext
    {
        public DatabaseFacade Database { get; }
        DbSet<User> User { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Account> Account { get; set; }
        DbSet<AccountHistory> AccountHistory { get; set; }
        DbSet<Transaction> Transaction { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
