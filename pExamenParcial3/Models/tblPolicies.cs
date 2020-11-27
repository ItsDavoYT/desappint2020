using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorPolicy.Models
{
    public class tblPolicies{
        [Key]
        [Display(Name="Policy Reference")]
        [Column("policy_reference")]
        [StringLength(50)]
        public string strPolicyReferenceNo {get;set;}
        [Display(Name="Policy Effective Date")]
        [Column("policy_effective_date")]
        [DataType(DataType.Date)]
        public DateTime dtePolicyEffectiveDate {get;set;}
        [Display(Name="Policy Expiration Date")]
        [Column("policy_expiration_date")]
        [DataType(DataType.Date)]
        public DateTime dtePolicyExpirationDate {get;set;}
        [Display(Name="Policy Cost")]
        [Column("policy_cost")]
        [DataType(DataType.Currency)]
        public int curTotalPolicyCost{get;set;}
        [Display(Name="Payer ID")]
        [Column("payer_id")]
        public int lngPayerId{get;set;}
        [Display(Name="Last Update")]
        [Column("last_update")]
        public DateTime dteLastUpdate{get;set;}
        [Display(Name="Additional Info")]
        [Column("additional_info")]
        [StringLength(300)]
        public string memAdditionalInfo{get;set;}

        public ICollection<tblVehicles> Vehicles{get;set;}

    }
    
}

