using System;
using System.Collections.Generic;
using System.Linq;
namespace Services5263
{
    public class RoomService : IRoomRepository
    {
        private readonly AppDbContext _dbContext;

        public RoomService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room CreateRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();

            return room;
        }

        public void DeleteRoom(int id)
        {
            var room = _dbContext.Rooms.Find(id);
            if (room == null)
            {
                throw new ArgumentException("Room not found", nameof(id));
            }

            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }

        public Room GetRoomById(int id)
        {
            return _dbContext.Rooms.FirstOrDefault(r => r.RoomId == id);
        }

        public Room UpdateRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            var existingRoom = _dbContext.Rooms.Find(room.RoomId);
            if (existingRoom == null)
            {
                throw new ArgumentException("Room not found", nameof(room));
            }

            existingRoom.Number = room.Number;
            existingRoom.Floor = room.Floor;
            existingRoom.Type = room.Type;

            _dbContext.SaveChanges();

            return existingRoom;
        }
    }
}
