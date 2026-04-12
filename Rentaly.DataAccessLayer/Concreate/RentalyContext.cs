using Microsoft.EntityFrameworkCore;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Concreate
{
    public class RentalyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NıTRO-AN515-57;Database=RentalyDb;TrustServerCertificate=True;Integrated Security=True");
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<OurFeature> OurFeatures { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<LatestNew> LatestNews { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
    }
}