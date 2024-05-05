using Microsoft.AspNetCore.Http;

namespace Perakaravan.Application.Dtos.Request.Sliders
{
    public class SliderCreateRequestDto
    {
        public IFormFile ImageFile { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RedirectUrl { get; set; }
    }
}
