using Microsoft.AspNetCore.Mvc;

namespace endPoint.website.Areas.Admin.Controllers
{
    public class Home : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
