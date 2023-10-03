using Microsoft.AspNetCore.Mvc;

namespace YummyM.Controllers
{
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
