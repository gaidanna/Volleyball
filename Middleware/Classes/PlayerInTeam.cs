using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware;
using System.Runtime.Serialization;
using Volleyball.Attributes;

namespace Middleware
{
    [DataContract]
    public class PlayerInTeam : Base
    {
        //private DataRow row;
        //public static Dictionary<Guid, PlayerInTeam> Items = new Dictionary<Guid, PlayerInTeam>();
        static PlayerInTeam()
        {
            //dataBase = new ExternalDataBase();
            //TableInform.TryCreateTable( "PlayerInTeams" , GetRowNames );
        }

        private static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, PlayerId uniqueidentifier, TeamId uniqueidentifier, PRIMARY KEY (Id) )";
        }

        public PlayerInTeam( Team team , Player player )
            : base()
        {
            //Items.Add(Id, this);
            //row = table.Table.NewRow();
            teamId = team.Id;
            playerId = player.Id;
        }

         [IsInTable]
        [DataMember]
        private Guid playerId;

         [IsInTable]
        [DataMember]
        private Guid teamId;

         //[DataMember]
         //public Team Team
         //{
         //    get
         //    {
         //        return Team.Items[teamid];
         //    }
         //    set
         //    {
         //        teamid = value.Id;
         //    }
         //}

         //[DataMember]
         //public Player Player
         //{
         //    get
         //    {
         //        return Player.Items[playerId];
         //    }
         //    set
         //    {
         //        playerId = value.Id;
         //    }
         //}

        //public new void Save()
        //{
        //    Team.Save();
        //    Player.Save();
        //    base.Save();
        //}
    }
}
