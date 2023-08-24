using AutoMapper;
using EndavaNetApp.Model.Dto;
using EndavaNetApp.Models;
using EndavaNetApp.Models.Dto;

namespace EndavaNetApp.Profiles;

public class EventProfile : Profile
{
    public EventProfile() 
    {
        CreateMap<Event, EventDto>().ReverseMap();
        CreateMap<Event, EventPatchDto>().ReverseMap();
    }
}

