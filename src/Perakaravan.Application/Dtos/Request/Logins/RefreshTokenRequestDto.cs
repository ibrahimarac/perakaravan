namespace Perakaravan.Application.Dtos.Request.Logins
{
    public class RefreshTokenRequestDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
