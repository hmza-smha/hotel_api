using hotel_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Services.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);

        Task<Hotel> Update(int id, Hotel hotel);

        Task Delete(int id);

        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotel(int id);

        Task<List<Room>> GetAvailable(int id);
    }
}
