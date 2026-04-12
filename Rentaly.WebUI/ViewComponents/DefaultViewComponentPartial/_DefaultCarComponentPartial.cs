using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concreate;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultCarComponentPartial : ViewComponent
    {
        private readonly RentalyContext _context;

        public _DefaultCarComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Cars
                .Include(x => x.Brand)      // Markayı getir
                .Include(x => x.CarModel)   // Modeli getir
                .Include(x => x.Branch)     // Şubeyi getir
                .Where(x => x.IsAvailable == true) // Sadece müsait (True) olanları getir
                .OrderByDescending(x => x.CarId)   // Sondan başa sırala
                .Take(10)                          // İlk 10 tanesini al
                .ToListAsync();

            return View(values);
        }
    }
}
