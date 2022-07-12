using hotel_api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Services.Interfaces
{
    public interface IRoom
    {
        Task<CreateRoomDTO>Create(CreateRoomDTO room);

        Task<PutRoomDTO> Update(int hotelId, int roomNumber, PutRoomDTO room);

        Task Delete(int hotelId, int roomNumber);

        Task<GetRoomDTO> GetRoom(int hotelId, int roomNumber);

        Task<List<GetRoomDTO>> GetRooms(int hotelId);

        Task AddAmenityToRoom(int roomNumber, int hotelId, int amenityId);

        Task RemoveAmenityFromRoom(int roomNumber, int hotelId, int amenityId);

        Task BookRoom(int roomNumber, int hotelId, string CustomerUsername);

        Task RemoveBook(int roomNumber, int hotelId);
    }
}
