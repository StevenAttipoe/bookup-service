using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookup_service.Models
{
    public class Room
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public RoomType type { get; set; }

        //[Required]
        //public long RoomFacilitiesId { get; set; }

        [Required]
        public int floor { get; set; }

        [Required]
        public bool isBooked { get; set; }

        //public RoomFacilities Facilities { get; set; }

        public Room(long id, RoomType type, int floor, bool isBooked)
        {
            this.Id = id;
            this.type = type;
            this.floor = floor;
            this.isBooked = isBooked;
        }
    }
}

