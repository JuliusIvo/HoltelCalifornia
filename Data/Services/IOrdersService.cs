using HotelProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Data.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> getAll();

        Task<Order> getById(int id);

        Task Add(Order order);

        Task<IEnumerable<Order>> getAllByUserId(int userId);

        Task Delete(int id);
    }
}
