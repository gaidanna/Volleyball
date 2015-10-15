using Middleware;
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
            Game game;
            List<Game> games;
            List<Dictionary<string, string>> resultedList;
            Middleware.VolleyballService.VolleyballServiceClient client;

            games = new List<Game>();
            client = new Middleware.VolleyballService.VolleyballServiceClient();

            if (!string.IsNullOrEmpty(gender))
            {
                var result = Enum.Parse(typeof(Middleware.VolleyballService.Gender), gender, true);
                resultedList = new List<Dictionary<string, string>>(client.ReadAll(Middleware.VolleyballService.TablesNames.Games, (Middleware.VolleyballService.Gender)result));
                ViewBag.gender = gender;
            }
            else
            {
                resultedList = new List<Dictionary<string, string>>(client.ReadAll(Middleware.VolleyballService.TablesNames.Games, Middleware.VolleyballService.Gender.Male));
            }

            foreach (var item in resultedList)
            {
                    games.Add(new Game(item));
            }

            return View(new HomeModel(games));
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
