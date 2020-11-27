using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorPolicy.Models
{
    public class tblVehicles{
        [Key]
        public int lngVehicleID {get;set;}
        [Display(Name="Vehicle Chassis Number")]
        [Column("vehicle_chassis_number")]
        [StringLength(11)]
        public string strVehicleChassisNo {get;set;}
        [Display(Name="Vehicle Engine Number")]
        [Column("vehicle_engine_number")]
        [StringLength(11)]
        public string strVehicleEngineNo {get;set;}
        [Display(Name="Vehicle Engine Size")]
        [Column("vehicle_engine_size")]
        [StringLength(50)]
        public string strVehicleEngineSize {get;set;}
        [Display(Name="Vehicle Make")]
        [Column("vehicle_make")]
        [StringLength(50)]
        public string strVehicleMake {get;set;}
        [Display(Name="Vehicle Model")]
        [Column("vehicle_model")]
        [StringLength(50)]
        public string strVehicleModel {get;set;}
        [Display(Name="Registration Year")]
        [Column("registration_year")]
        public int lngRegistrationYear {get;set;}
        [Display(Name="Registration Number")]
        [Column("registration_number")]
        [StringLength(50)]
        public string strVehicleRegistrationNo {get;set;}
        [Display(Name="Vehicle Value")]
        [Column("vehicle_value")]
        [DataType(DataType.Currency)]
        public int curVehicleValue {get;set;}
        [Display(Name="Insurance Group")]
        [Column("insurance_group")]
        public int lngInsuranceGroup {get;set;}
        [Display(Name="Policy Reference Number")]
        [Column("policy_reference_number")]
        [StringLength(300)]
        public string strPolicyReferenceNo {get;set;}

        [ForeignKey("lngDriveID")]
        public ICollection<tblLink_VehiclesDrivers> VehiclesDrivers{get;set;}

        
        public tblInsuranceGroups InsuranceGroups{get;set;}
        public tblPolicies Policies{get;set;}
    
    }
}

