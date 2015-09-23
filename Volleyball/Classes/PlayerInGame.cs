using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware;
using System.Runtime.Serialization;
using Volleyball.Attributes;

namespace Volleyball.Classes
{
    [DataContract]
    public class PlayerInGame : Base
    {
        static PlayerInGame()
        {
            TableInform.TryCreateTable( "PlayerInGames" , GetRowNames );
        }

        private static string GetRowNames()
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

        //[DataMember]
        // public Game Game
        // {
        //     get
        //     {
        //         return game;
        //     }
        //     set
        //     {
        //         Game.Id = value.Id;
        //         //gameId = value.Id;
        //     }
        // }

        //[DataMember]
        //public Player Player
        //{
        //    get
        //    {
        //        return playerId;
        //    }
        //    set
        //    {
        //        playerId = value.Id;
        //    }
        //}
    }
}
