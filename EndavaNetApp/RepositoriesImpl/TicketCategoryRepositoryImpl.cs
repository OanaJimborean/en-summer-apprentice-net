using EndavaNetApp.Models;
using EndavaNetApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EndavaNetApp.RepositoriesImpl
{
    public class TicketCategoryRepositoryImpl : ITicketCategoryRepository
    {
        private TicketManagementSystemContext _dbContext;
        public TicketCategoryRepositoryImpl()
        {
            _dbContext = new TicketManagementSystemContext();
        }
        public int Add(TicketCategory @ticketCategory)
        {
            throw new NotImplementedException();
        }
        public void Delete(TicketCategory @ticketCategory)
        {
            _dbContext.Remove(@ticketCategory);
            _dbContext.SaveChanges();
        }
        public IEnumerable<TicketCategory> GetAll()
        {
            var @ticketCategory = _dbContext.TicketCategories;
            return @ticketCategory;
        }
        public async Task<TicketCategory> GetById(int id)
        {
            var @ticketCategory = await _dbContext.TicketCategories
             .Where(e => e.TicketCategoryid == id).FirstOrDefaultAsync();
            return @ticketCategory;
        }
        public void Update(TicketCategory @ticketCategory)
        {
            _dbContext.Entry(@ticketCategory).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
