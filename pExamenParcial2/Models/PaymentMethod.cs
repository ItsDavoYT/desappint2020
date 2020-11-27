using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelAGC.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodID {get; set;}
        [Required]
        [Display(Name="Payment Method")]
        [StringLength(50)]
        public string paymentMethod {get; set;}
        
        public ICollection<Payment> Payments {get; set;}       
    }
}