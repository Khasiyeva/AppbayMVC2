using Microsoft.AspNetCore.Mvc;

namespace Appbay.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
