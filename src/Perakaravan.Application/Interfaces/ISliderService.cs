using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.Application.Wrapper;

namespace Perakaravan.Application.Interfaces
{
    public interface ISliderService
    {
        Task<Result> CreateSlider(SliderCreateRequestDto sliderModel);
    }
}
