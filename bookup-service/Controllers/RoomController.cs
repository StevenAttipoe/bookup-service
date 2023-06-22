using System;
using bookup_service.Interfaces;
using bookup_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookup_service.Controllers
{
    [Route("api/v1/room")]
    [ApiController]
    public class RoomController: Controller
    {

        private readonly IRoomService RoomService;

        public RoomController(IRoomService RoomService)
        {
            this.RoomService = RoomService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(204)]
        public ActionResult<string> CreateRoom([FromBody] Room room)
        {
            RoomService.CreateRoom(room);
            return "Successfully created";
        }

        [HttpGet]
        [Route("get/all")]
        [ProducesResponseType(200)]
        public ActionResult<List<Room>> GetRoomsListings()
        {
            return RoomService.GetRooms();
        }

    }
}

