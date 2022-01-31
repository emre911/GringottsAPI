using Gringotts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IGringottsDataContext _context;
        public TransactionRepository(IGringottsDataContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Transaction accountTransaction)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Transaction.Add(accountTransaction);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                transaction.Commit();
            }
            return accountTransaction.Id;
        }

        public async Task<List<Transaction>> ListWithAccountNumber(long accountNumber)
        {
            return await _context.Transaction.Where(t => t.AccountNumber == accountNumber && t.IsActive).ToListAsync();
        }

        public async Task<List<Transaction>> ListWithCustomerTimeline(int customerNumber, DateTime startDate, DateTime endDate)
        {
            return await _context.Transaction.Where(t => t.CustomerNumber == customerNumber && t.IsActive && t.CreatedOn >= startDate && t.CreatedOn <= endDate).ToListAsync();
        }
    }
}
