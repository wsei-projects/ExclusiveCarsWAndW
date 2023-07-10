using CarsAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IPasswordHasher<User> passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Comment> Comment { get; set; }

        private readonly IPasswordHasher<User> _passwordHasher;

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

            var user = new User()
            {
                Id = 1,
                Email = "user@test.com",
                RoleId = 1,
            };

            var hashedPassword = _passwordHasher.HashPassword(user, "user123!");
            user.PasswordHash = hashedPassword;

            var admin = new User()
            {
                Id = 2,
                Email = "admin@test.com",
                RoleId = 2,
            };

            var hashedPasswordAdmin = _passwordHasher.HashPassword(admin, "admin123!");
            admin.PasswordHash = hashedPasswordAdmin;

            modelBuilder.Entity<User>().HasData(
                user,
                admin
            );

            modelBuilder.Entity<Posts>().HasData(
                new Posts
                {
                    Id = 1,
                    CarId = 1,
                    DateOfCreate = DateTime.Now,
                    Description = "Krótki opiss na bloga",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tincidunt nec tellus eu congue. Integer imperdiet ex non ante ullamcorper feugiat. Quisque aliquet ex ipsum, vitae congue eros lacinia suscipit. Pellentesque arcu diam, efficitur nec ullamcorper nec, facilisis nec velit. Maecenas eu bibendum lectus. Curabitur luctus orci eget eros ullamcorper convallis. Nunc dictum mauris eu diam aliquet fermentum. Fusce iaculis tellus eget odio auctor, at dapibus velit aliquam. Sed sed eros nec velit elementum elementum. Cras sollicitudin mauris lobortis lobortis aliquet.",
                    ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/Jaguar/F-TYPE/7810/1675671305429/front-left-side-47.jpg?tr=w-456",
                    Title = "Title",
                },
                 new Posts
                 {
                     Id = 2,
                     CarId = 2,
                     DateOfCreate = DateTime.Now,
                     Description = "Krótki opiss na bloga",
                     LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tincidunt nec tellus eu congue. Integer imperdiet ex non ante ullamcorper feugiat. Quisque aliquet ex ipsum, vitae congue eros lacinia suscipit. Pellentesque arcu diam, efficitur nec ullamcorper nec, facilisis nec velit. Maecenas eu bibendum lectus. Curabitur luctus orci eget eros ullamcorper convallis. Nunc dictum mauris eu diam aliquet fermentum. Fusce iaculis tellus eget odio auctor, at dapibus velit aliquam. Sed sed eros nec velit elementum elementum. Cras sollicitudin mauris lobortis lobortis aliquet.",
                     ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/Bentley/Continental/7771/1676965640042/front-left-side-47.jpg?tr=w-456",
                     Title = "Title",
                 }

            );

            modelBuilder.Entity<Car>().HasData(new Car
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                ClassId = 1,
                Description = "Spacious and reliable sedan."
            },
             new Car
             {
                 Id = 2,
                 Brand = "BMW",
                 Model = "M3",
                 Year = 2021,
                 ClassId = 4,
                 Description = "Fast exlusive car"
             },
             new Car
             {
                 Id = 3,
                 Brand = "Skoda",
                 Model = "Octavia",
                 Year = 2011,
                 ClassId = 1,
                 Description = "Comfortable and fuel-efficient sedan."
             },
             new Car
             {
                 Id = 4,
                 Brand = "Mitsubisy",
                 Model = "Outlander",
                 Year = 2019,
                 ClassId = 2,
                 Description = "Spacious and versatile SUV."
             },
             new Car
             {
                 Id = 5,
                 Brand = "Skoda",
                 Model = "Fabia",
                 Year = 2022,
                 ClassId = 1,
                 Description = "Spacious and versatile SUV. Lorem ipsum"
             }
             );
        }
    }
}
