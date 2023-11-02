using Microsoft.AspNetCore.Mvc;

namespace YummyM.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
