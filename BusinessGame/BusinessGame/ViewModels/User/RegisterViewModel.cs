using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        public DateTime Registration_date { get; set; }
    }
}