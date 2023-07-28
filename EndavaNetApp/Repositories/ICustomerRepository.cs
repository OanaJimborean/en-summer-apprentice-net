using EndavaNetApp.Models;

namespace EndavaNetApp.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Task<Customer> GetById(int id);

        int Add(Customer @customer);

        void Update(Customer @customer);

        void Delete(Customer @customer);
    }
}
