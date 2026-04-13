using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
using Rentaly.DataAccessLayer.Concreate;
using Rentaly.EntityLayer.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Rentaly.WebUI.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly RentalyContext _context;

        public AdminBookingController()
        {
            _context = new RentalyContext();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "Rezervasyon Yönetimi";
            ViewBag.Title3 = "Rezervasyon Listesi";
            // Araç bilgilerini de görmek istersen .Include(x => x.Car) ekleyebilirsin
            var values = await _context.Rentals.ToListAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            await PrepareCarLists();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Rental rental)
        {
            // 1. Onay Kodunu Üret
            string confirmationCode = Guid.NewGuid().ToString("N").Substring(0, 16).ToUpper();
            rental.Description = "Onay Kodu: " + confirmationCode + (string.IsNullOrEmpty(rental.Description) ? "" : " | " + rental.Description);

            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();

            // 2. Durum Kontrolü ve Mail Gönderimi
            if (rental.Status == "Onaylandı")
            {
                await SendConfirmationEmail(rental, confirmationCode);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var value = await _context.Rentals.FindAsync(id);
            if (value != null)
            {
                _context.Rentals.Remove(value);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var value = await _context.Rentals.FindAsync(id);
            await PrepareCarLists();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();

            if (rental.Status == "Onaylandı")
            {
                // Mevcut kodu çek, yoksa yeni üret
                string code = "ONAYLI";
                if (rental.Description != null && rental.Description.Contains("Onay Kodu: "))
                {
                    code = rental.Description.Split("Onay Kodu: ")[1].Substring(0, 16);
                }
                else
                {
                    code = Guid.NewGuid().ToString("N").Substring(0, 16).ToUpper();
                }

                await SendConfirmationEmail(rental, code);
            }

            return RedirectToAction("Index");
        }

        private async Task PrepareCarLists()
        {
            var carList = await _context.Cars
                .Select(x => new
                {
                    x.CarId,
                    x.DailyPrice,
                    Display = x.Brand.BrandName + " " + x.CarModel.ModelName + " (" + x.DailyPrice + " ₺)"
                }).ToListAsync();

            ViewBag.Cars = new SelectList(carList, "CarId", "Display");
            ViewBag.CarPrices = carList.ToDictionary(x => x.CarId.ToString(), x => x.DailyPrice.ToString());
        }
        public async Task<IActionResult> SendConfirmation(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                string discountCode;
                // Açıklama alanında kod var mı kontrol et, yoksa 8 haneli üret
                if (rental.Description != null && rental.Description.Contains("İndirim Kodu: "))
                {
                    discountCode = rental.Description.Split("İndirim Kodu: ")[1].Substring(0, 8);
                }
                else
                {
                    discountCode = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
                    rental.Description = "İndirim Kodu: " + discountCode + (string.IsNullOrEmpty(rental.Description) ? "" : " | " + rental.Description);
                    _context.Rentals.Update(rental);
                    await _context.SaveChangesAsync();
                }

                await SendConfirmationEmail(rental, discountCode);
            }
            return RedirectToAction("Index");
        }
        private async Task SendConfirmationEmail(Rental rental, string discountCode)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Rentaly Exclusive", ""));
                message.To.Add(new MailboxAddress(rental.NameSurname, rental.Email));
                message.Subject = "Size Özel Bir Ayrıcalık: " + discountCode;

                // Tarih hesaplamaları
                var startDate = DateTime.Now;
                var endDate = startDate.AddYears(1); // Kodun 1 yıl geçerli olduğunu varsayıyoruz

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $@"
        <div style='background-color: #0a0a0b; padding: 50px 0; font-family: ""Inter"", ""Segoe UI"", Helvetica, Arial, sans-serif;'>
            <table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='background-color: #16171a; border-radius: 24px; overflow: hidden; box-shadow: 0 25px 50px rgba(0,0,0,0.5); border: 1px solid #2d2e32;'>
                
                <tr>
                    <td align='center' style='background: #1c1d21; padding: 60px 0;'>
                        <div style='letter-spacing: 8px; color: #ffffff; font-size: 32px; font-weight: 200; margin-bottom: 10px; text-transform: uppercase;'>RENTALY</div>
                        <div style='width: 40px; height: 1px; background-color: #c5a059; margin: 15px 0;'></div>
                        <p style='color: #c5a059; font-size: 11px; text-transform: uppercase; letter-spacing: 3px; font-weight: 600;'>Luxury Car Rental</p>
                    </td>
                </tr>
                
                <tr>
                    <td style='padding: 0 50px 40px 50px;'>
                        <h2 style='color: #ffffff; font-size: 22px; font-weight: 400; text-align: center; margin-bottom: 30px;'>Hoş Geldiniz, <span style='color: #c5a059;'>{rental.NameSurname}</span></h2>
                        
                        <p style='color: #a1a1aa; line-height: 1.8; font-size: 14px; text-align: center; margin-bottom: 40px;'>
                            Rezervasyonunuz onaylanmıştır. Prestijli sürüş deneyiminize ek olarak, bir sonraki kiralamanızda kullanabileceğiniz size özel indirim kodunuzun detayları aşağıdadır.
                        </p>
                        
                        <div style='background: #1e1f24; border: 1px solid #3f3f46; border-radius: 16px; padding: 40px; text-align: center;'>
                            <span style='color: #71717a; font-size: 10px; font-weight: bold; text-transform: uppercase; letter-spacing: 2px;'>AYRICALIKLI İNDİRİM KODU</span>
                            <div style='margin: 20px 0;'>
                                <span style='font-family: ""Courier New"", Courier, monospace; font-size: 40px; color: #ffffff; font-weight: 700; letter-spacing: 10px;'>{discountCode}</span>
                            </div>
                            <div style='display: inline-block; padding: 8px 18px; background-color: rgba(197, 160, 89, 0.1); border-radius: 20px;'>
                                <span style='color: #c5a059; font-size: 11px; font-weight: bold;'>%15 ÖZEL İNDİRİM</span>
                            </div>
                        </div>

                        <table width='100%' style='margin-top: 40px; border-top: 1px solid #2d2e32; padding-top: 30px;'>
                            <tr>
                                <td style='padding-bottom: 12px; color: #71717a; font-size: 12px;'>Rezervasyon Referansı:</td>
                                <td align='right' style='padding-bottom: 12px; color: #e4e4e7; font-weight: 500; font-size: 12px;'>#RT-{rental.RentalId}</td>
                            </tr>
                            <tr>
                                <td style='padding-bottom: 12px; color: #71717a; font-size: 12px;'>Başlangıç Tarihi:</td>
                                <td align='right' style='padding-bottom: 12px; color: #c5a059; font-weight: 500; font-size: 12px;'>{startDate:dd.MM.yyyy}</td>
                            </tr>
                            <tr>
                                <td style='color: #71717a; font-size: 12px;'>Bitiş Tarihi:</td>
                                <td align='right' style='color: #e4e4e7; font-weight: 500; font-size: 12px;'>{endDate:dd.MM.yyyy}</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
                <tr>
                    <td align='center' style='padding: 35px; background-color: #111214; border-top: 1px solid #2d2e32;'>
                        <p style='color: #52525b; font-size: 10px; line-height: 1.6; margin: 0;'>
                            Bu indirim kodu belirtilen tarihler arasında geçerlidir.<br>
                            Sorularınız için Rentaly VIP destek hattıyla iletişime geçebilirsiniz.
                        </p>
                    </td>
                </tr>
            </table>
        </div>";

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("", "");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception) { }
        }
    }
}