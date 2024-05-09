using Services5263;
using System.Collections.Generic;

public interface IGuestRepository
{
    IEnumerable<Guest> GetAllGuests();
    Guest GetGuestById(int id);
    Guest CreateGuest(Guest guest);
    Guest UpdateGuest(Guest guest);
    void DeleteGuest(int id);
}
