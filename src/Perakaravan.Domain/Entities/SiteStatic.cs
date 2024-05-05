using Perakaravan.Domain.Common;

namespace Perakaravan.Domain.Entities
{
    public class SiteStatic : Entity
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
        public string Logo { get; set; }
        public string LogoTitle { get; set; }
        public string SmtpUrl { get; set; }
        public string SmtpDisplayName { get; set; }
        public int SmtpPort { get; set; }
    }
}
