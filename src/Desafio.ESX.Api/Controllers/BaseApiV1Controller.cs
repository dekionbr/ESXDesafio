using Microsoft.AspNetCore.Mvc;

namespace Desafio.ESX.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseApiV1Controller : ControllerBase
    {

        protected IActionResult BadResponse(object result = null)
        {
            return BadRequest(new
            {
                success = false,
                errors = result
            });
        }

        protected new IActionResult Response(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }
    }
}