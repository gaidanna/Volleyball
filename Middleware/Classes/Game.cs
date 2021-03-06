﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization;
using Volleyball.Attributes;
using Middleware;
using Middleware.VolleyballService;
using System.Reflection;

namespace Middleware
{
    [DataContract( IsReference = true )]
    public class Game : Base
    {
        [IsInTable]
        [DataMember]
        private Guid teamOneId;
        [IsInTable]
        [DataMember]
        private Guid teamTwoId;
        [DataMember]
        private string league;
        [DataMember]
        private string firstReferee;
        [DataMember]
        private string secondReferee;
        [DataMember]
        private string location;
        [DataMember]
        private DateTime date;
        [DataMember]
        private string score;

        private static VolleyballServiceClient client = new VolleyballServiceClient();
        private List<Player> players;
        private List<Player> playersInGame;
        private Team[] teams;

        static Game()
        {
            table = MethodBase.GetCurrentMethod().DeclaringType.Name + "s";
        }

        public static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, League varchar(50) NOT NULL, FirstReferee varchar(50) NOT NULL, SecondReferee varchar(50) NOT NULL, Location varchar(50) NOT NULL, Date date NOT NULL, TeamOneId uniqueidentifier NOT NULL, TeamTwoId uniqueidentifier NOT NULL, Score varchar(50) NOT NULL, PRIMARY KEY (Id) )";
        }

        public Game( string league , string mainReferee , string secondReferee , string location , DateTime date , Team teamOne , Team teamTwo , string score )
        {
            this.teamOneId = teamOne.Id;
            this.teamTwoId = teamTwo.Id;
            this.league = league;
            this.firstReferee = mainReferee;
            this.secondReferee = secondReferee;
            this.location = location;
            this.date = date;
            this.score = score;
        }

        public Game( Dictionary<string , string> fieldsDict )
        {
            try
            {
                this.Id = new Guid( fieldsDict[ "Id" ] );
                this.teamOneId = new Guid( fieldsDict[ "TeamOneId" ] );
                this.teamTwoId = new Guid( fieldsDict[ "TeamTwoId" ] );
                this.league = fieldsDict[ "League" ];
                this.firstReferee = fieldsDict[ "FirstReferee" ];
                this.secondReferee = fieldsDict[ "SecondReferee" ];
                this.location = fieldsDict[ "Location" ];
                this.date = Convert.ToDateTime( fieldsDict[ "Date" ] );
                this.score = fieldsDict[ "Score" ];
            }
            catch
            { }
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
        public string FirstReferee
        {
            get
            {
                return firstReferee;
            }
            set
            {
                firstReferee = value;
            }
        }

        [IsInTable]
        [DataMember]
        public string SecondReferee
        {
            get
            {
                return secondReferee;
            }
            set
            {
                secondReferee = value;
            }
        }

        [IsInTable]
        [DataMember]
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        [IsInTable]
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [IsInTable]
        [DataMember]
        public string Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public Team[] Teams
        {
            get
            {
                var teams = new List<Team>();
                var teamsList = client.ReadTeams_Game(Id);
                foreach (var team in teamsList)
                {
                    teams.Add(new Team(team));
                }
                return teams.ToArray();
            }
        }

        public List<Player> Players
        {
            get
            {
                players = new List<Player>();
                var playersList = client.ReadPlaeyrs_Game(Id);
                foreach (var pl in playersList)
                {
                    players.Add(new Player(pl));
                }
                return players;
            }
        }

        public List<Player> BestPlayers
        {
            get
            {
                playersInGame = new List<Player>();
                var playersList = client.ReadPlayersInfoInGame(Id, VolleyballService.PlayersInfo.BestPlayer);
                if (playersList != null)
                {
                    foreach (var pl in playersList)
                    {
                        playersInGame.Add(new Player(pl));
                    }
                    return playersInGame;
                }
                return null;
            }
        }

        public List<Player> YellowCardsPlayers
        {
            get
            {
                playersInGame = new List<Player>();
                var playersList = client.ReadPlayersInfoInGame(Id, VolleyballService.PlayersInfo.YellowCard);
                if (playersList != null)
                {
                    foreach (var pl in playersList)
                    {
                        playersInGame.Add(new Player(pl));
                    }
                    return playersInGame;
                }
                return null;
            }
        }

        public List<Player> RedCardsPlayers
        {
            get
            {
                playersInGame = new List<Player>();
                var playersList = client.ReadPlayersInfoInGame(Id, VolleyballService.PlayersInfo.RedCard);
                if (playersList != null)
                {
                    foreach (var pl in playersList)
                    {
                        playersInGame.Add(new Player(pl));
                    }
                    return playersInGame;
                }
                return null;
            }
        }
    }
}
