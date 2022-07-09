using hotel_api.Data;
using hotel_api.Models;
using hotel_api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace hotel_api.Services
{
    public class HotelService : IHotel
    {
        private ApplicationDbContext _context;

        public HotelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> Update(int id, Hotel hotel)
        {
            Hotel hotelInDb = await _context.Hotels.FindAsync(id);

            if (hotelInDb == null)
                throw new Exception("Hotel Does not exist");

            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.Hotels.FindAsync(id);
        }
    }
}
