using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICategoryService _categoryService;
        private readonly IBranchService _branchService;
        private readonly IBrandService _brandService;
        private readonly ICarModelService _modelService;

        public CarController(ICarService carService, ICategoryService categoryService, IBranchService branchService, IBrandService brandService, ICarModelService modelService)
        {
            _carService = carService;
            _categoryService = categoryService;
            _branchService = branchService;
            _brandService = brandService;
            _modelService = modelService;
        }

        public async Task<IActionResult> CarList()
        {
            var values = await _carService.TGetAllCarWithCategoryAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            ViewBag.Categories = new SelectList(await _categoryService.TGetListAsync(), "CategoryId", "CategoryName");
            ViewBag.Brands = new SelectList(await _brandService.TGetListAsync(), "BrandId", "BrandName");
            ViewBag.Models = new SelectList(await _modelService.TGetListAsync(), "ModelId", "ModelName");
            ViewBag.Branches = new SelectList(await _branchService.TGetListAsync(), "BranchId", "BranchName");
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(Car car)
        {
            await _carService.TInsertAsync(car);
            return RedirectToAction("CarList");
        }
    }
}
