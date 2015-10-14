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
using Middleware.VolleyballService;

namespace Middleware
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
        [DataMember]
        private int year;
        [DataMember]
        private string imagePath;

        private List<Player> players;
        private List<Game> games;
        private static VolleyballServiceClient client;

        static Team()
        {
            client = new VolleyballServiceClient();
        }

        public static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, LEAGUE varchar(50) NOT NULL, NAME varchar(50) NOT NULL, MANAGER varchar(50) NOT NULL, PHONE varchar(50) NOT NULL, EMAIL varchar(50) NOT NULL, PRIMARY KEY (Id) )";
        }

        public Team(string league, string name, string manager, string phone, string email, int year, string imagePath)
            : base()
        {
            this.league = league;
            this.name = name;
            this.manager = manager;
            this.phone = phone;
            this.email = email;
            this.year = year;
            this.imagePath = imagePath;
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
                this.year = Convert.ToInt32(fieldsDict["YEAR"]);
                this.imagePath = fieldsDict["imagePath"];
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

        [IsInTable]
        [DataMember]
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        [IsInTable]
        [DataMember]
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
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
    }
}
