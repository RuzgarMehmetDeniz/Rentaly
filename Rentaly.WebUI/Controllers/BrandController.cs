using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.Businesslayer.ValidationRules;
using Rentaly.EntityLayer.Entities;

public class BrandController : Controller
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Title1 = "Ana Sayfa";
        ViewBag.Title2 = "Marka Yönetimi";
        ViewBag.Title3 = "Marka Listesi";
        var value = await _brandService.TGetListAsync();
        return View(value);
    }
    [HttpGet]
    public IActionResult CreateBrand() => View();

    [HttpPost]
    public async Task<IActionResult> CreateBrand(Brand brand)
    {
        if (ModelState.IsValid)
        {
            await _brandService.TInsertAsync(brand);
            return RedirectToAction("Index");
        }
        return View(brand);
    }

    public async Task<IActionResult> DeleteBrand(int id)
    {
        await _brandService.TDeleteAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBrand(int id)
    {
        var value = await _brandService.TGetByIdAsync(id);
        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBrand(Brand brand)
    {
        if (ModelState.IsValid)
        {
            await _brandService.TUpdateAsync(brand);
            return RedirectToAction("Index");
        }

        return View(brand);
    }
}