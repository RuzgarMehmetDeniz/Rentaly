using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class FAQController : Controller
    {
        private readonly IFAQService _faqService;

        public FAQController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "FAQ Yönetimi";
            ViewBag.Title3 = "FAQ Listesi";
            var values = await _faqService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFAQ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFAQ(FAQ faq)
        {
            await _faqService.TInsertAsync(faq);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFAQ(int id)
        {
            await _faqService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFAQ(int id)
        {
            var value = await _faqService.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFAQ(FAQ faq)
        {
            await _faqService.TUpdateAsync(faq);
            return RedirectToAction("Index");
        }
    }
}