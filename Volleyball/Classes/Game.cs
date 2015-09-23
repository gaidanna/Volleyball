using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Classes;
using System.Xml;
using System.Runtime.Serialization;
using Volleyball.Attributes;
using Middleware;
using Volleyball.ServiceReference1;
using System.Reflection;

namespace Volleyball
{
    [DataContract(IsReference = true)]
    public class Game : Base
    {
        private static IDataBase dataBase;

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
        protected static string table;
        [DataMember]
        private string score;
        private static VolleyballServiceClient client = new VolleyballServiceClient();

        //public static Dictionary<Guid, Game> Items = new Dictionary<Guid, Game>();
        private List<Player> players;
        private Team[] teams;

        static Game()
        {
            table = MethodBase.GetCurrentMethod().DeclaringType.Name + "s";
            TableInform.TryCreateTable(table, GetRowNames);
        }

        private static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, League varchar(50) NOT NULL, FirstReferee varchar(50) NOT NULL, SecondReferee varchar(50) NOT NULL, Location varchar(50) NOT NULL, Date date NOT NULL, TeamOneId uniqueidentifier NOT NULL, TeamTwoId uniqueidentifier NOT NULL, Score varchar(50) NOT NULL, PRIMARY KEY (Id) )";
        }

        public Game(string league, string mainReferee, string secondReferee, string location, DateTime date, Team teamOne, Team teamTwo, string score)
        {
            //players = new List<Player>();
            //teams = new List<Team>();
            //Items.Add(Id, this);
            this.teamOneId = teamOne.Id;
            this.teamTwoId = teamTwo.Id;
            this.league = league;
            this.firstReferee = mainReferee;
            this.secondReferee = secondReferee;
            this.location = location;
            this.date = date;
            this.score = score;
        }

        public Game(Dictionary<string, string> fieldsDict)
        {
            try
            {
                
                this.Id = new Guid(fieldsDict["Id"]);
                //this,teamOneId = new Guid[2];
                this.teamOneId = new Guid(fieldsDict["TeamOneId"]);
                this.teamTwoId = new Guid(fieldsDict["TeamTwoId"]);
                this.league = fieldsDict["League"];
                this.firstReferee = fieldsDict["FirstReferee"];
                this.secondReferee = fieldsDict["SecondReferee"];
                this.location = fieldsDict["Location"];
                this.date = Convert.ToDateTime(fieldsDict["Date"]);
                this.score = fieldsDict["Score"];
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
                
                //teams = new List<Team>();
                teams = new Team[2];
                var teamsList = client.ReadTeams_Game(Id);
                for (int a = 0; a < teamsList.Count; a++)
                {
                    teams[a] = new Team(teamsList[a]);
                }
                return teams;
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
    }
}
