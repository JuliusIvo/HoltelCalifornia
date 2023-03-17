using HotelProject.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRoomsService _roomsService;
        private readonly IUsersService _userService;
        private readonly IOrdersService _ordersService;

        public OrdersController(IRoomsService roomsService, IOrdersService ordersService, IUsersService usersService)
        {
            _ordersService = ordersService;
            _roomsService = roomsService;
            _userService = usersService;   
        }

        public async Task<IActionResult> Index(int id)
        {
            var orders = await _ordersService.getAllByUserId(id);
            return View(orders);
        }

        public async Task<IActionResult> OrderRoom(int roomId, int userId)
        {
            var room = await _roomsService.getById(roomId);
            var user = await _userService.getById(userId);

            if (room != null)
            {
                await _ordersService.Add(new Models.Order { UserId = userId, RoomId = roomId, amount = (
                    room.PricePerNight * (room.DateFrom - room.DateTo).TotalDays)
                    });
                await _roomsService.Update(roomId, room);
            }
            return RedirectToAction(nameof(RoomsController.Index));
        }
    }
}
