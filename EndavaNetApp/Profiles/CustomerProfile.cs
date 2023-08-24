using EndavaNetApp.Models;
using EndavaNetApp.Models.Dto;
using AutoMapper;
using EndavaNetApp.Model.Dto;

namespace EndavaNetApp.Profiles;
public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerPatchDto>().ReverseMap();
    }
}

