using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class ResetPasswordModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "پسوورد جدید خالی است")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "پسورد جدید و تکرار آن با هم مطابقت ندارد")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ResetCode { get; set; }
    }
}