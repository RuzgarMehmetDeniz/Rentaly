using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Rentaly.WebUI.ViewComponents.CarViewComponentPartial
{
    public class _CarSeatViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // İsteğine göre 3'ten 6'ya kadar olan koltuk sayılarını gönderiyoruz
            var seats = new List<int> { 3, 4, 5, 6 };
            return View(seats);
        }
    }
}