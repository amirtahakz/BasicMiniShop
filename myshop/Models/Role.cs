using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRole { get; set; }
        public string NameFarsi { get; set; }
        public string NameEnglish { get; set; }
        public List<MyUser> MyUsers { get; set; }
    }
}