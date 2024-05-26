using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SoftwareProduct, SoftwareProductDto>();
            CreateMap<License, LicenseDto>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Account, AccountDto>();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.SoftwareLicense.Account.Name))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString("MM/dd/yyyy hh:mm tt")));
        }
    }
}