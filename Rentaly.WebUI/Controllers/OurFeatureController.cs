using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class OurFeatureController : Controller
    {
        private readonly IOurFeatureService _ourFeatureService;

        public OurFeatureController(IOurFeatureService ourFeatureService)
        {
            _ourFeatureService = ourFeatureService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "Özelliklerimizin Yönetimi";
            ViewBag.Title3 = "Özelliklerimiz Listesi";
            var values =await _ourFeatureService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public  IActionResult CreateOurFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOurFeature(OurFeature ourFeature)
        {
            await _ourFeatureService.TInsertAsync(ourFeature);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOurFeature(int id)
        {
           await _ourFeatureService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOurFeature(int id)
        {
            var value = await _ourFeatureService.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOurFeature(OurFeature ourFeature)
        {
            await _ourFeatureService.TUpdateAsync(ourFeature);
            return RedirectToAction("Index");
        }
    }
}