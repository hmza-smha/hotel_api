using hotel_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Services.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> Create(Amenity amenity);

        Task<Amenity> Update(int id, Amenity amenity);

        Task Delete(int id);

        Task<Amenity> GetAmenity(int id);

        Task<List<Amenity>> GetAmenities();
    }
}
