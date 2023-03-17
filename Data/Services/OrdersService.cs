using HotelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            _context.Orders.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> getAll()
        {
            var result = await _context.Orders.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Order>> getAllByUserId(int userId)
        {
            var results = from order in _context.Orders
                          select order;
            results = results.Where(o => userId == o.UserId);
            
            return await results.ToListAsync();
        }

        public async Task<Order> getById(int id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId== id);
            return result;
        }
    }
}
