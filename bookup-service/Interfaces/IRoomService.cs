using System;
using bookup_service.Models;

namespace bookup_service.Interfaces
{
	public interface IRoomService
	{
        public List<Room> GetRooms();

        public void CreateRoom(Room room);

    }
}

