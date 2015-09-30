using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolleyballMvc.Models;

namespace VolleyballMvc.Controllers
{

    [GenderActionFilter]
    public class HomeController : Controller
    {
        public ActionResult Index(string gender)
        {
            if (!string.IsNullOrEmpty(gender))
            {
                ViewBag.gender = gender;
            }
            return View();
        }

        [GenderActionFilter]
        public ActionResult Contact(string gender)
        {
            if (!string.IsNullOrEmpty(gender))
            {
                ViewBag.gender = gender;
            }
            return View();
        }
    }
}
