using Microsoft.AspNetCore.Mvc;
using Perakaravan.InfraPack.Domain;
using System.Security.Claims;

namespace Perakaravan.Services.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SetLoggedUserMiddleware
    {
        private readonly RequestDelegate _next;

        public SetLoggedUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, [FromServices]LoggedUser loggedUser)
        {

            if(httpContext.User?.Identity is not null && loggedUser is not null)
            {
                var claimsIdentity = httpContext.User.Identity as ClaimsIdentity;

                var idClaim = claimsIdentity?.Claims.SingleOrDefault(c => c.Type == "Id");
                bool idClaimResult = int.TryParse(idClaim?.Value, out int userId);
                loggedUser.Id = idClaimResult ? userId : default(int);

                var nameClaim = claimsIdentity?.Claims.SingleOrDefault(c => c.Type == "Name");
                loggedUser.Name = nameClaim?.Value ?? null;

                var surnameClaim = claimsIdentity?.Claims.SingleOrDefault(c => c.Type == "Surname");
                loggedUser.Surname = surnameClaim?.Value ?? null;

                var usernameClaim = claimsIdentity?.Claims.SingleOrDefault(c => c.Type == "Username");
                loggedUser.Username = usernameClaim?.Value ?? null;

                var emailClaim = claimsIdentity?.Claims.SingleOrDefault(c => c.Type == "Email");
                loggedUser.Email = emailClaim?.Value ?? null;

            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SetLoggedUserMiddlewareExtensions
    {
        public static IApplicationBuilder UseSetLoggedUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SetLoggedUserMiddleware>();
        }
    }
}
