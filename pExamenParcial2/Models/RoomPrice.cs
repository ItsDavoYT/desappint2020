using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAGC.Models
{
    public class RoomPrice
    {
        [Key]
        public int RoomPriceID {get; set;}
        [Required]
        [Display(Name="Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName="Price")]
        public decimal roomPrice {get; set;}

        public ICollection<Room> Rooms {get; set;}   
    }
}