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
using System.Globalization;

namespace VolleyballMvc.Controllers
{
    public class GameController : Controller
    {
        [GenderActionFilter]
        public ActionResult Games( string month, string gender)
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

            if ( string.IsNullOrEmpty( month ) )
            {
                month = DateTimeFormatInfo.CurrentInfo.GetMonthName( DateTime.Now.Month );
            }
            foreach ( var item in resultedList )
            {
                game = new Game( item );
                if ( month.Equals( DateTimeFormatInfo.CurrentInfo.GetMonthName( game.Date.Month ) , StringComparison.InvariantCultureIgnoreCase ) )
                {
                    games.Add( new Game( item ) );
                }
            }

            return View( new GameScheduleModel( games , month ) );
        }

        [GenderActionFilter]
        public ActionResult Index(Guid gameId, string gender)
        {
            List<Player> playersList = new List<Player>();
            List<Team> teamsList = new List<Team>();

            Middleware.VolleyballService.VolleyballServiceClient client;
            
            client = new Middleware.VolleyballService.VolleyballServiceClient();

            var playersInGameDict = client.ReadPlaeyrs_Game(gameId);
            var teamsDict = client.ReadTeams_Game(gameId);
            var gameDict = client.Read(gameId, Middleware.VolleyballService.TablesNames.Games);

            foreach (var item in playersInGameDict)
            {
                playersList.Add(new Player(item));
            }

            foreach (var item in teamsDict)
            {
                teamsList.Add(new Team(item));
            }

            Game game = new Game(gameDict);

            if (!string.IsNullOrEmpty(gender))
            {
                ViewBag.gender = gender;
            }

            return View(new PreciseGameModel(playersList, game));
        }
    }
}
