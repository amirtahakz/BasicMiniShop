using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class ProductWithCategory
    {
        [Key]
        public int IdProductWithCategory { get; set; }
        [ForeignKey("CategoryName")]
        public int IdCategoryName { get; set; }
        [ForeignKey("Product")]
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public CategoryName CategoryName { get; set; }

    }
}