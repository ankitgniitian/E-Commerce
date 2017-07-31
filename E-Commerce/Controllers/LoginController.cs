using E_Commerce.Models;
using E_Commerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace E_Commerce.Controllers
{
    public class LoginController : Controller
    {

        ILogin IDataLogin;
        public LoginController()
        {
            IDataLogin = new LoginRepository();
        }
        // GET: Login This Action Method Will Show Login Page
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(login.Username))
                {
                    ModelState.AddModelError("Error", "Please Enter Username First");
                    return View(login);
                }
                bool success = WebSecurity.Login(login.Username, login.Password, false);
                if (success == true)
                {
                    Session["name"] = login.Username;

                    return RedirectToAction("Index", "AdminPanel");
                }
                else
                {
                    return View(login);
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please enter Username and Password");
            }

            return View(login);
        }


    }
}