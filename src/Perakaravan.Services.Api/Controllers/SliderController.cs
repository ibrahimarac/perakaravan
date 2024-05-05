using Microsoft.AspNetCore.Mvc;
using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.Application.Interfaces;

namespace Perakaravan.Services.Api.Controllers
{
    [Route("slider")]
    public class SliderController : ApiController
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] SliderCreateRequestDto sliderModel)
        {
            return CustomResponse(await _sliderService.CreateSlider(sliderModel));
        }
    }
}
