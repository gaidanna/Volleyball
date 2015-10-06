using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware;
using System.Runtime.Serialization;
using Volleyball.Attributes;
using Middleware.VolleyballService;

namespace Middleware
{
    [DataContract]
    public class PlayerInGame : Base
    {
        private static VolleyballServiceClient client = new VolleyballServiceClient();

        static PlayerInGame()
        {
            //TableInform.TryCreateTable( "PlayerInGames" , GetRowNames );
        }

        public static string GetRowNames()
        {
            return "( Id uniqueidentifier NOT NULL, PlayerId uniqueidentifier, GameId uniqueidentifier, BestPlayer bit NOT NULL, YellowCard bit NOT NULL, RedCard bit NOT NULL, PRIMARY KEY (Id) )";
        }

        public PlayerInGame(Player player, bool bestPlayer, bool yellowCard, bool redCard, Game game)
            : base()
        {
            //Items.Add(Id, this);
            //row = table.Table.NewRow();
            this.gameId = game.Id;
            this.playerId = player.Id;
            this.bestPlayer = bestPlayer;
            this.yellowCard = yellowCard;
            this.redCard = redCard;
        }

        public PlayerInGame(Dictionary<string, string> fieldsDict)
        {
            try
            {
                this.Id = new Guid( fieldsDict[ "Id" ] );
                this.playerId = new Guid( fieldsDict[ "PlayerId" ] );
                this.gameId = new Guid( fieldsDict[ "GameId" ] );
                this.bestPlayer = Convert.ToBoolean(fieldsDict[ "BestPlayer" ]);
                this.yellowCard = Convert.ToBoolean(fieldsDict["YellowCard"]);
                this.redCard = Convert.ToBoolean(fieldsDict["RedCard"]);
            }
            catch
            { }
        }

         [IsInTable]
        [DataMember]
        private Guid playerId;

         [IsInTable]
         [DataMember]
         private bool bestPlayer;

         [IsInTable]
         [DataMember]
         private bool yellowCard;

         [IsInTable]
         [DataMember]
         private bool redCard;

         [IsInTable]
        [DataMember]
        private Guid gameId;

         [DataMember]
         public Player Player
         {
             get
             {
                 var playerDict = client.Read(playerId, VolleyballService.TablesNames.Players);
                 return new Player(playerDict);
             }
         }

         [DataMember]
         public Game Game
         {
             get
             {
                 var playerDict = client.Read(gameId, VolleyballService.TablesNames.Games);
                 return new Game(playerDict);
             }
         }
    }
}
