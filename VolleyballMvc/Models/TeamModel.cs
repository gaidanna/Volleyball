using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolleyballMvc.Models
{
    public class TeamModel
    {
        public List<Player> TeamPlayers 
        { 
            get; 
            private set;
        }

        public List<Team> Teams 
        { 
            get; 
            private set;
        }

        public Team Team
        {
            get;
            private set;
        }

        //public TeamPlayersModel(List<Player> list)
        //{
        //    list.Sort((pl1,pl2)=>pl1.Name.CompareTo(pl2.Name));
        //    TeamPlayers = list;
        //}
        
        //public int TeamId { get; set; }
        //public string Name { get; set; }
        public TeamModel(List<Team> list)
        {
            list.Sort((team1,team2)=>team1.Name.CompareTo(team2.Name));
            Teams = list;
        }

        public TeamModel(List<Player> list, Team team)
        {
            TeamPlayers = list;
            Team = team;
        }
    }
}