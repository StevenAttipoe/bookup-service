using System;
using bookup_service.Interfaces;
using bookup_service.Models;
using Microsoft.EntityFrameworkCore;

namespace bookup_service.Services
{
	public class RoomService: IRoomService, IService
	{

        private readonly ApplicationDbContext applicationDbContext;

        public RoomService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void CreateRoom(Room room)
        {
            applicationDbContext.Set<Room>().Add(room);
            applicationDbContext.SaveChanges();
        }

        public List<Room> GetRooms()
        {
            return applicationDbContext.Set<Room>().ToList();
        }
    }
}

