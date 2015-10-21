using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Attributes;
using System.Data;
using Middleware;
using System.Reflection;
using Middleware.VolleyballService;

namespace Middleware
{
    [DataContract]
    public class Player : Base
    {
        [DataMember]
        private string name;
        [DataMember]
        private int number;
        [DataMember]
        private string amplua;
        [DataMember]
        private bool captain;
        [DataMember]
        private string league;
        [DataMember]
        private string imagePath;
        [DataMember]
        private int age;
        [DataMember]
        private int height;

        private List<Team> teams;
        private List<Game> games;
        public static VolleyballServiceClient client;

        static Player()
        {
            client = new VolleyballServiceClient();
            table = MethodBase.GetCurrentMethod().DeclaringType.Name + "s";
        }

        public static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, Name varchar(50) NOT NULL, Number int NOT NULL, League varchar(50) NOT NULL, Amplua varchar(50) NOT NULL, Captain bit NOT NULL, PRIMARY KEY (Id) )";
        }

        public Player(string name, int number, string amplua, bool captain, string league, string imagepath, int age, int height)
            : base()
        {
            this.name = name;
            this.number = number;
            this.amplua = amplua;
            this.captain = captain;
            this.league = league;
            this.imagePath = imagepath;
            this.age = age;
            this.height = height;
        }

        public Player(Dictionary<string, string> fieldsDict)
        {
            try
            {
                
                this.Id = new Guid(fieldsDict["Id"]);
                this.name = fieldsDict["Name"];
                this.number = Convert.ToInt32(fieldsDict["Number"]);
                this.amplua = fieldsDict["Amplua"];
                this.captain = Convert.ToBoolean(fieldsDict["Captain"]);
                this.league = fieldsDict["League"];
                this.imagePath = fieldsDict["ImagePath"];
                this.age = Convert.ToInt32(fieldsDict["Age"]);
                this.height = Convert.ToInt32(fieldsDict["Height"]);
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
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        [IsInTable]
        [DataMember]
        public string Amplua
        {
            get
            {
                return amplua;
            }
            set
            {
                amplua = value;
            }
        }

        [IsInTable]
        [DataMember]
        public bool Captain
        {
            get
            {
                return captain;
            }
            set
            {
                captain = value;
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
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        [IsInTable]
        [DataMember]
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
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

        public string CaptainTextPresentation
        {
            get
            {
                if (captain)
                {
                    return "♛";
                }
                return "-";
            }
        }

        public List<Team> Teams
        {
            get
            {
                teams = new List<Team>();

                var teamsList = client.ReadTeams_Player(Id);
                foreach (var teamInfo in teamsList)
                {
                    teams.Add(new Team(teamInfo));
                }
                return teams;
            }
        }

        public List<Game> Games
        {
            get
            {
                games = new List<Game>();
                var gamesList = client.ReadGames_Player(Id);
                foreach (var gameInfo in gamesList)
                {
                    games.Add(new Game(gameInfo));
                }
                return games;
            }
        }
    }
}
