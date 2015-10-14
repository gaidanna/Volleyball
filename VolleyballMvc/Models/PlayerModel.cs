using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolleyballMvc.Models
{
    public class PlayerModel
    {
        public List<Player> Players 
        { 
            get; 
            private set;
        }
        public PlayerModel(List<Player> list)
        {
            list.Sort((pl1,pl2)=>pl1.Name.CompareTo(pl2.Name));
            Players = list;
        }
    }
}