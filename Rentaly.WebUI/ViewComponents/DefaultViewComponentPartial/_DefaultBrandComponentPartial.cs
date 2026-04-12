using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultBrandComponentPartial:ViewComponent
    {
        private readonly IBrandService _brandService;

        public _DefaultBrandComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value= await _brandService.TGetListAsync();
            return View(value);
        }
    }
}
