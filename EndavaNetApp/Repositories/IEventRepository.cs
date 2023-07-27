using EndavaNetApp.Models;

namespace EndavaNetApp.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event GetById(int id);

        int Add(Event @event);

        void Update(Event @event);

        void Delete(Event @event);
    }
}
