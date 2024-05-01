using Perakaravan.Application.Dtos.Request.Logins;
using Perakaravan.Application.Wrapper;

namespace Perakaravan.Application.Interfaces
{
    public interface ILoginUserService
    {
        Task<Result> Login(LoginRequestDto loginUserRequest);
        Task<Result> CreateRefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequest);
    }
}
