﻿using EndavaNetApp.Models;
using EndavaNetApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EndavaNetApp.RepositoriesImpl
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public EventRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;

            return events;
        }

        public Event GetById(int id)
        {
            var @event = _dbContext.Events.Where(e => e.Eventid == id).FirstOrDefault();

            return @event;
        }


        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

    }
}
