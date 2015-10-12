﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Middleware.VolleyballService {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TablesNames", Namespace="http://schemas.datacontract.org/2004/07/Middleware")]
    public enum TablesNames : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Players = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Teams = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Games = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PlayerInGames = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PlayerInTeams = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Gender", Namespace="http://schemas.datacontract.org/2004/07/Middleware")]
    public enum Gender : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Male = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Female = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NotSpecified = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayersInfo", Namespace="http://schemas.datacontract.org/2004/07/Middleware")]
    public enum PlayersInfo : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BestPlayer = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        YellowCard = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RedCard = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VolleyballService.IVolleyballService")]
    public interface IVolleyballService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/Insert", ReplyAction="http://tempuri.org/IVolleyballService/InsertResponse")]
        void Insert(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/Insert", ReplyAction="http://tempuri.org/IVolleyballService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/Delete", ReplyAction="http://tempuri.org/IVolleyballService/DeleteResponse")]
        void Delete(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/Delete", ReplyAction="http://tempuri.org/IVolleyballService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/Update", ReplyAction="http://tempuri.org/IVolleyballService/UpdateResponse")]
        void Update(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/Update", ReplyAction="http://tempuri.org/IVolleyballService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/Read", ReplyAction="http://tempuri.org/IVolleyballService/ReadResponse")]
        System.Collections.Generic.Dictionary<string, string> Read(System.Guid Id, Middleware.VolleyballService.TablesNames tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/Read", ReplyAction="http://tempuri.org/IVolleyballService/ReadResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>> ReadAsync(System.Guid Id, Middleware.VolleyballService.TablesNames tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadAll", ReplyAction="http://tempuri.org/IVolleyballService/ReadAllResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadAll(Middleware.VolleyballService.TablesNames tableName, Middleware.VolleyballService.Gender gender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadAll", ReplyAction="http://tempuri.org/IVolleyballService/ReadAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadAllAsync(Middleware.VolleyballService.TablesNames tableName, Middleware.VolleyballService.Gender gender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadPlayers_Team", ReplyAction="http://tempuri.org/IVolleyballService/ReadPlayers_TeamResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadPlayers_Team(System.Guid teamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadPlayers_Team", ReplyAction="http://tempuri.org/IVolleyballService/ReadPlayers_TeamResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadPlayers_TeamAsync(System.Guid teamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadGames_Team", ReplyAction="http://tempuri.org/IVolleyballService/ReadGames_TeamResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadGames_Team(System.Guid teamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadGames_Team", ReplyAction="http://tempuri.org/IVolleyballService/ReadGames_TeamResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadGames_TeamAsync(System.Guid teamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadTeams_Player", ReplyAction="http://tempuri.org/IVolleyballService/ReadTeams_PlayerResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadTeams_Player(System.Guid playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadTeams_Player", ReplyAction="http://tempuri.org/IVolleyballService/ReadTeams_PlayerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadTeams_PlayerAsync(System.Guid playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadGames_Player", ReplyAction="http://tempuri.org/IVolleyballService/ReadGames_PlayerResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadGames_Player(System.Guid playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadGames_Player", ReplyAction="http://tempuri.org/IVolleyballService/ReadGames_PlayerResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadGames_PlayerAsync(System.Guid playerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadTeams_Game", ReplyAction="http://tempuri.org/IVolleyballService/ReadTeams_GameResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadTeams_Game(System.Guid gameId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadTeams_Game", ReplyAction="http://tempuri.org/IVolleyballService/ReadTeams_GameResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadTeams_GameAsync(System.Guid gameId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadPlaeyrs_Game", ReplyAction="http://tempuri.org/IVolleyballService/ReadPlaeyrs_GameResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadPlaeyrs_Game(System.Guid gameId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadPlaeyrs_Game", ReplyAction="http://tempuri.org/IVolleyballService/ReadPlaeyrs_GameResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadPlaeyrs_GameAsync(System.Guid gameId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/IsIdentifiedDuplicate", ReplyAction="http://tempuri.org/IVolleyballService/IsIdentifiedDuplicateResponse")]
        bool IsIdentifiedDuplicate(int number, System.Guid teamId, bool captain);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/IsIdentifiedDuplicate", ReplyAction="http://tempuri.org/IVolleyballService/IsIdentifiedDuplicateResponse")]
        System.Threading.Tasks.Task<bool> IsIdentifiedDuplicateAsync(int number, System.Guid teamId, bool captain);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/FindDuplicatedPlayers", ReplyAction="http://tempuri.org/IVolleyballService/FindDuplicatedPlayersResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> FindDuplicatedPlayers(int number, System.Guid teamId, bool captain);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/FindDuplicatedPlayers", ReplyAction="http://tempuri.org/IVolleyballService/FindDuplicatedPlayersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> FindDuplicatedPlayersAsync(int number, System.Guid teamId, bool captain);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/TryCreateTable", ReplyAction="http://tempuri.org/IVolleyballService/TryCreateTableResponse")]
        void TryCreateTable(string table, System.Func<string> getRowNames);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/TryCreateTable", ReplyAction="http://tempuri.org/IVolleyballService/TryCreateTableResponse")]
        System.Threading.Tasks.Task TryCreateTableAsync(string table, System.Func<string> getRowNames);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadPlayersInfoInGame", ReplyAction="http://tempuri.org/IVolleyballService/ReadPlayersInfoInGameResponse")]
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadPlayersInfoInGame(System.Guid gameId, Middleware.VolleyballService.PlayersInfo playersInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/ReadPlayersInfoInGame", ReplyAction="http://tempuri.org/IVolleyballService/ReadPlayersInfoInGameResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadPlayersInfoInGameAsync(System.Guid gameId, Middleware.VolleyballService.PlayersInfo playersInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/SaveImage", ReplyAction="http://tempuri.org/IVolleyballService/SaveImageResponse")]
        void SaveImage(byte[] bytes, string file);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVolleyballService/SaveImage", ReplyAction="http://tempuri.org/IVolleyballService/SaveImageResponse")]
        System.Threading.Tasks.Task SaveImageAsync(byte[] bytes, string file);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVolleyballServiceChannel : Middleware.VolleyballService.IVolleyballService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VolleyballServiceClient : System.ServiceModel.ClientBase<Middleware.VolleyballService.IVolleyballService>, Middleware.VolleyballService.IVolleyballService {
        
        public VolleyballServiceClient() {
        }
        
        public VolleyballServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VolleyballServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VolleyballServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VolleyballServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Insert(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName) {
            base.Channel.Insert(dictionary, tableName);
        }
        
        public System.Threading.Tasks.Task InsertAsync(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName) {
            return base.Channel.InsertAsync(dictionary, tableName);
        }
        
        public void Delete(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName) {
            base.Channel.Delete(dictionary, tableName);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName) {
            return base.Channel.DeleteAsync(dictionary, tableName);
        }
        
        public void Update(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName) {
            base.Channel.Update(dictionary, tableName);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(System.Collections.Generic.Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName) {
            return base.Channel.UpdateAsync(dictionary, tableName);
        }
        
        public System.Collections.Generic.Dictionary<string, string> Read(System.Guid Id, Middleware.VolleyballService.TablesNames tableName) {
            return base.Channel.Read(Id, tableName);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, string>> ReadAsync(System.Guid Id, Middleware.VolleyballService.TablesNames tableName) {
            return base.Channel.ReadAsync(Id, tableName);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadAll(Middleware.VolleyballService.TablesNames tableName, Middleware.VolleyballService.Gender gender) {
            return base.Channel.ReadAll(tableName, gender);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadAllAsync(Middleware.VolleyballService.TablesNames tableName, Middleware.VolleyballService.Gender gender) {
            return base.Channel.ReadAllAsync(tableName, gender);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadPlayers_Team(System.Guid teamId) {
            return base.Channel.ReadPlayers_Team(teamId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadPlayers_TeamAsync(System.Guid teamId) {
            return base.Channel.ReadPlayers_TeamAsync(teamId);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadGames_Team(System.Guid teamId) {
            return base.Channel.ReadGames_Team(teamId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadGames_TeamAsync(System.Guid teamId) {
            return base.Channel.ReadGames_TeamAsync(teamId);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadTeams_Player(System.Guid playerId) {
            return base.Channel.ReadTeams_Player(playerId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadTeams_PlayerAsync(System.Guid playerId) {
            return base.Channel.ReadTeams_PlayerAsync(playerId);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadGames_Player(System.Guid playerId) {
            return base.Channel.ReadGames_Player(playerId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadGames_PlayerAsync(System.Guid playerId) {
            return base.Channel.ReadGames_PlayerAsync(playerId);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadTeams_Game(System.Guid gameId) {
            return base.Channel.ReadTeams_Game(gameId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadTeams_GameAsync(System.Guid gameId) {
            return base.Channel.ReadTeams_GameAsync(gameId);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadPlaeyrs_Game(System.Guid gameId) {
            return base.Channel.ReadPlaeyrs_Game(gameId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadPlaeyrs_GameAsync(System.Guid gameId) {
            return base.Channel.ReadPlaeyrs_GameAsync(gameId);
        }
        
        public bool IsIdentifiedDuplicate(int number, System.Guid teamId, bool captain) {
            return base.Channel.IsIdentifiedDuplicate(number, teamId, captain);
        }
        
        public System.Threading.Tasks.Task<bool> IsIdentifiedDuplicateAsync(int number, System.Guid teamId, bool captain) {
            return base.Channel.IsIdentifiedDuplicateAsync(number, teamId, captain);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> FindDuplicatedPlayers(int number, System.Guid teamId, bool captain) {
            return base.Channel.FindDuplicatedPlayers(number, teamId, captain);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> FindDuplicatedPlayersAsync(int number, System.Guid teamId, bool captain) {
            return base.Channel.FindDuplicatedPlayersAsync(number, teamId, captain);
        }
        
        public void TryCreateTable(string table, System.Func<string> getRowNames) {
            base.Channel.TryCreateTable(table, getRowNames);
        }
        
        public System.Threading.Tasks.Task TryCreateTableAsync(string table, System.Func<string> getRowNames) {
            return base.Channel.TryCreateTableAsync(table, getRowNames);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ReadPlayersInfoInGame(System.Guid gameId, Middleware.VolleyballService.PlayersInfo playersInfo) {
            return base.Channel.ReadPlayersInfoInGame(gameId, playersInfo);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>> ReadPlayersInfoInGameAsync(System.Guid gameId, Middleware.VolleyballService.PlayersInfo playersInfo) {
            return base.Channel.ReadPlayersInfoInGameAsync(gameId, playersInfo);
        }
        
        public void SaveImage(byte[] bytes, string file) {
            base.Channel.SaveImage(bytes, file);
        }
        
        public System.Threading.Tasks.Task SaveImageAsync(byte[] bytes, string file) {
            return base.Channel.SaveImageAsync(bytes, file);
        }
    }
}
