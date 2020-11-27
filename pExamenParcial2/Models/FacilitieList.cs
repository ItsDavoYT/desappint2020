using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelAGC.Models
{
    public class FacilitieList
    {
        [Key]
        public int FacilityID {get; set;}
        [Required]
        [Display(Name="Facility Desc")]
        [StringLength(250)]
        public string FacilityDesc{get; set;}

        public ICollection<RoomFacilities> RoomsFacilities {get; set;}  
    }
}    