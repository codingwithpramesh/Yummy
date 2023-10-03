using Microsoft.AspNetCore.Mvc;

namespace YummyM.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
