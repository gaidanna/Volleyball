using Middleware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VolleyballMvc.Models
{
    public class PlayersModel
    {
        public List<Player> Players
        {
            get;
            private set;
        }
        public PlayersModel(List<Player> list)
        {
                list.Sort((pl1, pl2) => pl1.Name.CompareTo(pl2.Name));
                Players = list;
        }
    }

    public class PlayerInformationModel
    {
        public PlayerInformationModel(Player player, List<Team> teams, List<Game> games)
        {
            Player = player;
            Teams = teams;
            Games = games;
        }

        public Player Player
        {
            get;
            private set;
        }

        public List<Game> Games
        {
            get;
            private set;
        }

        public List<Team> Teams
        {
            get;
            private set;
        }

        public string ImagePath
        {
            get
            {
                return String.Concat("~/Content/Images/", Player.ImagePath.Replace(@"\", " /").Replace(" ", ""));
            }
        }

    }
}