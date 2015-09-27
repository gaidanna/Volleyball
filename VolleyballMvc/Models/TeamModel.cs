using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolleyballMvc.Models
{
    public class TeamModel
    {
        public List<Team> Teams 
        { 
            get; 
            private set;
        }
        //public int TeamId { get; set; }
        //public string Name { get; set; }
        public TeamModel(List<Team> list)
        {
            list.Sort((team1,team2)=>team1.Name.CompareTo(team2.Name));
            Teams = list;
        }
    }
}