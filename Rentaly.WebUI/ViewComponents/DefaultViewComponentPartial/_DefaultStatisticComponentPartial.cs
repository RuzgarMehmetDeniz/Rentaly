using Microsoft.AspNetCore.Mvc;
using Rentaly.DataAccessLayer.Concreate;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly RentalyContext _context;

        public _DefaultStatisticComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Cars.Count();
            ViewBag.v2 = _context.Brands.Count();
            ViewBag.v3 = _context.Customers.Count();
            ViewBag.v4 = _context.Awards.Count();
            return View();
        }
    }
}
