using AutoMapper;
using Perakaravan.Application.Dtos.Response.Logins;
using Perakaravan.Domain.Entities;

namespace Perakaravan.Application.Automapper
{
    public class DomainToDtoMappingProfiler : Profile
    {
        public DomainToDtoMappingProfiler()
        {
            CreateMap<LoginUser, LoginUserDto>();
        }
    }
}
