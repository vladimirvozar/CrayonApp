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
        }
    }
}
