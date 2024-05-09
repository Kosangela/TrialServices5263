using Microsoft.AspNetCore.Mvc;
using Services5263;

namespace Services5263.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomService;

        public RoomController(IRoomRepository roomService)
        {
            _roomService = roomService;
        }

        // GET: /Room
        public IActionResult Index()
        {
            var rooms = _roomService.GetAllRooms();
            return View(rooms);
        }

        // GET: /Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomService.CreateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: /Room/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = _roomService.GetRoomById(id.Value);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: /Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _roomService.UpdateRoom(room);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: /Room/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = _roomService.GetRoomById(id.Value);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: /Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            _roomService.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
