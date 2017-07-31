using E_Commerce.Models;
using E_Commerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace E_Commerce.Controllers
{
    public class MainMenuController : Controller
    {
        IMainMenu IObjMainMenu;
        public MainMenuController()
        {
            IObjMainMenu = new MainMenuRepository();

        }
        // GET: MainMenu
        [HttpGet]
        public ActionResult Create()
        {
            TempData["Model"] = IObjMainMenu.GetAllMainMenu();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MainMenu mainMenu)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(mainMenu.MainMenuText))
                {
                    ModelState.AddModelError("Error", "Enter Menu Text First");
                    return View(mainMenu);
                }

                int result = IObjMainMenu.InsertMainMenu(mainMenu);


                if (result > 0)
                {
                    TempData["Message"] = "Record Successfully Saved";
                }
                else
                {
                    TempData["Message"] = "Record Does'nt Saved";
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please Enter All Details");
            }
            return View("Create", mainMenu);
        }

        public ActionResult Index(int? page)
        {
            return View(IObjMainMenu.GetAllMainMenu().ToList().ToPagedList(page ?? 1,10));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = IObjMainMenu.GetMainMenuByID(id);
            return View("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MainMenu menu)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(menu.MainMenuText))
                {
                    ModelState.AddModelError("Error", "Please Enter Main Menu Text");
                    return View("Edit");
                }

                int value = IObjMainMenu.UpdateMainMenuByID(menu);

                if (value > 0)
                {
                    TempData["Message"] = "Record Updated Successfully";
                }
                else
                {
                    TempData["Message"] = "Something Went Wrong";
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please Enter All Fiields");
            }
            return View("Edit");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = IObjMainMenu.GetMainMenuByID(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePermanet(int id)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.MainMenuID = id;
            int value = IObjMainMenu.DeleteMainMenuByID(mainMenu);
            if (value > 0)
            {
                TempData["Mesage"] = "Record Deleted Successfully";
                return View("Delete");
            }
            else
            {
                TempData["Message"] = "Something Went Wrong";
                return View("Delete");
            }

            return RedirectToAction("Index");
        }


    }
}