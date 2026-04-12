using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Abstract;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultNavbarComponentPartial:ViewComponent
    {
        private readonly IContactDal _contactDal;

        public _DefaultNavbarComponentPartial(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactDal.GetListAsync();
            return View(values);
        }
    }
}
