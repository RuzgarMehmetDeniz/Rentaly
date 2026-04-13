using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.CarViewComponentPartial
{
    public class _CarPriceViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
