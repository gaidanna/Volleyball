using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using VolleyballMvc.Filters;
using VolleyballMvc.Models;

namespace VolleyballMvc.Controllers
{
    [GenderActionFilter]
    public class WomenController : BaseController
    {
        public ActionResult WomenInfo(string gender)
        {
            ViewBag.Message = "Women league available.";

            return View();
        }

        //public ActionResult About()
        //{
        //    //ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    //ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
