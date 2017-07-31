using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class MainMenu
    {
        [Key]
        public int MainMenuID { get; set; }
        [Required(ErrorMessage = "Please Enter Main Menu Text")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string MainMenuText { get; set; }

        public bool IsActive { get; set; }
    }
}