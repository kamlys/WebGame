﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessGame.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name="Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name="Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password")]
        public String comparePassword { get; set; }

        [Required]
        [Display(Name="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? Registration_Date { get; set; }
    }
}