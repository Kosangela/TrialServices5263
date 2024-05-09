using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Services5263;

namespace Services5263.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestRepository _guestService;

        public GuestController(IGuestRepository guestService)
        {
            _guestService = guestService;
        }

        // GET: /Guest
        public IActionResult Index()
        {
            var guests = _guestService.GetAllGuests();
            return View(guests);
        }

        // GET: /Guest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Guest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _guestService.CreateGuest(guest);
                return RedirectToAction(nameof(Index));
            }
            return View(guest);
        }

        // GET: /Guest/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = _guestService.GetGuestById(id.Value);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: /Guest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Guest guest)
        {
            if (id != guest.GuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _guestService.UpdateGuest(guest);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(guest);
        }

        // GET: /Guest/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = _guestService.GetGuestById(id.Value);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: /Guest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var guest = _guestService.GetGuestById(id);
            if (guest == null)
            {
                return NotFound();
            }

            _guestService.DeleteGuest(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
