using HotelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data.Services
{
    public class RoomsService : IRoomsService
    {
        private readonly AppDbContext _context;

        public RoomsService(AppDbContext context)
        {
           _context = context;
        }

        public async Task Add(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);
            _context.Rooms.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> getAll()
        {
            var result = await _context.Rooms.ToListAsync();
            return result;
        }

        public async Task<Room> getById(int id)
        {
            var result = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId== id);
            return result;
        }

        public async Task<Room> Update(int Id, Room newRoom)
        {
            _context.Update(newRoom);
            await _context.SaveChangesAsync();
            return newRoom;
        }
    }

}
