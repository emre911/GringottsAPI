using Gringotts.Data.Entities;

namespace Gringotts.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(int customerNumber);

        Task<int> Add(Customer customer);

        Task Delete(int CustomerNumber);

        Task Update(Customer customer);
    }
}
