using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concreate;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.Businesslayer.Abstract;
using Rentaly.Businesslayer.Concreate;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentalyContext>(options =>
    options.UseSqlServer("Server=NýTRO-AN515-57;Database=RentalyDb;TrustServerCertificate=True;Integrated Security=True"));

// DAL
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICarDal, EfCarDal>();
builder.Services.AddScoped<IBranchDal, EfBranchDal>();
builder.Services.AddScoped<IBrandDal, EfBrandDal>();
builder.Services.AddScoped<ICarModelDal, EfCarModelDal>();
builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
builder.Services.AddScoped<IRentalDal, EfRentalDal>();

// Business
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICarService, CarManager>();
builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<ICarModelService, CarModelManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IRentalService, RentalManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();