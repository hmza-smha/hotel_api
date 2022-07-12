using hotel_api.DTOs;
using hotel_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Services.Interfaces
{
    public interface IAmenity
    {
        Task<CreateAmenityDTO> Create(CreateAmenityDTO amenity);

        Task<CreateAmenityDTO> Update(int id, CreateAmenityDTO amenity);

        Task Delete(int id);

        Task<GetAmenityDTO> GetAmenity(int id);

        Task<List<GetAmenityDTO>> GetAmenities();

        Task<List<GetRoomDTO>> GetRooms(int amenityId, int hotelId);
    }
}
