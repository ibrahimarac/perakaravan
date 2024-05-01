namespace Perakaravan.Application.Dtos.Response.Logins
{
    public class LoginResponseDto
    {
        public LoginUserDto LoginUser { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
    }

    public class LoginUserDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }
    }
}
