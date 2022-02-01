using Gringotts.Data.Entities;

namespace Gringotts.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(long customerNumber);

        Task<int> Add(Customer customer);

        Task Delete(int customerId);

        Task Update(Customer customer);
    }
}
