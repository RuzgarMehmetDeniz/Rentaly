using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concreate;
using System.Linq;

public class CarListController : Controller
{
    private readonly RentalyContext _context;

    public CarListController(RentalyContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? vtype, int? brandId, int? seat, decimal? minPrice, decimal? maxPrice, int? pickUpBranchId, int? dropOffBranchId)
    {
        // 1. Temel sorgu ve İlişkili Tablolar (Eager Loading)
        var query = _context.Cars
            .Include(x => x.Branch)
            .Include(x => x.Brand)
            .Include(x => x.CarModel)
            .Include(x => x.Category)
            .AsQueryable();

        // 2. Kategori Filtresi (vtype)
        if (vtype.HasValue)
        {
            query = query.Where(x => x.CategoryId == vtype.Value);
        }

        // 3. Marka Filtresi (brandId)
        if (brandId.HasValue)
        {
            query = query.Where(x => x.BrandId == brandId.Value);
        }

        // 4. Koltuk Sayısı Filtresi (seat)
        if (seat.HasValue)
        {
            query = query.Where(x => x.SeatCount == seat.Value);
        }

        // 5. Fiyat Aralığı Filtresi (minPrice & maxPrice)
        if (minPrice.HasValue && maxPrice.HasValue)
        {
            // Aracın DailyPrice alanı sizin veritabanınızdaki fiyat sütunudur
            query = query.Where(x => x.DailyPrice >= minPrice.Value && x.DailyPrice <= maxPrice.Value);
        }

        // 6. Şube Filtresi (Pick Up)
        if (pickUpBranchId.HasValue)
        {
            query = query.Where(x => x.BranchId == pickUpBranchId.Value);
        }

        // Sonuçları listele ve View'a gönder
        var values = query.ToList();
        return View(values);
    }
}