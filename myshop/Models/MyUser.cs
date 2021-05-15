﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class MyUser
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string NameFamily { get; set; }
        public string Password { get; set; }
        public bool ConfirmEmail { get; set; }
        public string ResetPasswordCode { get; set; }
        [ForeignKey("Role")]
        public int? IdRole { get; set; }
        public Role Role { get; set; }
    }
}
