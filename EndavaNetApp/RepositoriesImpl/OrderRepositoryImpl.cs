using EndavaNetApp.Controllers;
using EndavaNetApp.Models;
using EndavaNetApp.Models.Dto;
using EndavaNetApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EndavaNetApp.RepositoriesImpl
{
    public class OrderRepositoryImpl : IOrderRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public OrderRepositoryImpl()
        {
            _dbContext = new TicketManagementSystemContext();
        }
        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;

            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var @order = await _dbContext.Orders.Where(o => o.Orderid == id).FirstOrDefaultAsync();

            return @order;
        }

        public void Delete(Order @order)
        {
            _dbContext.Remove(@order);
            _dbContext.SaveChanges();
        }

        public void Update(Order @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }


    }
}
