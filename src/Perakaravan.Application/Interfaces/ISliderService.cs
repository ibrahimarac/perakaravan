using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.Application.Wrapper;

namespace Perakaravan.Application.Interfaces
{
    public interface ISliderService
    {
        Task<Result> GetAllSlider();
        Task<Result> GetAllSliderDetail();
        Task<Result> CreateSlider(SliderCreateRequestDto sliderModel);
        Task<Result> UpdateSlider(SliderUpdateRequestDto sliderModel);
        Task<Result> DeleteSlider(int id);
    }
}
