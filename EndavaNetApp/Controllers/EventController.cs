using AutoMapper;
using EndavaNetApp.Model.Dto;
using EndavaNetApp.Models;
using EndavaNetApp.Models.Dto;
using EndavaNetApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;

namespace EndavaNetApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly TicketManagementSystemContext _ticketManagementSystemContext;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper) {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll();

            var dtoEvents = events.Select(e => new EventDto()
            {
                EventID = e.Eventid,
                EventDescription = e.EventDescription,
                EventName = e.EventName,
                EventType = e.EventType?.EventTypeName ?? string.Empty,
                Venue = e.Venue?.Location ?? string.Empty
            });

            return Ok(dtoEvents);
        }

        [HttpGet]
        public ActionResult<EventDto> GetByID(int id)
        {
            var @event = _eventRepository.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            var eventDto = _mapper.Map<EventDto>(@event);

            return Ok(eventDto);
        }

        [HttpPatch]
        public ActionResult<EventPatchDto> Patch(EventPatchDto eventPatchDto)
        {
            var eventEntity = _eventRepository.GetById(eventPatchDto.EventId);
            if(eventEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(eventPatchDto, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var eventEntity = _eventRepository.GetById(id);
            if(eventEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }

    }
}


