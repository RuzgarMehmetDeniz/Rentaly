using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.CarViewComponentPartial
{
    public class _CarSeatViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke( )
        {
            return View();
        }
    }
}
