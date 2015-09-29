using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolleyballMvc.Models;

namespace VolleyballMvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string Gender
        {
            get { return (string)ControllerContext.RouteData.Values["gender"]; }
        }
    }


    [GenderActionFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index(string gender)
        {
            string path;
            //if (string.IsNullOrEmpty(gender))
            //{
            //    return HttpNotFound();
            //}
            if (gender == "female")
            {
                path = "../Content/Styles/Home.css";
            }
            else
            {
                path = "../Content/Styles/HomeW.css";
            }
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
