using hotel_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_api.Services.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room room);

        Task<Room> Update(int id, Room room);

        Task Delete(int id);

        Task<Room> GetRoom(int id);

        Task<List<Room>> GetRooms();
    }
}
