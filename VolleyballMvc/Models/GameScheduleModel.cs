using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware;

namespace VolleyballMvc.Models
{
    public class GameScheduleModel
    {
        public Dictionary<DateTime , List<Game>> Games
        {
            get;
            private set;
        }

        public GameScheduleModel( List<Game> games )
        {
            games.Sort( delegate( Game first , Game next )
            {
                return next.Date.CompareTo( first.Date );
            } );

            this.Games = new Dictionary<DateTime , List<Game>>();

            foreach ( Game game in games )
            {
                if ( !this.Games.ContainsKey( game.Date ) )
                {
                    this.Games[ game.Date ] = new List<Game>();
                }
                this.Games[ game.Date ].Add( game );
            }
        }
    }
}