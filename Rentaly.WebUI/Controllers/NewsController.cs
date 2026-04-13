using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concreate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class NewsController : Controller
    {
        private readonly RentalyContext _context;

        public NewsController(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 7;

            // Toplam haber sayısını alalım (Sayfa sayısını hesaplamak için)
            var totalNewsCount = await _context.LatestNews.CountAsync();

            var values = await _context.LatestNews
                .OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // View tarafında sayfalama butonlarını oluşturmak için gerekli bilgileri taşıyoruz
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalNewsCount / pageSize);

            return View(values);
        }
        public async Task<IActionResult> Details(int id)
        {
            var news = await _context.LatestNews.FindAsync(id);
            return View(news);
        }
    }
}