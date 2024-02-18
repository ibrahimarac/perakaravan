using Perakaravan.Domain.Common;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Attributes;

namespace Perakaravan.Domain.Entities
{
    public class LoginUser : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        [Encrypt]
        public string Password { get; set; }

        [Encrypt]
        public string Email { get; set; }

        [Encrypt]
        public string Phone { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpire { get; set; }
    }
}
