using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
