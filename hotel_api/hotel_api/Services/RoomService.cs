using hotel_api.Data;
using hotel_api.Models;
using hotel_api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using hotel_api.DTOs;

namespace hotel_api.Services
{
    public class RoomService : IRoom
    {
        private ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateRoomDTO> Create(CreateRoomDTO room)
        {
            if (IsExist(room.RoomNumber, room.HotelID))
                    throw new Exception("Simmilar Room Exists!");

            Room new_room = new Room
            {
                HotelId = room.HotelID,
                RoomNumber = room.RoomNumber,
                Phone = room.Phone,
                Status = room.Status,
                Rate = room.Rate,
                Price = room.Price
            };

            _context.Entry(new_room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int roomNumber, int hotelId)
        {
            if (!IsExist(roomNumber, hotelId))
                throw new Exception("Room Does not Exists!");

            Room room = await _context.Rooms.FindAsync(hotelId, roomNumber);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<GetRoomDTO> GetRoom(int roomNumber, int hotelId)
        {
            // PKs should be ordered as in the table
            var room = await _context.Rooms
                .Where(x => x.HotelId == hotelId && x.RoomNumber == roomNumber)
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .Include(x => x.Customer)
                .Include(x => x.Hotel)
                .SingleOrDefaultAsync();

            if (room == null)
                throw new Exception("Room Does not Exists!");

            var roomDTO = new GetRoomDTO
            {
                RoomNumber = room.RoomNumber,
                HotelName = room.Hotel.Name,
                Phone = room.Phone,
                Price = room.Price,
                Rate = room.Rate,
                Status = room.Status,
                Amenities = room.RoomAmenities
                    .Select(x => new GetAmenityDTO
                    {
                        Id = x.AmenityId,
                        Name = x.Amenity.Name,
                    }).ToList()
            };

            if (room.Customer != null)
                roomDTO.Customer = room.Customer.Username;

            return roomDTO;
        }

        public async Task<List<GetRoomDTO>> GetRooms(int hotelId)
        {
            return await _context.Rooms.Where(x => x.HotelId == hotelId)
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .Include(x=>x.Customer)
                .Include(x => x.Hotel)
                .Select(x => new GetRoomDTO
                {
                    RoomNumber = x.RoomNumber,
                    HotelName = x.Hotel.Name,
                    Customer = x.Customer.Username,
                    Phone = x.Phone,
                    Price = x.Price,
                    Rate = x.Rate,
                    Status = x.Status,
                    Amenities = x.RoomAmenities
                    .Select(x => new GetAmenityDTO
                    {
                        Id = x.AmenityId,
                        Name = x.Amenity.Name,
                    }).ToList()

                }).ToListAsync();
        }

        public async Task<PutRoomDTO> Update(int roomNumber, int hotelId, PutRoomDTO room)
        {
            var roomInDb = await _context.Rooms
                .Where(x => x.RoomNumber == roomNumber && x.HotelId == hotelId)
                .SingleOrDefaultAsync();

            if (roomInDb == null)
                throw new Exception("Room Does not Exist!");

            roomInDb.RoomNumber = room.RoomNumber;
            roomInDb.Phone = room.Phone;
            roomInDb.Price = room.Price;
            roomInDb.Rate = room.Rate;
            roomInDb.Status = room.Status;

            _context.Entry(roomInDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task AddAmenityToRoom(int roomNumber, int hotelId, int amenityId)
        {
            if (!IsExist(roomNumber, hotelId))
                throw new Exception("Room Does not Exist!");

            if (!_context.Amenities.Any(x => x.Id == amenityId))
                throw new Exception("Amenity Does not Exist!");

            if (_context.RoomAmenities.Any(x => x.RoomNumber == roomNumber && x.HotelId == hotelId && x.AmenityId == amenityId))
                throw new Exception("Similar Amenity Exists!");

            var roomAmenity = new RoomAmenity
            {
                HotelId = hotelId,
                RoomNumber = roomNumber,
                AmenityId = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int hotelId, int roomNumber,  int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities
                .Where(x => x.HotelId == hotelId && x.RoomNumber == roomNumber && x.AmenityId == amenityId)
                .FirstOrDefaultAsync();

            if (roomAmenity == null)
                throw new Exception("Amenity Does not Exists!");

            _context.Entry(roomAmenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task BookRoom(int roomNumber, int hotelId, string CustomerUsername)
        {
            var room = await _context.Rooms.FindAsync(hotelId, roomNumber);

            if (room == null)
            {
                throw new Exception("Room Does not Exist!");
            }
            else
            {
                room.CustomerUsername = CustomerUsername;
                room.Status = "Booked By " + CustomerUsername;
                _context.Entry(room).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveBook(int roomNumber, int hotelId)
        {
            var room = await _context.Rooms.FindAsync(hotelId, roomNumber);

            if (room == null)
            {
                throw new Exception("Room Does not Exist!");
            }
            else
            {
                room.CustomerUsername = null;
                room.Status = "Available";
                _context.Entry(room).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        private bool IsExist(int roomNumber, int hotelId)
        {
            return _context.Rooms.Any(x => x.HotelId == hotelId && x.RoomNumber == roomNumber);
        }        
    }
}
