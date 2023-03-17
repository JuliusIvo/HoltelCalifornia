using HotelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> getAll()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task<User> getById(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return result;
        }

        public async Task<User> getByEmail(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return result;
        }

        public async Task<User> Update(int Id, User newUser)
        {
            _context.Update(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
