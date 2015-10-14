using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Middleware;

namespace Middleware
{
    [DataContract]
    public class Serialization : IDataBase
    {

        //[DataMember]
        //public List<Player> Players
        //{
        //    get { return Player.Items.Values.ToList(); }
        //    set
        //    {
        //        var tmp = new Dictionary<Guid, Player>();
        //        foreach (var item in value)
        //            tmp.Add(item.Id, item);
        //        Player.Items = tmp;
        //    }
        //}

        //[DataMember]
        //public List<Team> Teams
        //{
        //    get { return Team.Items.Values.ToList(); }
        //    set
        //    {
        //        var tmp = new Dictionary<Guid, Team>();
        //        foreach (var item in value)
        //            tmp.Add(item.Id, item);
        //        Team.Items = tmp;
        //    }
        //}

        //[DataMember]
        //public List<Game> Games
        //{
        //    get { return Game.Items.Values.ToList(); }
        //    set
        //    {
        //        var tmp = new Dictionary<Guid, Game>();
        //        foreach (var item in value)
        //            tmp.Add(item.Id, item);
        //        Game.Items = tmp;
        //    }
        //}

        internal static void Save()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(Serialization));
            XmlWriter xmlw = XmlWriter.Create("DB.xml");
            dcs.WriteObject(xmlw, new Serialization());
            xmlw.Close();
        }

        internal static void Load()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(Serialization));
            XmlReader xmlr = XmlReader.Create("DB.xml");
            dcs.ReadObject(xmlr);
            xmlr.Close();
        }

        public void CreateGame(Game game)
        {

            //DataContractSerializer dcs = new DataContractSerializer(typeof(Game));
            //XmlWriter xmlw = XmlWriter.Create("DB.xml");
            //dcs.WriteObject(xmlw, new Game());
            //xmlw.Close();
            
            //string path;
            //XmlSerializer writer;

            //writer = new XmlSerializer(typeof(Game));
            //path = String.Format(@"C:\Users\Anna\Desktop\xml\{0}.xml", gameInfo.Id);
            
            //using (StreamWriter file = new StreamWriter(path))
            //{
            //    writer.Serialize(file, gameInfo);
            //}
        }

        //public Game ReadGame(Guid id)
        //{
        //    //string path;
        //    //Game gameInfo;
        //    //XmlSerializer reader;

        //    //gameInfo = new Game();
        //    //path = String.Format(@"C:\Users\Anna\Desktop\xml\{0}.xml", id);
        //    //reader = new XmlSerializer(typeof(Game));

        //    //using (StreamReader file = new StreamReader(path))
        //    //{
        //    //    gameInfo = (Game)reader.Deserialize(file);
        //    //}
        //    //return gameInfo;
        //    return new Game(("2", "2", "2", "3", DateTime.Now, new int[,]{ {2,2} });
        //}
        public void UpdateGame(Game game)
        {  
            //w/o implementation  
        }
        public void DeleteGame(Game game)
        {
            //w/o implementation
        }

        public void CreateTeam(Team team)
        {
            // w/o implementation
        }

        //public Team ReadTeam(Guid guid)
        //{
        //    return new Team("n/a");
        //}

        public void UpdateTeam(Team team)
        {
            // w/o implementation
        }

        public void DeleteTeam(Team team)
        {
            // w/o implementation
        }

        public void CreatePlayer(Player player)
        {
            // w/o implementation
        }

        public Player ReadPlayer(Guid guid)
        {
            return new Player("n/a", -1, "a", false, "female");
        }

        public void UpdatePlayer(Player player)
        {
            // w/o implementation
        }

        public void DeletePlayer(Player player)
        {
            // w/o implementation
        }

        

        //public static GameInfo ReadXML()
        //{
        //    XmlSerializer reader =
        //        new XmlSerializer(typeof(GameInfo));
        //    StreamReader file = new StreamReader(
        //        @"C:\Users\Anna\Desktop\xml\SerializationOverview.xml");
        //    GameInfo gameInfo = new GameInfo();

        //    gameInfo = (GameInfo)reader.Deserialize(file);

        //    return gameInfo;
        //    //Console.WriteLine(overview.title);

        //}

    }
}
