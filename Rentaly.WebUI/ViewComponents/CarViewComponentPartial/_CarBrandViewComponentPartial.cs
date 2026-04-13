using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.CarViewComponentPartial
{
    public class _CarBrandViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
