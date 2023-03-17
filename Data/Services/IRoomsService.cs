using HotelProject.Models;

namespace HotelProject.Data.Services
{
    public interface IRoomsService
    {
        Task<IEnumerable<Room>> getAll();

        Task<Room> getById(int id);

        Task Add(Room room);
        Task<Room> Update(int Id, Room newRoom);

        Task Delete(int id);
    }
}
