using Microsoft.AspNetCore.Mvc;
using Perakaravan.Application.Wrapper;

namespace Perakaravan.Services.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ActionResult CustomResponse<T>(Result<T> result)
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
