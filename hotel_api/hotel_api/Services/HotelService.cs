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
    public class HotelService : IHotel
    {
        private ApplicationDbContext _context;

        public HotelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateHotelDTO> Create(CreateHotelDTO hotel)
        {
            if (await _context.Hotels.AnyAsync(x => x.Name == hotel.Name))
                throw new Exception("Simmilar Hotel Exists!");

            var new_hotel = new Hotel
            {
                Name = hotel.Name,
                City = hotel.City,
                Country = hotel.Country,
                Phone = hotel.Phone,
                Status = hotel.Status,
            };

            _context.Entry(new_hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            if (!IsExist(id))
                throw new Exception("Hotel Does not exist!");

            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetRoomDTO>> GetAvailable(int id)
        {
            var roomList = await _context.Rooms
                .Where(x => x.HotelId == id && x.Status == "Available")
                .Include(x => x.Hotel)
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .Select(x => new GetRoomDTO
                {
                    RoomNumber = x.RoomNumber,
                    HotelName = x.Hotel.Name,
                    Customer = x.CustomerUsername,
                    Phone = x.Phone,
                    Price = x.Price,
                    Rate = x.Rate,
                    Status = x.Status,
                    Amenities = x.RoomAmenities
                        .Select(x => new GetAmenityDTO
                        {
                            Id = x.AmenityId,
                            Name = x.Amenity.Name
                        }).ToList(),

                }).ToListAsync();

            return roomList;
        }

        public async Task<GetHotelDTO> GetHotel(int id)
        {
            var hotel = await _context.Hotels
                .Include(x => x.Rooms)
                .ThenInclude(x => x.Customer)
                .Include(x => x.Rooms)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (hotel == null)
                throw new Exception("Hotel Does not Exists!");

            return new GetHotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                City = hotel.City,
                Country = hotel.Country,
                Phone = hotel.Phone,
                Status = hotel.Status,
                Rooms = hotel.Rooms
                    .Select(x => new GetRoomDTO
                    {
                        HotelName = hotel.Name,
                        RoomNumber = x.RoomNumber,
                        Rate = x.Rate,
                        Status = x.Status,
                        Phone = x.Phone,
                        Customer = x.CustomerUsername,
                        Price = x.Price,
                        Amenities = x.RoomAmenities
                            .Select(x => new GetAmenityDTO
                            {
                                Id = x.Amenity.Id,
                                Name = x.Amenity.Name
                            }).ToList()
                    }).ToList()
            };
        }

        public async Task<List<GetHotelDTO>> GetHotels()
        {
            return await _context.Hotels
                 .Include(x => x.Rooms)
                 .ThenInclude(x => x.Customer)
                 .Include(x => x.Rooms)
                 .ThenInclude(x => x.RoomAmenities)
                 .ThenInclude(x => x.Amenity)
                 .Select(x => new GetHotelDTO
                 {
                     Id = x.Id,
                    Name = x.Name,
                    City = x.City,
                    Country = x.Country,
                    Phone = x.Phone,
                    Status = x.Status,
                    Rooms = x.Rooms
                        .Select(x => new GetRoomDTO
                        {
                            HotelName = x.Hotel.Name,
                            RoomNumber = x.RoomNumber,
                            Rate = x.Rate,
                            Status = x.Status,
                            Phone = x.Phone,
                            Customer = x.CustomerUsername,
                            Price = x.Price,
                            Amenities = x.RoomAmenities
                                .Select(x => new GetAmenityDTO
                                {
                                    Id = x.Amenity.Id,
                                    Name = x.Amenity.Name
                                }).ToList()
                        }).ToList()
                 }).ToListAsync();

        }

        public async Task<CreateHotelDTO> Update(int id, CreateHotelDTO hotel)
        {
            if (!IsExist(id))
                throw new Exception("Hotel Does not exist!");

            var hotelInDB = await _context.Hotels.FindAsync(id);

            hotelInDB.Name = hotel.Name;
            hotelInDB.Country = hotel.Country;
            hotelInDB.City = hotel.City;
            hotelInDB.Phone = hotel.Phone;
            hotelInDB.Status = hotel.Status;

            _context.Entry(hotelInDB).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotel;
        }

        private bool IsExist(int id)
        {
            return _context.Hotels.Any(x => x.Id == id);
        }
    }
}
