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
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
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
        public async Task<ActionResult<EventDto>> GetByID(int id)
        {
        
                var @event = await _eventRepository.GetById(id);

                /*if (@event == null)
                {
                    return NotFound();
                }*/

                var eventDto = _mapper.Map<EventDto>(@event);

                return Ok(eventDto);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatchDto)
        {
            if (eventPatchDto == null) throw new ArgumentNullException(nameof(eventPatchDto));
            var eventEntity = await _eventRepository.GetById(eventPatchDto.EventId);
            if(eventEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(eventPatchDto, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if(eventEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }

    }
}


