using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyAPI.Data;

namespace YummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   /* [Authorize]*/
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet("Index")]
        public IActionResult Index()
        {
            var data = _context.ecomPortfolios.FirstOrDefault();
            return Ok(data);
        }
    }
}
