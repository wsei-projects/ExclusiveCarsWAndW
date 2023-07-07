using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
               .Property(u => u.Name)
               .IsRequired();

            modelBuilder.Entity<CarClass>().HasData(
                new CarClass { Id = 1, Name = "Economy" },
                new CarClass { Id = 2, Name = "SUV" },
                new CarClass { Id = 3, Name = "Luxury" },
                new CarClass { Id = 4, Name = "Sports" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "User" },
                new Role { Id = 2, Name = "Admin" }
            );

            modelBuilder.Entity<Car>().HasData(new Car
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                ClassId = 1,
                PricePerDay = 50.99m,
                ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/Jaguar/F-TYPE/7810/1675671305429/front-left-side-47.jpg?tr=w-456",
                Description = "Spacious and reliable sedan."
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                Id = 2,
                Brand = "BMW",
                Model = "M3",
                Year = 2021,
                ClassId = 4,
                PricePerDay = 150.00m,
                ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/BMW/M2/10257/1686225075596/front-left-side-47.jpg?tr=w-456",
                Description = "Fast exlusive car"
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                Id = 3,
                Brand = "Skoda",
                Model = "Octavia",
                Year = 2011,
                ClassId = 1,
                PricePerDay = 40,
                ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/Bentley/Continental/7771/1676965640042/front-left-side-47.jpg?tr=w-456",
                Description = "Comfortable and fuel-efficient sedan."
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                Id = 4,
                Brand = "Mitsubisy",
                Model = "Outlander",
                Year = 2019,
                ClassId = 2,
                PricePerDay = 80,
                ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/BMW/Z4/10183/1685003672330/front-left-side-47.jpg?impolicy=resize&imwidth=420",
                Description = "Spacious and versatile SUV."
            });

            modelBuilder.Entity<Car>().HasData(new Car
            {
                Id = 5,
                Brand = "Skoda",
                Model = "Fabia",
                Year = 2022,
                ClassId = 1,
                PricePerDay = 50,
                ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/Lamborghini/Huracan-EVO/6729/1678692048287/front-left-side-47.jpg?tr=w-456",
                Description = "Spacious and versatile SUV. Lorem ipsum"
            });
        }
    }
}
