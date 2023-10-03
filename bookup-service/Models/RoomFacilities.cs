using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookup_service.Models
{
    public class RoomFacilities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public bool HasTv { get; set; }

        [Required]
        public bool HasFridge { get; set; }

        [Required]
        public bool HasFan { get; set; }

        [Required]
        public bool HasKitchen { get; set; }

        [Required]
        public bool HasBathroom { get; set; }

        // (One-to-one relationship)
        //public Room Room { get; set; }

        public RoomFacilities(bool hasTv, bool hasFridge, bool hasFan, bool hasKitchen, bool hasBathroom)
        {
            HasTv = hasTv;
            HasFridge = hasFridge;
            HasFan = hasFan;
            HasKitchen = hasKitchen;
            HasBathroom = hasBathroom;
        }
    }


}

