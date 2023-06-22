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

        [Required]
        public bool hasTv { get; set; }

        [Required]
        public bool hasFridge { get; set; }

        [Required]
        public bool hasFan { get; set; }

        [Required]
        public bool hasKitchen { get; set; }

        [Required]
        public bool hasBathroom { get; set; }


        public Room(long id, RoomType type, bool hasTv, bool hasFridge, bool hasFan, bool hasKitchen, bool hasBathroom)
        {
            Id = id;
            this.type = type;
            this.hasTv = hasTv;
            this.hasFridge = hasFridge;
            this.hasFan = hasFan;
            this.hasKitchen = hasKitchen;
            this.hasBathroom = hasBathroom;
        }
    }
}

