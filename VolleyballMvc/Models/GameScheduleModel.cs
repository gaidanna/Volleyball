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

        public string Month
        {
            get;
            private set;
        }

        //public string ShortScore
        //{
        //    get {
        //        int firstTeamCount = 0;
        //        int secondTeamCount = 0;
        //        var result = game.Score.Replace("(", string.Empty).Replace(")", string.Empty).Replace(";", ", ").Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        //        for (int i = 0; i < result.Length - 1; i++)
        //        {
        //            if (Convert.ToInt32(result[i]) > Convert.ToInt32(result[i + 1]))
        //            {
        //                firstTeamCount++;
        //            }
        //            else
        //            {
        //                secondTeamCount++;
        //            }
        //        }
                                
            
        //    }
        //}

        public GameScheduleModel( List<Game> games , string month )
        {
            this.Month = month;

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

        public string GetMonthClass( string month )
        {
            return "month-picker-label" + ( month.Equals( this.Month , StringComparison.InvariantCultureIgnoreCase ) ? " active" : "" );
        }
    }
}