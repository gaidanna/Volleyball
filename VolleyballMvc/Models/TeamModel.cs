using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolleyballMvc.Models
{
    public class TeamsModel
    {

        public List<Team> Teams
        {
            get;
            private set;
        }

        public TeamsModel(List<Team> list)
        {
            list.Sort((team1, team2) => team1.Name.CompareTo(team2.Name));
            Teams = list;
        }
    }

    public class TeamInformationModel
    {
        public TeamInformationModel(List<Player> list, Team team)
        {
            TeamPlayers = list;
            Team = team;
        }

        public List<Player> TeamPlayers
        {
            get;
            private set;
        }

        public Team Team
        {
            get;
            private set;
        }

        public string ImagePath
        {
            get
            {
                return String.Concat("~/", Team.ImagePath.Replace(@"\", " /").Substring(41).Replace(" ", ""));
            }
        }
    }
}