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
using Middleware;

namespace VolleyballMvc.Controllers
{
    [GenderActionFilter]
    public class PlayerController : Controller
    {
        public ActionResult Players(string gender)
        {
            List<Player> playersList = new List<Player>();
            //ViewBag.Message = "Teams available.";
            Middleware.VolleyballService.VolleyballServiceClient client = new Middleware.VolleyballService.VolleyballServiceClient();

            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>(client.ReadAll(Middleware.VolleyballService.TablesNames.Players, Middleware.VolleyballService.Gender.NotSpecified));

            if (!string.IsNullOrEmpty(gender))
            {
                ViewBag.gender = gender;
            }
            foreach (var item in list)
            {
                playersList.Add(new Player(item));
            }

            return View(new PlayerModel(playersList));// new TeamModel() { Users = users } );
        }
    }
}
