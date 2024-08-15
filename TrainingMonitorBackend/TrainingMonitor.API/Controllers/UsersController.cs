using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingMonitor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost("register")]
        public IActionResult RegisterUser()
        {
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult LogIn()
        {
            return Ok();
        }
    }
}
