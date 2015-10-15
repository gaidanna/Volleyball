using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middleware;

namespace VolleyballMvc.Models
{
    public class HomeModel
    {
        public Dictionary<DateTime, List<Game>> Games
        {
            get;
            private set;
        }

        public HomeModel(List<Game> games)
        {
            int count;

            games.Sort(delegate(Game first, Game next)
            {
                return next.Date.CompareTo(first.Date);
            });

            this.Games = new Dictionary<DateTime, List<Game>>();

            if (games.Count > 3)
            { count = 3; }
            else
            { count = games.Count; }

            for (int i = 0; i < count; i++)
            {
                if (!this.Games.ContainsKey(games[i].Date))
                {
                    this.Games[games[i].Date] = new List<Game>();
                }
                this.Games[games[i].Date].Add(games[i]);
            }
        }
    }
}