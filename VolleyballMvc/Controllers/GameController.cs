using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using VolleyballMvc.Filters;
using VolleyballMvc.Models;
using Middleware.VolleyballService;

namespace VolleyballMvc.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Games()
        {
            ViewBag.Message = "Games available.";

            TeamsContext dbContext = new TeamsContext();

            VolleyballServiceClient client = new VolleyballServiceClient();

            List<Dictionary<string , string>> resultedList = new List<Dictionary<string , string>>( client.ReadAll( TablesNames.Games , Gender.NotSpecified ) );

            return View( new GameScheduleModel( resultedList ) );
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
