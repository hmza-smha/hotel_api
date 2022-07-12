using hotel_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hotel_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<RoomAmenity> RoomAmenities { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasKey(
                x => new { x.HotelId, x.RoomNumber }
            );

            modelBuilder.Entity<RoomAmenity>().HasKey(
                x => new { x.RoomNumber, x.AmenityId, x.HotelId }
            );

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

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

            modelBuilder.Entity<RoomAmenity>().HasData(
                new RoomAmenity { HotelId = 1, RoomNumber = 1, AmenityId = 1 },
                new RoomAmenity { HotelId = 1, RoomNumber = 1, AmenityId = 2 },
                new RoomAmenity { HotelId = 1, RoomNumber = 1, AmenityId = 3 },
                new RoomAmenity { HotelId = 2, RoomNumber = 1, AmenityId = 1 },
                new RoomAmenity { HotelId = 2, RoomNumber = 1, AmenityId = 2 },
                new RoomAmenity { HotelId = 3, RoomNumber = 1, AmenityId = 1 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Username = "Admin", Password = "123", Phone = "0786371281", Role = "Admin" },
                new User { Username = "HamZa", Password = "123", Phone = "0786371281", Role = "Customer" }
            );

        }
    }
}
