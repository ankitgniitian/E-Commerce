﻿using E_Commerce.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        [MyExceptionHandler]
        public ActionResult Index()
        {
            return View();
        }
    }
}