using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.CarViewComponentPartial
{
    public class _CarCategoryViewComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CarCategoryViewComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.TGetListAsync();
            return View(values);
        }
    }
}