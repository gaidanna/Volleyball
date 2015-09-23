using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Volleyball.Attributes;
using Middleware;
using System.Reflection;
using Volleyball.ServiceReference1;

namespace Volleyball
{
    //[StringLengthValidationClass]
    [DataContract]
    public class Team : Base
    {
        protected static IDataBase dataBase;
        [DataMember]
        private string name;
        [DataMember]
        private string league;
        [DataMember]
        private string manager;
        [DataMember]
        private string phone;
        [DataMember]
        private string email;

        private List<Player> players;
        private List<Game> games;
        private static VolleyballServiceClient client;

        static Team()
        {
            TableInform.TryCreateTable( "Teams" , GetRowNames );
            client = new VolleyballServiceClient();
        }

        private static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, LEAGUE varchar(50) NOT NULL, NAME varchar(50) NOT NULL, MANAGER varchar(50) NOT NULL, PHONE varchar(50) NOT NULL, EMAIL varchar(50) NOT NULL, PRIMARY KEY (Id) )";
        }

        [StringLengthValidation( 3 )]
        public Team( string league, string name, string manager, string phone, string email )
            : base()
        {
            
            this.league = league;
            this.name = name;
            this.manager = manager;
            this.phone = phone;
            this.email = email;
        }

        public Team(Dictionary<string, string> fieldsDict)
        {
            try
            {
                
                this.Id = new Guid(fieldsDict["Id"]);
                this.league = fieldsDict["LEAGUE"];
                this.name = fieldsDict["NAME"];
                this.manager = fieldsDict["MANAGER"];
                this.phone = fieldsDict["PHONE"];
                this.email = fieldsDict["EMAIL"];
            }
            catch
            { }
        }

         [IsInTable]
        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

         [IsInTable]
         [DataMember]
         public string League
         {
             get
             {
                 return league;
             }
             set
             {
                 league = value;
             }
         }

         [IsInTable]
         [DataMember]
         public string Manager
         {
             get
             {
                 return manager;
             }
             set
             {
                 manager = value;
             }
         }

         [IsInTable]
         [DataMember]
         public string Phone
         {
             get
             {
                 return phone;
             }
             set
             {
                 phone = value;
             }
         }

         [IsInTable]
         [DataMember]
         public string Email
         {
             get
             {
                 return email;
             }
             set
             {
                 email = value;
             }
         }

         public List<Player> Players
         {
             get
             {
                 players = new List<Player>();
                 var playersList = client.ReadPlayers_Team(Id);
                 foreach (var plInfo in playersList)
                 {
                     players.Add(new Player(plInfo));
                 }
                 return players;
             }
         }

         public List<Game> Games
         {
             get
             {
                 games = new List<Game>();
                 var gamesList = client.ReadGames_Team(Id);
                 foreach (var gameInfo in gamesList)
                 {
                     games.Add(new Game(gameInfo));
                 }
                 return games;
             }
         }
         //public List<Game> Games
         //{
         //    get
         //    {
         //        var gamesList = new List<Game>();

         //        foreach (var game in Game.Items.Values)
         //        {
         //            if (game.Teams[0] == this || game.Teams[1] == this)
         //                gamesList.Add(game);
         //        }
         //        return gamesList;
         //    }
         //}

        //public List<PlayerInTeam> PlayerTeamObjs
        //{
        //    get
        //    {
        //        var playerTeamList = new List<PlayerInTeam>();
        //        foreach ( var playerTeam in PlayerInTeam.Items.Values )
        //            if ( playerTeam.Team == this )
        //                playerTeamList.Add( playerTeam );
        //        return playerTeamList;
        //    }
        //}


        //public List<Player> Players
        //{
        //    get
        //    {
        //        var teamList = new List<Player>();
        //        foreach ( var playerTeam in PlayerInTeam.Items.Values )
        //            if ( playerTeam.Team == this )
        //                teamList.Add( playerTeam.Player );
        //        return teamList;
        //    }
        //}

        //public override Dictionary<string, string> ConvertInstanceToDictionary()
        //{
        //    Dictionary<string, string> selectedProperties;
        //    Dictionary<string, string> selectedFields;
        //    Dictionary<string, string> result;

        //    selectedProperties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(prop => prop.GetCustomAttribute<IsInTable>() != null).ToDictionary(prop => prop.Name, prop => prop.GetValue(this).ToString());
        //    selectedFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.GetCustomAttribute<IsInTable>() != null).ToDictionary(f => f.Name, f => f.GetValue(this).ToString());

        //    if (selectedFields.Count > 0)
        //    {
        //        result = selectedProperties.Union(selectedFields).ToDictionary(k => k.Key, v => v.Value);
        //        return result;
        //    }
        //    else return selectedProperties;

        //}
    }
}
