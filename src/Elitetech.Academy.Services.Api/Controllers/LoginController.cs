using Microsoft.AspNetCore.Mvc;
using Perakaravan.Application.Dtos.Request;
using Perakaravan.Application.Dtos.Response;
using Perakaravan.Application.Interfaces;

namespace Perakaravan.Services.Api.Controllers
{
    [Route("login")]
    public class LoginController : ApiController
    {
        private readonly ILoginUserService _loginUserService;

        public LoginController(ILoginUserService loginUserService)
        {
            _loginUserService = loginUserService;
        }

        [HttpPost("access-token")]
        public async Task<IActionResult> GenerateAccessToken([FromBody] LoginRequestDto loginRequest)
        {
            return CustomResponse(await _loginUserService.Login(loginRequest));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> GenerateRefreshToken([FromBody] RefreshTokenRequestDto refreshTokenRequest)
        {
            return CustomResponse(await _loginUserService.CreateRefreshTokenAsync(refreshTokenRequest));
        }
    }
}
