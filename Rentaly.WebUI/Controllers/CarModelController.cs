using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.WebUI.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ICarModelService _carModelService;
        private readonly IBrandService _brandService;

        public CarModelController(ICarModelService carModelService, IBrandService brandService)
        {
            _carModelService = carModelService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _carModelService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCarModel()
        {
            var brands = await _brandService.TGetListAsync();
            ViewBag.Brands = new SelectList(brands, "BrandId", "BrandName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarModel(CarModel carModel)
        {
            await _carModelService.TInsertAsync(carModel);
            TempData["Success"] = "Model başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCarModel(int id)
        {
            var brands = await _brandService.TGetListAsync();
            ViewBag.Brands = new SelectList(brands, "BrandId", "BrandName");
            var value = await _carModelService.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCarModel(CarModel carModel)
        {
            await _carModelService.TUpdateAsync(carModel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCarModel(int id)
        {
            await _carModelService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}