using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concreate;
using Rentaly.EntityLayer.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly RentalyContext _context;

        public BookingController(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int carId, int pickupLocationId, int dropoffLocationId, DateTime pickUpDate, DateTime returnDate)
        {
            var car = await _context.Cars
                .Include(x => x.Brand)
                .Include(x => x.CarModel)
                .FirstOrDefaultAsync(x => x.CarId == carId);

            if (car == null) return NotFound();

            // Lokasyonları Branches tablosundan çekiyoruz
            var pickupLocation = await _context.Branches.FindAsync(pickupLocationId);
            var dropoffLocation = await _context.Branches.FindAsync(dropoffLocationId);

            ViewBag.SelectedCarId = carId;
            ViewBag.CarName = $"{car.Brand.BrandName} {car.CarModel.ModelName}";
            ViewBag.CarImage = car.ImageUrl;
            ViewBag.PickupId = pickupLocationId;
            ViewBag.DropoffId = dropoffLocationId;

            // Şube isimlerini ViewBag'e atıyoruz
            ViewBag.PickupName = pickupLocation?.BranchName ?? "Şube Bulunamadı";
            ViewBag.DropoffName = dropoffLocation?.BranchName ?? "Şube Bulunamadı";

            ViewBag.Start = pickUpDate;
            ViewBag.End = returnDate;

            int totalDays = (returnDate - pickUpDate).Days;
            if (totalDays <= 0) totalDays = 1;
            ViewBag.TotalPrice = totalDays * car.DailyPrice;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CompleteBooking(Rental rental)
        {
            if (rental == null) return BadRequest();

            try
            {
                // 1. Rezervasyon durumunu ve verilerini hazırla
                rental.Status = "Onaylandı";
                _context.Rentals.Add(rental);

                // 2. Aracı bul ve müsaitlik durumunu güncelle
                var car = await _context.Cars.FindAsync(rental.CarId);
                if (car != null)
                {
                    car.IsAvailable = false;
                    _context.Entry(car).State = EntityState.Modified;
                }

                // 3. Değişiklikleri tek bir transaction gibi kaydet
                await _context.SaveChangesAsync();

                // İşlem başarılıysa ana sayfaya veya "Rezervasyonlarım" gibi bir yere yönlendir
                return RedirectToAction("Index", "Default");
            }
            catch (Exception)
            {
                // Hata durumunda loglama yapılabilir veya kullanıcıya mesaj dönebilir
                ModelState.AddModelError("", "Rezervasyon sırasında bir hata oluştu.");
                return View("Index");
            }
        }
    }
}