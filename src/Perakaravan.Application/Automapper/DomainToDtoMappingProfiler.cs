using AutoMapper;
using Microsoft.Extensions.Configuration;
using Perakaravan.Application.Dtos.Response.Logins;
using Perakaravan.Domain.Entities;

namespace Perakaravan.Application.Automapper
{
    public class DomainToDtoMappingProfiler : Profile
    {
        public DomainToDtoMappingProfiler(IConfiguration configuration)
        {
            CreateMap<LoginUser, LoginUserDto>();

            CreateMap<Slider, SliderResponseDto>()
                .ForMember(x => x.ImageUrl, 
                    y => y.MapFrom(e => $"{configuration["Application:BasePath"]}/{e.ImageUrl}"));
            CreateMap<Slider, SliderDetailResponseDto>()
                .ForMember(x => x.ImageUrl,
                    y => y.MapFrom(e => $"{configuration["Application:BasePath"]}/{e.ImageUrl}"));


        }
    }
}
