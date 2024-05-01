using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Perakaravan.Application.Dtos.Request.Logins;
using Perakaravan.Application.Interfaces;
using Perakaravan.Application.Wrapper;

namespace Perakaravan.Services.Api.Controllers
{
    [Route("login")]
    public class LoginController : ApiController
    {
        private readonly ILoginUserService _loginUserService;
        private readonly IValidator<LoginRequestDto> _loginValidator;

        public LoginController(ILoginUserService loginUserService, IValidator<LoginRequestDto> loginValidator)
        {
            _loginUserService = loginUserService;
            _loginValidator = loginValidator;
        }

        [HttpPost("access-token")]        
        public async Task<IActionResult> GenerateAccessToken([FromBody] LoginRequestDto loginRequest)
        {
            var validationResult = _loginValidator.Validate(loginRequest);
            if (!validationResult.IsValid)
            {
                return CustomResponse(Result.Error(validationResult.Errors.Select(x => x.ErrorMessage).ToArray()));
            }
            return CustomResponse(await _loginUserService.Login(loginRequest));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> GenerateRefreshToken([FromBody] RefreshTokenRequestDto refreshTokenRequest)
        {
            return CustomResponse(await _loginUserService.CreateRefreshTokenAsync(refreshTokenRequest));
        }
    }
}
