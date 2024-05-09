using System;
using System.Collections.Generic;
using System.Linq;

namespace Services5263
{
    public class GuestService : IGuestRepository
    {
        private readonly AppDbContext _dbContext;

        public GuestService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guest CreateGuest(Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentNullException(nameof(guest));
            }

            _dbContext.Guests.Add(guest);
            _dbContext.SaveChanges();

            return guest;
        }

        public void DeleteGuest(int id)
        {
            var guest = _dbContext.Guests.Find(id);
            if (guest == null)
            {
                throw new ArgumentException("Guest not found", nameof(id));
            }

            _dbContext.Guests.Remove(guest);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Guest> GetAllGuests()
        {
            return _dbContext.Guests.ToList();
        }

        public Guest GetGuestById(int id)
        {
            return _dbContext.Guests.FirstOrDefault(g => g.GuestId == id);
        }

        public Guest UpdateGuest(Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentNullException(nameof(guest));
            }

            var existingGuest = _dbContext.Guests.Find(guest.GuestId);
            if (existingGuest == null)
            {
                throw new ArgumentException("Guest not found", nameof(guest));
            }

            existingGuest.FirstName = guest.FirstName;
            existingGuest.LastName = guest.LastName;
            existingGuest.DOB = guest.DOB;
            existingGuest.Address = guest.Address;
            existingGuest.Nationality = guest.Nationality;
            existingGuest.CheckInDate = guest.CheckInDate;
            existingGuest.CheckOutDate = guest.CheckOutDate;

            _dbContext.SaveChanges();

            return existingGuest;
        }
    }
}
