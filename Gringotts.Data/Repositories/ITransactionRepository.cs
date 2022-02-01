using Gringotts.Data.Entities;

namespace Gringotts.Data.Repositories
{
    public interface ITransactionRepository
    {
        Task<int> Add(Transaction transaction);

        Task<List<Transaction>> ListWithAccountNumber(long accountNumber);

        Task<List<Transaction>> ListWithCustomerTimeline(long customerNumber, DateTime startDate, DateTime endDate);
    }
}
