using Microsoft.AspNetCore.Mvc;
using Rentaly.DataAccessLayer.Abstract;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.DefaultViewComponentPartial
{
    public class _DefaultOurFeatureComponentPartial : ViewComponent
    {
        private readonly IOurFeatureDal _ourFeatureDal;

        public _DefaultOurFeatureComponentPartial(IOurFeatureDal ourFeatureDal)
        {
            _ourFeatureDal = ourFeatureDal;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _ourFeatureDal.GetListAsync();
            var firstValue = values.FirstOrDefault();

            return View(firstValue);
        }
    }
}
