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
            List<Dictionary<string, string>> list;
            List<Player> playersList;
            Middleware.VolleyballService.VolleyballServiceClient client;

            playersList = new List<Player>();
            client = new Middleware.VolleyballService.VolleyballServiceClient();
            
            if (!string.IsNullOrEmpty(gender))
            {
                var result = Enum.Parse(typeof(Middleware.VolleyballService.Gender), gender, true);
                list = new List<Dictionary<string, string>>(client.ReadAll(Middleware.VolleyballService.TablesNames.Players, (Middleware.VolleyballService.Gender)result));
                ViewBag.gender = gender;
            }
            else
            {
                list = new List<Dictionary<string, string>>(client.ReadAll(Middleware.VolleyballService.TablesNames.Players, Middleware.VolleyballService.Gender.Male));
            }
            foreach (var item in list)
            {
                playersList.Add(new Player(item));
            }

            return View(new PlayerModel(playersList));// new TeamModel() { Users = users } );
        }

        [GenderActionFilter]
        public ActionResult Index( string searchedText )
        {
            Middleware.VolleyballService.VolleyballServiceClient client;

            client = new Middleware.VolleyballService.VolleyballServiceClient();

            return View();
        }
    }
}
