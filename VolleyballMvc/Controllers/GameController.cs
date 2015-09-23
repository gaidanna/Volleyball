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
using Middleware;

namespace VolleyballMvc.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Games()
        {
            ViewBag.Message = "Games available.";

            TeamsContext dbContext = new TeamsContext();
            //string[] users = dbContext.Teams.Select(item => item.Name ).ToArray();

            return View( new GameScheduleModel() { Date = DateTime.Now , Games = new List<string>( new string[] { "Game1" , "Game2" , "Game3" } ) } );
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
