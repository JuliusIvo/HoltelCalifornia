using HotelProject.Models;
using System.Collections;

namespace HotelProject.Data.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> getAll();

        Task<User> getById(int id);

        Task Add(User room);
        Task<User> Update(int Id, User newUser);

        Task Delete(int id);
    }
}
