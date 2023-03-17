using HotelProject.Data;
using HotelProject.Data.Services;
using HotelProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsService _service;

        public RoomsController(IRoomsService service)
        { _service = service; }

        public async Task<IActionResult> Index()
        {
            var data = await _service.getAll();
            return View(data);
        }
        
        public async Task<IActionResult> Filter(int id)
        {
            var data = await _service.getById(id);
            return View(data);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PictureUrl, AmountOfBeds, PricePerNight, Name, RoomType")] Room room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }
            await _service.Add(room);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var roomDetails = await _service.getById(id);
            if(roomDetails == null) {
                return View("NotFound");
            }
            return View(roomDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("PictureUrl, AmountOfBeds, PricePerNight, Name, RoomType")] Room room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }
            await _service.Update(id, room);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var roomDetails = await _service.getById(id);
            if (roomDetails == null)
            {
                return View("NotFound");
            }
            return View(roomDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var roomDetails = await _service.getById(id);
            if (roomDetails == null) return View("Notfound");
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
