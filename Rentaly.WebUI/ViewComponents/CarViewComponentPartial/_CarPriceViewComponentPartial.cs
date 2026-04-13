using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Rentaly.WebUI.ViewComponents.CarViewComponentPartial
{
    public class _CarPriceViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Fiyat aralıklarını (Min-Max) içeren bir yapı oluşturuyoruz
            var priceRanges = new List<PriceRangeModel>
            {
                new PriceRangeModel { Text = "0 - 1000 TL", Min = 0, Max = 1000 },
                new PriceRangeModel { Text = "1000 - 2000 TL", Min = 1000, Max = 2000 },
                new PriceRangeModel { Text = "2000 - 5000 TL", Min = 2000, Max = 5000 },
                new PriceRangeModel { Text = "5000 TL +", Min = 5000, Max = 50000 }
            };
            return View(priceRanges);
        }
    }

    public class PriceRangeModel
    {
        public string Text { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}