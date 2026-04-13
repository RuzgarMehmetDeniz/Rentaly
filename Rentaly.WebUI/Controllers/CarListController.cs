using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concreate;
using System;

public class CarListController : Controller
{
    private readonly RentalyContext _context;

    public CarListController(RentalyContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? pickUpBranchId, int? dropOffBranchId, int? vtype)
    {
        var cars = _context.Cars
            .Include(x => x.Branch)
            .Include(x => x.Brand)
            .Include(x => x.CarModel)
            .AsQueryable();

        if (pickUpBranchId.HasValue)
        {
            cars = cars.Where(x => x.BranchId == pickUpBranchId.Value);
        }

        if (vtype.HasValue)
        {
            cars = cars.Where(x => x.CategoryId == vtype.Value);
        }

        return View(cars.ToList());
    }
}