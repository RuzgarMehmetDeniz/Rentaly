using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.CarViewComponentPartial
{
    public class _CarBrandViewComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _CarBrandViewComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.TGetListAsync();
            return View(values); 
        }
    }
}