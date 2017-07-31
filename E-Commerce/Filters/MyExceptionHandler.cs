﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Filters
{
    public class MyExceptionHandler : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase ctx = filterContext.HttpContext;

            //check if session is supported
            if (ctx.Session["Name"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}