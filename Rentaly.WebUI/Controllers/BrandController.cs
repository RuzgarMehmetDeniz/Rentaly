using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.Businesslayer.ValidationRules;
using Rentaly.EntityLayer.Entities;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<IActionResult> Index()
        {
            var value= await _brandService.TGetListAsync();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(Brand brand)
        {
            var validator = new BrandValidator();
            var result = validator.Validate(brand);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                return View(brand);
            }

            await _brandService.TInsertAsync(brand);
            return RedirectToAction("Index");
        }
    }
}
