using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.WebUI.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<IActionResult> BranchList()
        {
            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "Şube Yönetimi";
            ViewBag.Title3 = "Şube Listesi";
            var values = await _branchService.TGetListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch(Branch branch)
        {
            await _branchService.TInsertAsync(branch);
            return RedirectToAction("BranchList");
        }
        public async Task<IActionResult> DeleteBranch(int id)
        {
            await _branchService.TDeleteAsync(id);
            return RedirectToAction("BranchList");
        }
    }
}