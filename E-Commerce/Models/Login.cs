using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Your Username")]
        [EmailAddress(ErrorMessage = "Please Provide Your Valid Email ID")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Your Password First")]
        public string Password { get; set; }
    }
}