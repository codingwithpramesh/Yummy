using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyAPI.Data;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Home")]
        public IActionResult Home()
        {
            var data = _context.ecomPortfolios.FirstOrDefault();
            return Ok(data);
        }
    }
}
