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

    public class PreciseGameModel
    {
        public Game PreciseGame
        { get; private set; }

        public List<Player> FirstTeamPlayers
        { get; private set; }

        public List<Player> SecondTeamPlayers
        { get; private set; }

        public List<Player> Players
        { get; private set; }

        public PreciseGameModel(List<Player> teamPlayers, Game game)
        {
            PreciseGame = game;
            Players = teamPlayers;
            //FirstTeamPlayers = teamPlayers.FindAll(item => item.);
            //SecondTeamPlayers = secondTeamPlayers;
        }
    }
}