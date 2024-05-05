using AutoMapper;
using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.Domain.Entities;

namespace Perakaravan.Application.Automapper
{
    public class DtoToDomainMappingProfiler : Profile
    {
        public DtoToDomainMappingProfiler()
        {
            CreateMap<SliderCreateRequestDto, Slider>();
            CreateMap<SliderUpdateRequestDto, Slider>();
        }
    }
}
