using System;
using bookup_service.Models;

namespace bookup_service.Interfaces
{
	public interface IRoomService
	{
        public void CreateRoom(Room room);

        public bool BookRoom(int room);

        public bool ShowInterestInRoom(int id);

        public List<Room> GetRooms();

    }
}

