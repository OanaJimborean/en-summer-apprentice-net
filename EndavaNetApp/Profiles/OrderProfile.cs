using AutoMapper;
using EndavaNetApp.Model.Dto;
using EndavaNetApp.Models.Dto;
using EndavaNetApp.Models;

namespace EndavaNetApp.Profiles;


public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderPatchDto>().ReverseMap();
    }
}