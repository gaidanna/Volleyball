using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware;

namespace VolleyballMvc.Models
{
    public class GameScheduleModel
    {
        public Game[] Games
        {
            get;
            private set;
        }

        public GameScheduleModel( List<Dictionary<string , string>> data )
        {
            List<Game> games;

            games = new List<Game>();

            foreach ( var item in data )
            {
                games.Add( new Game( item ) );
            }
            games.Sort( delegate( Game first , Game next )
            {
                return next.Date.CompareTo( first.Date );
            } );

            this.Games = games.ToArray();
        }

    }
}