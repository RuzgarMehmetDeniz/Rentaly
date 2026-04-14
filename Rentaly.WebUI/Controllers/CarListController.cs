using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concreate;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

public class CarListController : Controller
{
    private readonly RentalyContext _context;

    public CarListController(RentalyContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? vtype, int? brandId, int? seat, decimal? minPrice, decimal? maxPrice, int? pickUpBranchId, int? dropOffBranchId, int? page)
    {
        // 1. Temel sorgu (AsQueryable ile sorgu henüz veritabanına gitmez)
        var query = _context.Cars
            .Include(x => x.Branch)
            .Include(x => x.Brand)
            .Include(x => x.CarModel)
            .Include(x => x.Category)
            .Where(x => x.IsAvailable == true)
            .AsQueryable();

        // 2. Filtrelemeler (Senin mevcut mantığın)
        if (vtype.HasValue) query = query.Where(x => x.CategoryId == vtype.Value);
        if (brandId.HasValue) query = query.Where(x => x.BrandId == brandId.Value);
        if (seat.HasValue) query = query.Where(x => x.SeatCount == seat.Value);
        if (minPrice.HasValue && maxPrice.HasValue)
            query = query.Where(x => x.DailyPrice >= minPrice.Value && x.DailyPrice <= maxPrice.Value);
        if (pickUpBranchId.HasValue) query = query.Where(x => x.BranchId == pickUpBranchId.Value);

        // 3. Sayfalama Ayarları
        int pageSize = 12;
        int pageNumber = page ?? 1;

        // ÖNEMLİ: X.PagedList kullanırken sorgunun mutlaka bir sıralamaya (OrderBy) sahip olması gerekir.
        var values = query.OrderByDescending(x => x.CarId).ToPagedList(pageNumber, pageSize);

        return View(values);
    }
    public async Task<IActionResult> CarDetail(int id)
    {
        // Veritabanından arabayı ve bağlı olduğu tabloları çekiyoruz
        var car = await _context.Cars
            .Include(x => x.Brand)
            .Include(x => x.CarModel)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.CarId == id);

        ViewBag.Branches = await _context.Branches.ToListAsync();

        return View(car);
    }

}