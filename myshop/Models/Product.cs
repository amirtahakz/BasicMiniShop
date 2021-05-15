using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PriceOffer { get; set; }
        public string ImageProduct { get; set; }
        public int NumbersOfProduct { get; set; }
        public List<ProductWithCategory> ProductWithCategorys { get; set; }
    }
}