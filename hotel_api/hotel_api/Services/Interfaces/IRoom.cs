using hotel_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Services.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room room);

        Task<Room> Update(int hotelId, int roomNumber, Room room);

        Task Delete(int hotelId, int roomNumber);

        Task<Room> GetRoom(int hotelId, int roomNumber);

        Task<List<Room>> GetRooms();
    }
}
