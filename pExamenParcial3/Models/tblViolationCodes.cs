using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorPolicy.Models
{
    public class tblViolationCodes{
        [Key]
        [Display(Name="Violation Code")]
        [Column("violation_code")]
        [StringLength(11)]
        public string strViolationCode {get;set;}
        [Display(Name="Violation Description")]
        [Column("violation_description")]
        [StringLength(50)]
        public string strViolationDescription {get;set;}
        [Display(Name="Additional Info")]
        [Column("additional_info")]
        [StringLength(300)]
        public string strAdditionalInfo {get;set;}

        public ICollection<tblLink_ViolationsDrivers> ViolationsDrivers{get;set;}  

    }
    
}