using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultHeroComponentPartial : ViewComponent
    {
        private readonly IBranchService _branchService;

        public _DefaultHeroComponentPartial(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var branches = await _branchService.TGetListAsync();
            return View(branches);
        }
    }
}