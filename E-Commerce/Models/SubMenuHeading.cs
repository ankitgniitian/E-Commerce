using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Models
{
    public class SubMenuHeading
    {
        [Key]
        public int SubMenuHeadingID { get; set; }
        [Required(ErrorMessage = "Please Enter Submenu")]
        public string SubMenuHeadingText { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("SubMenuHeadingID")]
        [ValidMainMenuAttribute(ErrorMessage = "Please Select Main Menu First")]
        public int MainMenuID { get; set; }
        public string MainMenuText { get; set; }     
        public List<MainMenu> MainMenuList { get; set; }

        public class ValidMainMenuAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (Convert.ToInt32(value) == 0 || Convert.ToInt32(value) == null)
                    return false;
                else
                    return true;
            }
        }
    }
}