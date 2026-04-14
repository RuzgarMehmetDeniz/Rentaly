using Rentaly.Businesslayer.Abstract;
using Rentaly.Businesslayer.Concreate;
using Rentaly.BusinessLayer.Concrete;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concreate;
using Rentaly.DataAccessLayer.EntityFramework;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// --- DAL (Data Access Layer) Servisleri ---
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICarDal, EfCarDal>();
builder.Services.AddScoped<IBranchDal, EfBranchDal>();
builder.Services.AddScoped<IBrandDal, EfBrandDal>();
builder.Services.AddScoped<ICarModelDal, EfCarModelDal>();
builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
builder.Services.AddScoped<IRentalDal, EfRentalDal>();
builder.Services.AddScoped<IOurFeatureDal, EfOurFeatureDal>();
builder.Services.AddScoped<IAwardDal, EfAwardDal>();
builder.Services.AddScoped<ILatestNewDal, EfLatestNewDal>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<IFAQDal, EfFAQDal>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

// --- Business Layer Servisleri ---
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICarService, CarManager>();
builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<ICarModelService, CarModelManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IRentalService, RentalManager>();
builder.Services.AddScoped<IOurFeatureService, OurFeatureManager>();
builder.Services.AddScoped<IAwardService, AwardManager>();
builder.Services.AddScoped<ILatestNewService, LatestNewManager>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<IFAQService, FAQManager>();
builder.Services.AddScoped<IContactService, ContactManager>();

// Veritabaný ve Diðer Yapýlandýrmalar
builder.Services.AddDbContext<RentalyContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- Middleware Yapýlandýrmasý ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 404 ve Diðer Hata Kodlarý Ýçin Yönlendirme
// Not: Bu satýr StaticFiles'dan önce veya hemen sonra olabilir.
app.UseStatusCodePagesWithReExecute("/ErrorPage/Index/", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Route Yapýlandýrmasý
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();