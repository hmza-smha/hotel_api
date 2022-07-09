using hotel_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hotel_api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Amenity> Amenities { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
                .HasKey(x => new { x.HotelId, x.RoomNumber });

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Async Inn", City = "Amman", Country = "Jordan", Phone = "06-485236", Status = "Available" },
              new Hotel { Id = 2, Name = "Async Inn", City = "Irbid", Country = "Jordan", Phone = "06-485236", Status = "Closed" },
              new Hotel { Id = 3, Name = "Async Inn", City = "Aqaba", Country = "Jordan", Phone = "06-485236", Status = "Available" }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { HotelId = 1,  RoomNumber = 1, Phone = 123},
                new Room { HotelId = 1,  RoomNumber = 2, Phone = 124},
                new Room { HotelId = 1,  RoomNumber = 3, Phone = 125},
                new Room { HotelId = 2, RoomNumber = 1, Phone = 122 },
                new Room { HotelId = 3, RoomNumber = 1, Phone = 124 },
                new Room { HotelId = 3, RoomNumber = 2, Phone = 125 }
            );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "TV"},
                new Amenity { Id = 2, Name = "Cofee Machine" },
                new Amenity { Id = 3, Name = "Ocean View" }
            );


            // any unique string id
            const string ADMIN_ID = "a18be9c0";
            const string ADMIN_ROLE_ID = "ad376a8f";

            // create an Admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "Admin",
                NormalizedName = "Admin"
            });

            // create a User
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "Admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
                SecurityStamp = string.Empty
            });

            // assign that user to the admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

        }
    }
}
