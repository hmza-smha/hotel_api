﻿using hotel_api.Data;
using hotel_api.Models;
using hotel_api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace hotel_api.Services
{
    public class RoomService : IRoom
    {
        private ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(Room room)
        {
            if (IsExist(room.RoomNumber, room.HotelId))
                    throw new Exception("Simmilar Room Exists!");

            _context.Entry(room).State = EntityState.Added;
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

        public async Task<Room> GetRoom(int roomNumber, int hotelId)
        {
            // PKs should be ordered as in the table
            return await _context.Rooms.FindAsync(hotelId, roomNumber);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> Update(int roomNumber, int hotelId, Room room)
        {
            if (!IsExist(roomNumber, hotelId))
                throw new Exception("Room Does not Exist!");

            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.Rooms.FindAsync(hotelId, roomNumber);
        }

        private bool IsExist(int roomNumber, int hotelId)
        {
            return _context.Rooms.Any(x => x.HotelId == hotelId && x.RoomNumber == roomNumber);
        }
    }
}
