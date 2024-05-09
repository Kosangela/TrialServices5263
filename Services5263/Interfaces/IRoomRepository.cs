using System.Collections.Generic;
using Services5263;
public interface IRoomRepository
{
    IEnumerable<Room> GetAllRooms();
    Room GetRoomById(int id);
    Room CreateRoom(Room room);
    Room UpdateRoom(Room room);
    void DeleteRoom(int id);
}
