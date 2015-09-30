using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using VolleyballMvc.Filters;
using VolleyballMvc.Models;
using Middleware;
using System.Data.Common;

namespace VolleyballMvc.Controllers
{
    [GenderActionFilter]
    public class TeamController : Controller
    {
        public ActionResult Teams(string gender)
        {
            List<Team> teamsList = new List<Team>();
            //ViewBag.Message = "Teams available.";
            Middleware.VolleyballService.VolleyballServiceClient client = new Middleware.VolleyballService.VolleyballServiceClient();
            List<Dictionary<string, string>> list = new List<Dictionary<string , string>>( client.ReadAll(Middleware.VolleyballService.TablesNames.Teams, Middleware.VolleyballService.Gender.NotSpecified));
            if (!string.IsNullOrEmpty(gender))
            {
                ViewBag.gender = gender;
            }
            foreach (var item in list)
            {
                teamsList.Add(new Team(item));
            }
            
            return View(new TeamModel(teamsList));// new TeamModel() { Users = users } );
        }

        public ActionResult TeamInfo()
        {
            //ViewBag.Message = "Your app description page.";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    //ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
