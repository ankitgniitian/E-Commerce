using E_Commerce.Models;
using E_Commerce.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Dapper;
using WebMatrix.WebData;
using E_Commerce.Filters;

namespace E_Commerce.Controllers
{
    [MyExceptionHandler]
    public class AddUserController : Controller
    {
        ILogin loginData;
        public AddUserController()
        {
            loginData = new LoginRepository();
        }
        [HttpGet]
        // GET: AddUser
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(login.Username))
                {
                    ModelState.AddModelError("Error", "Please Enter Username First");
                    return View(login);
                }

                if (string.IsNullOrEmpty(login.Password))
                {
                    ModelState.AddModelError("Error", "Please Enter Password First");
                    return View(login);
                }
                if (WebSecurity.UserExists(login.Username))
                {
                    ModelState.AddModelError("Error", "This Username Is Already Exists");
                    return View(login);
                }

                WebSecurity.CreateUserAndAccount(login.Username, login.Password, new { EmailID = login.Username });

                if (loginData.InsertLoginDetails(login) > 0)
                {
                    TempData["Message"] = "Record Saved Successfully";

                    RedirectToAction("Login", "Login");
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please Enter Username And Password");
                return View(login);
            }

            return View(login);
        }
    }
}