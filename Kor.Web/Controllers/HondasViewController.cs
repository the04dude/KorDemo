using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kor.Web.Controllers
{
    public class HondasViewController : Controller
    {
        [Authorize()]
        public ActionResult Index()
        {
            return View();
        }
    }
}