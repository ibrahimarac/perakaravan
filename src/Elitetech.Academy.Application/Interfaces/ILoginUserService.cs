using Perakaravan.Application.Dtos.Request;
using Perakaravan.Application.Dtos.Response;
using Perakaravan.Application.Wrapper;

namespace Perakaravan.Application.Interfaces
{
    public interface ILoginUserService
    {
        Task<Result<LoginResponseDto>> Login(LoginRequestDto loginUserRequest);
        Task<Result<LoginResponseDto>> CreateRefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequest);
    }
}
