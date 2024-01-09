using Appbay.Core.Models;
using Appbay.DAL.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Appbay.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
