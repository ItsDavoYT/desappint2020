using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MotorPolicy.Models
{
    public class tblDrivers{
        [Key]
        public int lngDriveID {get;set;}
        [Display(Name="Titulo")]
        [Column("title")]
        public string strTitle {get;set;}
        [Required]
        [Display(Name="First Name")]
        [StringLength(50)]
        [Column("first_name")]
        public string strFirstName {get;set;}
        [StringLength(300)]
        [Display(Name="Last Name")]
        [Column("last_name")]
        public string strLastName {get;set;}
        [DataType(DataType.Date)]
        [Display(Name="DOB")]
        [Column("dob")]
        public DateTime dteDOB {get;set;}
        [DataType(DataType.Date)]
        [Display(Name="Date Licensed")]
        [Column("date_licensed")]
        public DateTime dteDateLicensed {get;set;}
        [StringLength(300)]
        [Display(Name="License Reference")]
        [Column("license_reference")]
        public string strLicenseReference {get;set;}
        [StringLength(300)]
        [Display(Name="Ad. Street")]
        [Column("address_street")]
        public string strAddress_Street {get;set;}
        [StringLength(300)]
        [Display(Name="Ad. Town Village")]
        [Column("address_townvillage")]
        public string strAddress_TownVillage {get;set;}
        [StringLength(300)]
        [Display(Name="Ad. Country")]
        [Column("address_country")]
        public string strAddress_Country {get;set;}
        [StringLength(10)]
        [Display(Name="Ad. PC")]
        [Column("address_postcode")]
        public string strAddress_PostCode {get;set;}
        [StringLength(20)]
        [Display(Name="Day Phone")]
        [Column("contact_dphone")]
        public string strContactDayPhone {get;set;}
        [StringLength(20)]
        [Display(Name="Nigth Phone")]
        [Column("contact_nphone")]
        public string strContactNightPhone {get;set;}

        [NotMapped]
        public string FullName => strLastName + ", " + strFirstName;

        public ICollection<tblLink_ViolationsDrivers> ViolationsDrivers{get;set;}
        
        public ICollection<tblLink_VehiclesDrivers> VehiclesDrivers{get;set;}

        


    }
}