using hotel_api.Data;
using hotel_api.Models;
using hotel_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> GetRoom(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<List<Amenity>> GetRooms()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenity> Update(int id, Amenity amenity)
        {
            Amenity amenityInDb = await _context.Amenities.FindAsync(id);

            if (amenityInDb == null)
                throw new Exception("Amenity Does not exist");

            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.Amenities.FindAsync(id);
        }
    }
}
