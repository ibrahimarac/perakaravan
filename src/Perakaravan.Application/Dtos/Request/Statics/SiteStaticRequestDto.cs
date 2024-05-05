using Microsoft.AspNetCore.Http;

namespace Perakaravan.Application.Dtos.Request.Statics
{
    public class SiteStaticRequestDto
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string GoogleMap { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string HomepageTitle { get; set; }
        public string Footer { get; set; }
        public IFormFile Logo { get; set; }
        public string LogoTitle { get; set; }
    }
}
