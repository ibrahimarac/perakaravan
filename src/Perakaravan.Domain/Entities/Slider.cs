using Perakaravan.Domain.Common;

namespace Perakaravan.Domain.Entities
{
    public class Slider : Entity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RedirectUrl { get; set; }
    }
}
