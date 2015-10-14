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

            return View(new PlayersModel(playersList));
        }

        [GenderActionFilter]
        public ActionResult Index(Guid playerId, string gender)
        {
            Player player;
            Dictionary<string, string> playerDict;
            List<Dictionary<string, string>> gamesDict;
            List<Dictionary<string, string>> teamsDict;
            List<Game> gamesWithReward;
            List<Team> teamsList;
            Middleware.VolleyballService.VolleyballServiceClient client;

            gamesWithReward = new List<Game>();
            teamsList = new List<Team>();
            client = new Middleware.VolleyballService.VolleyballServiceClient();
            playerDict = client.Read(playerId, Middleware.VolleyballService.TablesNames.Players);
            gamesDict = client.ReadPlayerStatisticsInGames(playerId, Middleware.VolleyballService.PlayersInfo.BestPlayer);
            teamsDict = client.ReadTeams_Player(playerId);
            player = new Player(playerDict);

            if (gamesDict != null)
            {
                foreach (var item in gamesDict)
                {
                    gamesWithReward.Add(new Game(item));
                }
            }

            foreach (var item in teamsDict)
            {
                teamsList.Add(new Team(item));
            }

            if (!string.IsNullOrEmpty(gender))
            {
                ViewBag.gender = gender;
            }
            return View(new PlayerInformationModel(player, teamsList, gamesWithReward));
        }

        [GenderActionFilter]
        public ActionResult SearchResult(string searchedText, string gender)
        {
            List<Player> playersList;
            Middleware.VolleyballService.VolleyballServiceClient client;

            playersList = new List<Player>();
            client = new Middleware.VolleyballService.VolleyballServiceClient();
            var searchedResult = client.FindSerchResults(searchedText, Middleware.VolleyballService.TablesNames.Players);
            if (!string.IsNullOrEmpty(gender))
            {
                ViewBag.gender = gender;
            }
            if (searchedResult != null)
            {
                foreach (var item in searchedResult)
                {
                    playersList.Add(new Player(item));
                }
                
                return PartialView("~/Views/Player/SearchResult.cshtml", new PlayersModel(playersList));
            }
            else
            {
                return PartialView("~/Views/Player/SearchResult.cshtml", new PlayersModel(null));
            }
        }
    }
}
