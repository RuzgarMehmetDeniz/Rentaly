using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "Referans Yönetimi";
            ViewBag.Title3 = "Referans Listesi";
            var values = await _testimonialService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(Testimonial testimonial)
        {
            await _testimonialService.TInsertAsync(testimonial);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _testimonialService.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(Testimonial testimonial)
        {
            await _testimonialService.TUpdateAsync(testimonial);
            return RedirectToAction("Index");
        }
    }
}