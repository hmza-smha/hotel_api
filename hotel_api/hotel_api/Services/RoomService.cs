using hotel_api.Data;
using hotel_api.Models;
using hotel_api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

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
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> Update(int id, Room room)
        {
            Room roomInDb = await _context.Rooms.FindAsync(id);

            if (roomInDb == null)
                throw new Exception("Room Does not exist");

            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.Rooms.FindAsync(id);
        }
    }
}
