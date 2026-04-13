using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concreate;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultCallUsNowComponentPartial:ViewComponent
    {
        private readonly RentalyContext _context;

        public _DefaultCallUsNowComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value= await _context.Contacts.Take(1).ToListAsync();
            return View(value);
        }
    }
}
