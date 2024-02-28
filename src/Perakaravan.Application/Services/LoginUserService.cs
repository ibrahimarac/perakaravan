using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Perakaravan.Application.Dtos.Request;
using Perakaravan.Application.Dtos.Response;
using Perakaravan.Application.Interfaces;
using Perakaravan.Application.Wrapper;
using Perakaravan.Domain.Repositories;
using Perakaravan.InfraPack.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Perakaravan.Application.Services
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LoginUserService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<Result> Login(LoginRequestDto loginUserRequest)
        {
            var loginUser = await _unitOfWork.LoginUserRepository.FirstOrDefaultAsync(x => x.Username == loginUserRequest.Username &&
                x.Password == loginUserRequest.Password);

            if (loginUser is null)
            {
                return Result.NotFound();
            }

            #region Token üretiliyor

            var tokenExpireDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:TokenExpireMinutes"] ?? ""));

            var claims = new[]
            {
                new Claim("UserId", loginUser.Id.ToString()),
                new Claim("Username", loginUser.Username)
            };

            var token = GenerateToken(tokenExpireDate, claims.ToList());

            #endregion

            #region Refresh token üretiliyor

            var refreshTokenExpireDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:RefreshTokenExpireMinutes"] ?? ""));

            var refreshToken = GenerateRefreshToken();

            loginUser.RefreshToken = refreshToken;
            loginUser.RefreshTokenExpire = refreshTokenExpireDate;

            _unitOfWork.LoginUserRepository.Update(loginUser);
            await _unitOfWork.CommitAsync();

            #endregion

            return Result.Success(new LoginResponseDto
            {
                LoginUser = _mapper.Map<LoginUserDto>(loginUser),
                Token = token,
                TokenExpireDate = tokenExpireDate,
                RefreshToken = refreshToken,
                RefreshTokenExpireDate = refreshTokenExpireDate
            });

        }


        public async Task<Result> CreateRefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequest)
        {

            var tokenExpireDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:TokenExpireMinutes"] ?? ""));
            var refreshTokenExpireDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:RefreshTokenExpireMinutes"] ?? ""));

            ClaimsPrincipal principle = GetPrincipalFromExpiredToken(refreshTokenRequest.AccessToken);

            int userId;
            var getUserIdResult = int.TryParse(principle.FindFirst("Id")?.Value, out userId);
            if (!getUserIdResult)
            {
                return Result.Error("Access token geçerli değil.");
            }

            var existsUser = await _unitOfWork.LoginUserRepository.GetByIdAsync(userId);

            if (existsUser is null || existsUser.RefreshToken != refreshTokenRequest.RefreshToken || existsUser.RefreshTokenExpire <= DateTime.UtcNow.ToTurkeyLocalTime())
            {
                return Result.Error("Access token veya refresh token geçerli değil.");
            }

            //Tokenlar üretiliyor
            var accessToken = GenerateToken(tokenExpireDate, principle.Claims.ToList());
            var refreshToken = GenerateRefreshToken();

            //Yeni token bilgileri kaydediliyor.
            existsUser.RefreshToken = refreshToken;
            existsUser.RefreshTokenExpire = refreshTokenExpireDate;
            _unitOfWork.LoginUserRepository.Update(existsUser);
            await _unitOfWork.CommitAsync();

            return Result.Success(new LoginResponseDto
            {
                LoginUser = _mapper.Map<LoginUserDto>(existsUser),
                Token = accessToken,
                TokenExpireDate = tokenExpireDate,
                RefreshToken = refreshToken,
                RefreshTokenExpireDate = refreshTokenExpireDate
            });
        }



        #region Private Methods

        private string GenerateToken(DateTime tokenExpireDate, List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["Jwt:Audience"] ?? "",
                Issuer = _configuration["Jwt:Issuer"] ?? "",
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = tokenExpireDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidAudience = _configuration["Jwt:Audience"] ?? "",
                ValidIssuer = _configuration["Jwt:Issuer"] ?? "",
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"] ?? "")),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        #endregion
    }
}
