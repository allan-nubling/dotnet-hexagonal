using Microsoft.AspNetCore.Mvc;

namespace Application.API.v1.Controllers
{
    [ApiController]
    [ApiV1Route("[controller]")]
    public class HealthCheckController : ControllerBase

    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Healthy!");
        }
    }
}