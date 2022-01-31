using Gringotts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gringotts.Data
{
    public class GringottsDataContext: DbContext, IGringottsDataContext
    {
        public GringottsDataContext(DbContextOptions<GringottsDataContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountHistory> AccountHistory { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GringottsDataContext).Assembly);
        }
    }
}
