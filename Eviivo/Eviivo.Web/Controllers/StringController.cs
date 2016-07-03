using Eviivo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eviivo.Web.Controllers
{
    public class StringController : Controller
    {
        // GET: String
        public ActionResult Match(StringMatchViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View("~/views/home/index.cshtml", model);
            }
            return View();
        }
    }
}