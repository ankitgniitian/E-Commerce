using E_Commerce.Models;
using E_Commerce.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class SubMenuHeadingController : Controller
    {
        ISubMenuHeading IObjSubMenuData;
        IMainMenu IObjMainmenuData;
        public SubMenuHeadingController()
        {
            IObjSubMenuData = new SubMenuHeadingRepository();
            IObjMainmenuData = new MainMenuRepository();
        }
        // GET: SubMenuHeading
        public ActionResult Index()
        {
            var model = IObjSubMenuData.GetAllSubMenu();
            return View(model);
        }
       [HttpGet]
        public ActionResult Create()
        {
            SubMenuHeading subMenuHeading = new SubMenuHeading();
            subMenuHeading.MainMenuList = BindMainMenu();
            return View(subMenuHeading);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubMenuHeading subMenuHeading)
        {
            if (ModelState.IsValid)
            {
                IObjSubMenuData.InsertSubMenuHeading(subMenuHeading);
            }
            else
            {
                ModelState.AddModelError("Error", "Please Enter Full Details");
            }

            subMenuHeading.MainMenuList = BindMainMenu();
            
            return View(subMenuHeading);
        }

        [NonAction]
        public List<MainMenu> BindMainMenu()
        {
            List<MainMenu> mainMenuList = new List<MainMenu>()
            {
                new MainMenu
                {
                    MainMenuID = 0,
                    MainMenuText = "Select"
                }
            };

            foreach (var item in IObjMainmenuData.GetActiveMainMenu())
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.MainMenuID = item.MainMenuID;
                mainMenu.MainMenuText = item.MainMenuText;
                mainMenuList.Add(mainMenu);
            }

            return mainMenuList;

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SubMenuHeading subMenuHeading = new SubMenuHeading();

            subMenuHeading.SubMenuHeadingID = id;

            subMenuHeading = IObjSubMenuData.GetSubMenuHeadingByID(subMenuHeading);

            subMenuHeading.MainMenuList = BindMainMenu();

            subMenuHeading.MainMenuList.Select(x => x.MainMenuID = id);

            return View(subMenuHeading);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditPost(SubMenuHeading subMenuHeading)
        {
            if (ModelState.IsValid)
            {
                IObjSubMenuData.UpdateSubMenuHeading(subMenuHeading);
            }

            subMenuHeading.MainMenuList = BindMainMenu();

            return View(subMenuHeading);
        }

        //private string Encrypt(string clearText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}

        //private string Decrypt(string cipherText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    cipherText = cipherText.Replace(" ", "+");
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            SubMenuHeading subMenuHeading = new SubMenuHeading();

            subMenuHeading.SubMenuHeadingID = id;

            subMenuHeading.MainMenuList = BindMainMenu();

            subMenuHeading.MainMenuList.Select(x => x.MainMenuID = id);

            subMenuHeading = IObjSubMenuData.GetSubMenuHeadingByID(subMenuHeading);

            if (subMenuHeading == null)
            {
                TempData["Message"] = "No Records Found";
                return View();
            }

            return View(subMenuHeading);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePerManent(int id)
        {
            SubMenuHeading subMenuHeading = new SubMenuHeading();
            subMenuHeading.SubMenuHeadingID = id;
            int value = IObjSubMenuData.DeleteSubMenuHeading(subMenuHeading);
            if (value > 0)
            {
                TempData["Message"] = "Record Deleted Successfully";
            }
            else
            {
                TempData["Message"] = "Something Went Wrong";
            }
            return View("Delete");
        }
    }
}