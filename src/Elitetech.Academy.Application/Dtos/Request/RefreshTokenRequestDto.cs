﻿namespace Perakaravan.Application.Dtos.Request
{
    public class RefreshTokenRequestDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
