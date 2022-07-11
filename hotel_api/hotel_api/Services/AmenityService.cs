using hotel_api.Data;
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

        public async Task<Amenity> Create(Amenity amenity)
        {
            if (IsExist(amenity.Id))
                throw new Exception("Simmilar Amenity Exists!");

            _context.Entry(amenity).State = EntityState.Added;
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

        public async Task<Amenity> GetAmenity(int id)
        {
            return await _context.Amenities
                .Where(a => a.Id == id)
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Room)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Room)
                .ToListAsync();
        }

        public async Task<Amenity> Update(int id, Amenity amenity)
        {
            if (!IsExist(amenity.Id))
                throw new Exception("Amenity Does not Exist!");

            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return amenity;
        }

        private bool IsExist(int id)
        {
            return _context.Amenities.Any(x => x.Id == id);
        }
    }
}
