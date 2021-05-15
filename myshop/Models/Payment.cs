using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class Payment
    {
        [Key]
        public int IdPayment { get; set; }
        public double TotalPrice { get; set; }       
        public bool PaymentConfirmation { get; set; }
        [ForeignKey("MyUser")]
        public int UserId { get; set; }
        public MyUser MyUser { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }
    }
}