using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Perakaravan.Application.Wrapper;

namespace Perakaravan.Services.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ActionResult CustomResponse(Result result)
        {

            if (result.Status == ResultStatus.Ok)
            {
                return Ok(result);
            }
            else if(result.Status == ResultStatus.NotFound)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
