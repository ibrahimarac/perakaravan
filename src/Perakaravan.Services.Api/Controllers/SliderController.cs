using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Perakaravan.Application.Dtos.Request.Sliders;
using Perakaravan.Application.Interfaces;

namespace Perakaravan.Services.Api.Controllers
{
    [Route("slider")]
    [Authorize]
    public class SliderController : ApiController
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await _sliderService.GetAllSlider());
        }

        [HttpGet("get-detail")]
        public async Task<IActionResult> GetAllDetail()
        {
            return CustomResponse(await _sliderService.GetAllSliderDetail());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] SliderCreateRequestDto sliderModel)
        {
            return CustomResponse(await _sliderService.CreateSlider(sliderModel));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] SliderUpdateRequestDto sliderModel)
        {
            return CustomResponse(await _sliderService.UpdateSlider(sliderModel));
        }

        [HttpPut("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CustomResponse(await _sliderService.DeleteSlider(id));
        }
    }
}
