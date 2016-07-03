using Eviivo.Domain;
using Eviivo.Web.Actions;
using Eviivo.Web.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eviivo.Web.Controllers
{
    public class StringController : Controller
    {
        private ILogger logger;
        private IStringMatch stringMatch;

        public StringController(ILogger logger, IStringMatch stringMatch)
        {
            this.stringMatch = stringMatch;
            this.logger = logger;
        }

        [HttpPost]
        // GET: String
        public ActionResult Match(StringMatchViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View("~/views/home/index.cshtml", model);
            }
            else
            {
                return new StringMatchAction<ActionResult>(logger, stringMatch)
                {
                    OnComplete = (m) => View("~/views/home/index.cshtml", m),
                    OnFailed = () => View("~views/shared/error.cshtml")
                }.Execute(model);
            }
        }
    }
}