﻿using System;
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
    [DataContract]
    public class Team : Base
    {
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

        public Team(string league, string name, string manager, string phone, string email, string imagePath)
            : base()
        {
            this.league = league;
            this.name = name;
            this.manager = manager;
            this.phone = phone;
            this.email = email;
            this.imagePath = imagePath;
        }


        public Team(Dictionary<string, string> fieldsDict)
        {
            try
            {
                this.Id = new Guid(fieldsDict["Id"]);
                this.league = fieldsDict["League"];
                this.name = fieldsDict["Name"];
                this.manager = fieldsDict["Manager"];
                this.phone = fieldsDict["Phone"];
                this.email = fieldsDict["Email"];
                this.imagePath = fieldsDict["ImagePath"];
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
