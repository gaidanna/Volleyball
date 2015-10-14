using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware;
using System.Runtime.Serialization;
using Volleyball.Attributes;
using System.Windows.Forms;

namespace Middleware
{
    [DataContract]
    public class PlayerInTeam : Base
    {
        [DataMember]
        private int year;

        [IsInTable]
        [DataMember]
        private Guid playerId;

        [IsInTable]
        [DataMember]
        private Guid teamId;

        public static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, PlayerId uniqueidentifier, TeamId uniqueidentifier, PRIMARY KEY (Id) )";
        }

        public PlayerInTeam( Team team , Player player, int year )
            : base()
        {
            this.teamId = team.Id;
            this.playerId = player.Id;
            this.year = year;
        }

        public PlayerInTeam(Dictionary<string, string> fieldsDict)
        {
            try
            {
                this.Id = new Guid(fieldsDict["Id"]);
                this.playerId = new Guid(fieldsDict["PlayerId"]);
                this.teamId = new Guid(fieldsDict["TeamId"]);
                this.year = Convert.ToInt32(fieldsDict["Year"]);
            }
            catch
            { 
                MessageBox.Show("Something went wrong.");
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
    }
}
