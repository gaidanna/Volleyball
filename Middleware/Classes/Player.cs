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

        //private bool yellowCard;
        //private bool redCard;
        //private bool bestPlayer;

        private List<Team> teams;
        private List<Game> games;

        
        public static VolleyballServiceClient client;

        protected static IDataBase dataBase;
        //public static Dictionary<Guid, Player> Items = new Dictionary<Guid, Player>();

        static Player()
        {
            client = new VolleyballServiceClient();
            table = MethodBase.GetCurrentMethod().DeclaringType.Name + "s";
            //client.TryCreateTable(table, GetRowNames);
            //TableInform.TryCreateTable(table, GetRowNames);
        }

        public static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, Name varchar(50) NOT NULL, Number int NOT NULL, League varchar(50) NOT NULL, Amplua varchar(50) NOT NULL, Captain bit NOT NULL, PRIMARY KEY (Id) )";
        }

        public Player(string name, int number, string amplua, bool captain, string league)
            : base()
        {
            
            this.name = name;
            this.number = number;
            this.amplua = amplua;
            this.captain = captain;
            this.league = league;
            //Items.Add(Id, this);
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

       

        //public List<PlayerInTeam> PlayerTeamObjs
        //{
        //    get
        //    {
        //        var playerTeamList = new List<PlayerInTeam>();
        //        foreach (var teamPlayer in PlayerInTeam.Items.Values)
        //            if (teamPlayer.Player == this)
        //                playerTeamList.Add(teamPlayer);
        //        return playerTeamList;
        //    }
    }

    //public List<Team> Teams
    //{
    //    get
    //    {
    //        var teamList = new List<Team>();
    //        foreach (var teamPlayer in PlayerInTeam.Items.Values)
    //            if (teamPlayer.Player == this)
    //                teamList.Add(teamPlayer.Team);
    //        return teamList;
    //    }
    //}

    //public List<Game> Games
    //{
    //    get
    //    {
    //        var playerGameList = new List<Game>();
    //        foreach (var playerGame in PlayerInGame.Items.Values)
    //            if (playerGame.Player == this)
    //                playerGameList.Add(playerGame.Game);
    //        return playerGameList;
    //    }
    //}

    //public static void SetDataBase(IDataBase db)
    //{
    //    dataBase = db;
    //}



    //public Player UpdateProperties(string name, string stringNumber, string amplua, bool captainCheckbox)
    //{ 

    //}

    //[IsTested]
    //public void Save()
    //{
    //    if ( dataBase != null )
    //    {
    //        dataBase.CreatePlayer( this );
    //    }
    //}

    //[IsTested]
    //public Player Read()
    //{
    //    return dataBase.ReadPlayer( this.Id );
    //}

    //[IsTested]
    //public void Update()
    //{
    //    dataBase.UpdatePlayer( this );
    //}

    //[IsTested]
    //public void Delete()
    //{
    //    dataBase.DeletePlayer( this );
    //    Player.Items.Remove( this.Id );
    //}
}
//}
