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
        public ActionResult Games( string month )
        {
            Game game;
            List<Game> games;
            Middleware.VolleyballService.VolleyballServiceClient client;
            List<Dictionary<string , string>> resultedList;

            client = new Middleware.VolleyballService.VolleyballServiceClient();
            resultedList = new List<Dictionary<string , string>>( client.ReadAll( Middleware.VolleyballService.TablesNames.Games , Middleware.VolleyballService.Gender.NotSpecified ) );

            games = new List<Game>();
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
