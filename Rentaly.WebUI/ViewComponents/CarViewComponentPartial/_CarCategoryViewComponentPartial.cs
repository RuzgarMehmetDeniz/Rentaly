using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.CarViewComponentPartial
{
    public class _CarCategoryViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
