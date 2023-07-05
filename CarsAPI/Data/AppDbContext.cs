using Microsoft.EntityFrameworkCore;
using CarsAPI.Models;

namespace CarsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }
        public DbSet<Cars> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cars>().HasData(new Cars
            {
                Id= 1,
                Brand = "Audi",
                Model = "A7",
                Year = 2020,
                Class = CarClass.Luxury,
                PricePerDay = 50,

            });
            modelBuilder.Entity<Cars>().HasData(new Cars
            {
                Id = 2,
                Brand = "BMW",
                Model = "M3",
                Year = 2021,
                Class = CarClass.Sports,
                PricePerDay = 150,

            });
            modelBuilder.Entity<Cars>().HasData(new Cars
            {
                Id = 3,
                Brand = "Skoda",
                Model = "Octavia",
                Year = 2011,
                Class = CarClass.Economy,
                PricePerDay = 40,

            });
            modelBuilder.Entity<Cars>().HasData(new Cars
            {
                Id = 4,
                Brand = "Mitsubisy",
                Model = "Outlander",
                Year = 2019,
                Class = CarClass.SUV,
                PricePerDay = 80,

            });
        }
    }
    
}
