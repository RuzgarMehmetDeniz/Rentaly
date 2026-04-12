using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;
using System.Threading.Tasks;


namespace Rentaly.WebUI.Controllers
{
    public class LatestNewsController : Controller
    {
        private readonly ILatestNewService _latestNewsService;

        public LatestNewsController(ILatestNewService latestNewsService)
        {
            _latestNewsService = latestNewsService;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "Haber Yönetimi";
            ViewBag.Title3 = "Haber Listesi";
            var values = await _latestNewsService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews(LatestNew latestNews)
        {
            latestNews.CreatedDate = DateTime.Now;
            await _latestNewsService.TInsertAsync(latestNews);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteNews(int id)
        {
            await _latestNewsService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNews(int id)
        {
            var value = await _latestNewsService.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNews(LatestNew latestNews)
        {
            await _latestNewsService.TUpdateAsync(latestNews);
            return RedirectToAction("Index");
        }
    }
}