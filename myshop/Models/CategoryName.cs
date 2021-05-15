using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class CategoryName
    {
        [Key]
        public int IdCategoryName { get; set; }
        public string Subject { get; set; }
        public List<ProductWithCategory> ProductWithCategorys { get; set; }

    }
}