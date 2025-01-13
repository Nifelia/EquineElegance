using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquineElegance.WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [Authorize(Roles = "SuperAdmin, Winkelbeheerder")]
        public ActionResult QuickCreate()
        {
            return View();
        }

    }
}