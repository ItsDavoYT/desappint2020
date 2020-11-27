using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MotorPolicy.Models
{
    public class tblInsuranceGroups{
        [Key]
        [Display(Name="Insurance Group")]
        [Column("insurance_group")]
        public int lngInsuranceGroup {get;set;}
        [Display(Name="Insurance Group Details")]
        [Column("insurance_group_details")]
        [StringLength(300)]
        public string memInsuranceGroupDetails{get;set;}
        
        public ICollection<tblVehicles> Vehicles{get;set;}
    }
    
}

