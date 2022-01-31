using Gringotts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IGringottsDataContext _context;
        public CustomerRepository(IGringottsDataContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task Delete(int id)
        {
            var customerToDelete = await _context.Customer.FindAsync(id);

            if (customerToDelete == null)
                throw new NullReferenceException();

            _context.Customer.Remove(customerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Get(int customerNumber)
        {
            return await _context.Customer.Where(c => c.CustomerNumber == customerNumber).FirstOrDefaultAsync();
        }

        public async Task Update(Customer customer)
        {
            var customerToUpdate = await _context.Customer.FindAsync(customer.Id);

            if (customerToUpdate == null)
                throw new NullReferenceException();

            customerToUpdate.City = customer.City;
            customerToUpdate.Country = customer.Country;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.YearBirth = customer.YearBirth;
            customerToUpdate.Zip = customer.Zip;
            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.MiddleName = customer.MiddleName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Gender = customer.Gender;
            customerToUpdate.LastUpdatedOn = DateTime.Now;
        }
    }
}
