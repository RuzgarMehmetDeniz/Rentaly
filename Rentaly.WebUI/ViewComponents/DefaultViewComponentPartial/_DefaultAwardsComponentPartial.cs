using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concreate;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultAwardsComponentPartial : ViewComponent
    {
        private readonly RentalyContext _context;

        public _DefaultAwardsComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _context.Awards
                .Take(3)
                .ToListAsync();

            return View(value);
        }
    }
}
