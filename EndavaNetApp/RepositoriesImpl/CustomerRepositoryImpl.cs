using EndavaNetApp.Models;
using EndavaNetApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Umbraco.Core.Persistence;

namespace EndavaNetApp.RepositoriesImpl
{
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public CustomerRepositoryImpl()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        public int Add(Customer @customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer @customer)
        {
            _dbContext.Remove(@customer);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _dbContext.Customers;

            return customers;
        }

        public async Task<Customer> GetById(int id)
        {
            var @customer = await _dbContext.Customers.Where(c => c.Customerid == id).FirstOrDefaultAsync();

            /*if (@customer == null)
                throw new EntityNotFoundException(id, nameof(Customer));*/

            return @customer;
        }


        public void Update(Customer @customer)
        {
            _dbContext.Entry(@customer).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
