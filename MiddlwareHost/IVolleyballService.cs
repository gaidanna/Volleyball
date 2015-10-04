using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Middleware;

namespace MiddlewareHost
{
    //[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IVolleyballService))]
    [ServiceContract]
    public interface IVolleyballService
    {
        [OperationContract]
        void Insert(Dictionary<string, string> dictionary, TablesNames tableName);

        [OperationContract]
        void Delete(Dictionary<string, string> dictionary, TablesNames tableName);

        [OperationContract]
        void Update(Dictionary<string, string> dictionary, TablesNames tableName);

        [OperationContract]
        Dictionary<string, string> Read(Guid Id, TablesNames tableName);

        [OperationContract]
        List<Dictionary<string, string>> ReadAll(TablesNames tableName, Gender gender);

        [OperationContract]
        List<Dictionary<string, string>> ReadPlayers_Team(Guid teamId);

        [OperationContract]
        List<Dictionary<string, string>> ReadGames_Team(Guid teamId);

        [OperationContract]
        List<Dictionary<string, string>> ReadTeams_Player(Guid playerId);

        [OperationContract]
        List<Dictionary<string, string>> ReadGames_Player(Guid playerId);

        [OperationContract]
        List<Dictionary<string, string>> ReadTeams_Game(Guid gameId);

        [OperationContract]
        List<Dictionary<string, string>> ReadPlaeyrs_Game(Guid gameId);

        [OperationContract]
        bool IsIdentifiedDuplicate(int number, Guid teamId, bool captain);
        
        [OperationContract]
        List<Dictionary<string, string>> FindDuplicatedPlayers(int number, Guid teamId, bool captain);
        
        [OperationContract]
        void TryCreateTable(string table, Func<string> getRowNames);
    }    
}
