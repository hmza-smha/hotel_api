using hotel_api.DTOs;
using hotel_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Services.Interfaces
{
    public interface IHotel
    {
        Task<CreateHotelDTO> Create(CreateHotelDTO hotel);

        Task<CreateHotelDTO> Update(int id, CreateHotelDTO hotel);

        Task Delete(int id);

        Task<List<GetHotelDTO>> GetHotels();

        Task<GetHotelDTO> GetHotel(int id);

        Task<List<GetRoomDTO>> GetAvailable(int id);
    }
}
