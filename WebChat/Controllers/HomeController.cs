using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebChat.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [Authorize(Roles="Admins")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
