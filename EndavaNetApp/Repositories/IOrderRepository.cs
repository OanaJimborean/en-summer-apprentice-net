using EndavaNetApp.Models;

namespace EndavaNetApp.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Delete(Order @order);
        void Update(Order @order);
    }
}
