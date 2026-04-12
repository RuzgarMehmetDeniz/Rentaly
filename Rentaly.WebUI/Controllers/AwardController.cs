using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class AwardController : Controller
    {
        private readonly IAwardService _awardService;

        public AwardController(IAwardService awardService)
        {
            _awardService = awardService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "Ödül Yönetimi";
            ViewBag.Title3 = "Ödüllerimizin Listesi";
            var values = await _awardService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAward()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAward(Award award)
        {
            await _awardService.TInsertAsync(award);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAward(int id)
        {
            await _awardService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAward(int id)
        {
            var value = await _awardService.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAward(Award award)
        {
            await _awardService.TUpdateAsync(award);
            return RedirectToAction("Index");
        }
    }
}