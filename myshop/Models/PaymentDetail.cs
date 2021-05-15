using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class PaymentDetail
    {
        [Key]
        public int IdPaymentDetail { get; set; }
        public int NumbersOfProduct { get; set; }
        public double ProductPrice { get; set; }
        [ForeignKey("Payment")]
        public int IdPayment { get; set; }
        [ForeignKey("Product")]
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public Payment Payment { get; set; }
    }
}