using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyAPI.Data.Service.Abstract;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service) 
        {
            _service = service;
        }

        [HttpPost ("Login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            return Ok();
        }

        [HttpPost("Register")]
        public IActionResult Register()
        {
            return Ok();
        }

    }
}
