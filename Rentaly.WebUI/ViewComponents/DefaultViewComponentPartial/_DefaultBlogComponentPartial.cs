using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concreate;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultBlogComponentPartial : ViewComponent
    {
        private readonly RentalyContext _rentalyContext;

        public _DefaultBlogComponentPartial(RentalyContext rentalyContext)
        {
            _rentalyContext = rentalyContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _rentalyContext.LatestNews.Take(3).ToListAsync();
            return View(value);
        }
    }
}
