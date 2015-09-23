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
    public class TeamController : Controller
    {
        public ActionResult Teams()
        {
            //ViewBag.Message = "Teams available.";
           // VolleyballServiceClient client = new VolleyballServiceClient();
           // List<Dictionary<string, string>> list = client.ReadAll(TablesNames.Teams, Gender.Male);

            //UsersContext dbContext = new UsersContext();
            //string[] users = dbContext.UserProfiles.Select(item => item.UserName).ToArray();

            //TableInform table;
            //DbConnection connection;
            //DataRow[] rows;
            //List<Dictionary<string, string>> resultedList;

            //connection = TableInform.Connection;
            //resultedList = new List<Dictionary<string, string>>();
            //table = new TableInform("Teams"  );

            //if (true)
            //{
            //    rows = table.Table.Select();
            //}
            ////else
            ////{
            ////    string param = String.Format("LEAGUE = '{0}'", gender.ToString());
            ////    rows = table.Table.Select(param);
            ////}

            //foreach (var row in rows)
            //{
            //    var result = table.ConvertRowToDict(row);
            //    resultedList.Add(result);
            //}           


            ////IEnumerable<Team> teams = db
            ////ViewBag
            return View();// new TeamModel() { Users = users } );
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
