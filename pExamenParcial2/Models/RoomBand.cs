using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HotelAGC.Models
{
    public class RoomBand
    {
        [Key]
        public int RoomBandID {get; set;}
        [Required]
        [Display(Name="Band Desc")]
        [StringLength(50)]
        public string BandDesc {get; set;}
        
        public ICollection<Room> Rooms {get; set;}      
    }
}