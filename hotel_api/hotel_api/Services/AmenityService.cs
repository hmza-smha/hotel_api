using hotel_api.Data;
using hotel_api.DTOs;
using hotel_api.Models;
using hotel_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_api.Services
{
    public class AmenityService : IAmenity
    {
        private ApplicationDbContext _context;

        public AmenityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateAmenityDTO> Create(CreateAmenityDTO amenity)
        {
            if (await _context.Amenities.AnyAsync(x => x.Name == amenity.Name))
                throw new Exception("Simmilar Amenity Exists!");

            Amenity newAmenity = new Amenity
            {
                Name = amenity.Name
            };

            _context.Entry(newAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            if (!IsExist(id))
                throw new Exception("Amenity Does not Exist!");

            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<GetAmenityDTO> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities
                .Where(a => a.Id == id)
                .Include(x=>x.RoomAmenities)
                .ThenInclude(x => x.Room)
                .ThenInclude(x => x.Customer)
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Room)
                .ThenInclude(x => x.Hotel)
                .FirstOrDefaultAsync();

            return new GetAmenityDTO
            {
                Id = id,
                Name = amenity.Name,
                Rooms = amenity.RoomAmenities
                    .Select(x => new GetRoomDTO
                    {
                        RoomNumber = x.RoomNumber,
                        HotelName = x.Room.Hotel.Name,
                        Customer = x.Room.CustomerUsername,
                        Phone = x.Room.Phone,
                        Price = x.Room.Price,
                        Rate = x.Room.Rate,
                        Status = x.Room.Status,
                        Amenities = x.Room.RoomAmenities
                        .Select(x => new GetAmenityDTO
                        {
                            Id = x.AmenityId,
                            Name = x.Amenity.Name
                        }).ToList()

                    }).ToList()
            };
        }

        public async Task<List<GetAmenityDTO>> GetAmenities()
        {
            return await _context.Amenities
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Room)
                .ThenInclude(x => x.Customer)
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Room)
                .ThenInclude(x => x.Hotel)
                .Select(x => new GetAmenityDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Rooms = x.RoomAmenities
                    .Select(x => new GetRoomDTO
                    {
                        RoomNumber = x.RoomNumber,
                        HotelName = x.Room.Hotel.Name,
                        Customer = x.Room.CustomerUsername,
                        Phone = x.Room.Phone,
                        Price = x.Room.Price,
                        Rate = x.Room.Rate,
                        Status = x.Room.Status,
                        Amenities = x.Room.RoomAmenities
                        .Select(x => new GetAmenityDTO
                        {
                            Id = x.AmenityId,
                            Name = x.Amenity.Name
                        }).ToList()

                    }).ToList()

                }).ToListAsync();
        }

        public async Task<CreateAmenityDTO> Update(int id, CreateAmenityDTO amenity)
        {
            if (!IsExist(id))
                throw new Exception("Amenity Does not Exist!");

            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return amenity;
        }

        private bool IsExist(int id)
        {
            return _context.Amenities.Any(x => x.Id == id);
        }

        public async Task<List<GetRoomDTO>> GetRooms(int amenityId, int hotelId)
        {
            var rooms = await _context.RoomAmenities
                .Include(x => x.Room)
                .ThenInclude(x => x.Customer)
                .Include(x => x.Room)
                .ThenInclude(x => x.Hotel)
                .Include(x => x.Amenity)
                .Where(x => x.AmenityId == amenityId && x.HotelId == hotelId)
                .Select(x => new GetRoomDTO
                {
                    RoomNumber = x.RoomNumber,
                    HotelName = x.Room.Hotel.Name,
                    //Customer = x.Room.Customer.Username,
                    Customer = x.Room.CustomerUsername,
                    Phone = x.Room.Phone,
                    Price = x.Room.Price,
                    Rate = x.Room.Rate,
                    Status = x.Room.Status,
                    Amenities = x.Room.RoomAmenities
                        .Select(x => new GetAmenityDTO
                        {
                            Id = x.AmenityId,
                            Name = x.Amenity.Name
                        }).ToList(),

                }).ToListAsync();

            return rooms;
        }
    }
}
