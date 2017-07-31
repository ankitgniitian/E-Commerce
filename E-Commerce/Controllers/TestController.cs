using E_Commerce.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class TestController : Controller
    {
        ITest IObjtestData;
        public TestController()
        {
            IObjtestData = new Test();
        }
        // GET: Test
        public ActionResult List(int? page)
        {
            return View(IObjtestData.GetAllTest().ToList().ToPagedList(page ?? 1,10));
        }

        public ActionResult List2()
        {
            var test = IObjtestData.GetAllTest();
            return View("List2", test);
        }
    }
}