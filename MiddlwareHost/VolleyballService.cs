﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Data.Common;
using Middleware;

namespace MiddlewareHost
{
    public class VolleyballService : IVolleyballService
    {
        #region General methods
        public void Insert( Dictionary<string , string> dictionary , TablesNames tableName )
        {
            TableInform table;
            DbConnection connection;
            DataRow result;

            table = new TableInform( tableName.ToString() );
            connection = TableInform.Connection;
            result = table.ConvertDictToRow( dictionary );

            table.Table.Rows.Add( result );
            table.Update( new DataRow[] { result } );
        }

        public void Update( Dictionary<string , string> dictionary , TablesNames tableName )
        {
            TableInform table;
            DbConnection connection;
            string IdValue;
            DataRow row;

            IdValue = null;
            table = new TableInform( tableName.ToString() );
            connection = TableInform.Connection;
            table.Table.PrimaryKey = new DataColumn[] { table.Table.Columns[ "Id" ] };

            if ( dictionary.TryGetValue( "Id" , out IdValue ) )
            {
                row = table.Table.Rows.Find( IdValue );
                foreach ( KeyValuePair<string , string> pair in dictionary )
                {
                    row[ pair.Key ] = pair.Value;
                }

                table.Update( new DataRow[] { row } );
            }
        }

        public void Delete( Dictionary<string , string> dictionary , TablesNames tableName )
        {
            TableInform table;
            DbConnection connection;
            DataRow row;
            string IdValue;

            IdValue = null;
            table = new TableInform( tableName.ToString() );
            table.Table.PrimaryKey = new DataColumn[] { table.Table.Columns[ "Id" ] };
            connection = TableInform.Connection;

            if ( dictionary.TryGetValue( "Id" , out IdValue ) )
            {
                row = table.Table.Rows.Find( IdValue );
                row.Delete();
                table.Update( new DataRow[] { row } );
            }
        }

        public Dictionary<string , string> Read( Guid Id , TablesNames tableName )
        {
            TableInform table;
            DbConnection connection;
            DataRow result;

            connection = TableInform.Connection;
            table = new TableInform( tableName.ToString() );

            DataRow dr = table.Table.AsEnumerable().SingleOrDefault( r => r.Field<Guid>( "ID" ) == Id );
            var dict = table.ConvertRowToDict( dr );
            return dict;
        }

        public List<Dictionary<string , string>> ReadAll( TablesNames tableName , Gender gender )
        {
            TableInform table;
            DbConnection connection;
            DataRow[] rows;
            List<Dictionary<string , string>> resultedList;

            connection = TableInform.Connection;
            resultedList = new List<Dictionary<string , string>>();
            table = new TableInform( tableName.ToString() );

            if ( gender == Gender.NotSpecified )
            {
                rows = table.Table.Select();
            }
            else
            {
                string param = String.Format( "LEAGUE = '{0}'" , gender.ToString() );
                rows = table.Table.Select( param );
            }

            foreach ( var row in rows )
            {
                var result = table.ConvertRowToDict( row );
                resultedList.Add( result );
            }
            return resultedList;
        }
        #endregion

        #region Team+
        public List<Dictionary<string , string>> ReadPlayers_Team( Guid teamId )
        {
            DbConnection connection;
            List<Guid> playerIds;
            List<Dictionary<string , string>> resultedList;

            resultedList = new List<Dictionary<string , string>>();
            connection = TableInform.Connection;

            playerIds = GetPlayersByTeamId( TablesNames.PlayerInTeams , teamId );
            resultedList = ReadByIds( TablesNames.Players , playerIds );

            return resultedList;
        }

        public List<Dictionary<string , string>> ReadGames_Team( Guid teamId )
        {
            DbConnection connection;
            List<Guid> gameIds;
            List<Dictionary<string , string>> resultedList;

            resultedList = new List<Dictionary<string , string>>();
            connection = TableInform.Connection;

            gameIds = GetGamesByTeamId( TablesNames.Games , teamId );
            resultedList = ReadByIds( TablesNames.Games , gameIds );

            return resultedList;
        }
        #endregion

        #region Player+
        public List<Dictionary<string , string>> ReadTeams_Player( Guid playerId )
        {
            DbConnection connection;
            List<Guid> teamIds;
            List<Dictionary<string , string>> resultedList;

            resultedList = new List<Dictionary<string , string>>();
            connection = TableInform.Connection;

            teamIds = GetInfoByPlayerId( TablesNames.PlayerInTeams , playerId );
            resultedList = ReadByIds( TablesNames.Teams , teamIds );

            return resultedList;
        }

        public List<Dictionary<string , string>> ReadGames_Player( Guid playerId )
        {
            DbConnection connection;
            List<Guid> gameIds;
            List<Dictionary<string , string>> resultedList;

            resultedList = new List<Dictionary<string , string>>();
            connection = TableInform.Connection;

            gameIds = GetInfoByPlayerId( TablesNames.PlayerInGames , playerId );
            resultedList = ReadByIds( TablesNames.Games , gameIds );

            return resultedList;
        }
        #endregion

        #region
        public List<Dictionary<string , string>> ReadTeams_Game( Guid gameId )
        {
            DbConnection connection;
            List<Guid> teamIds;
            List<Dictionary<string , string>> resultedList;

            resultedList = new List<Dictionary<string , string>>();
            connection = TableInform.Connection;

            teamIds = GetTeamsByGameId( TablesNames.Games , gameId );
            resultedList = ReadByIds( TablesNames.Teams , teamIds );

            return resultedList;
        }

        public List<Dictionary<string , string>> ReadPlaeyrs_Game( Guid gameId )
        {
            DbConnection connection;
            List<Guid> playerIds;
            List<Dictionary<string , string>> resultedList;

            resultedList = new List<Dictionary<string , string>>();
            connection = TableInform.Connection;

            playerIds = GetPlayersByGameId( TablesNames.PlayerInGames , gameId );
            resultedList = ReadByIds( TablesNames.Players , playerIds );

            return resultedList;
        }
        #endregion

        //player
        private List<Guid> GetInfoByPlayerId( TablesNames tableName , Guid playerId )
        {
            TableInform table;

            table = new TableInform( tableName.ToString() );
            string param = ( tableName.ToString().Substring( 8 , 4 ) + "Id" );

            var res = ( from r in table.Table.AsEnumerable()
                        where r.Field<Guid>( "PlayerId" ) == playerId
                        select r.Field<Guid>( param ) ).ToList();
            //var res = (from DataRow r in table.Table.Rows select r["Id"].Equals(playerId.ToString())).ToList();
            return res;
            //table.Table.AsEnumerable().Where(row => row.Field<Guid>["PlayerId"] == playerId);//.Where(id => id == playerId.ToString()).ToList();
        }

        //team
        private List<Guid> GetPlayersByTeamId( TablesNames tableName , Guid teamId )
        {
            TableInform table;

            table = new TableInform( tableName.ToString() );

            var res = ( from r in table.Table.AsEnumerable()
                        where r.Field<Guid>( "TeamId" ) == teamId
                        select r.Field<Guid>( "PlayerId" ) ).ToList();
            return res;
            // return table.Table.Select(row => row["TeamId"]).Where(id => id == teamId.ToString()).ToList();
            //return table.Table.AsEnumerable().Select(row => row["TeamId"] == teamId.ToString()).ToList();
        }

        //team
        private List<Guid> GetGamesByTeamId( TablesNames tableName , Guid teamId )
        {
            TableInform table;
            List<Dictionary<string , string>> resultedList;

            resultedList = new List<Dictionary<string , string>>();
            table = new TableInform( tableName.ToString() );

            var res = ( from r in table.Table.AsEnumerable()
                        where r.Field<Guid>( "TeamOneId" ) == teamId || r.Field<Guid>( "TeamTwoId" ) == teamId
                        select r.Field<Guid>( "Id" ) ).ToList();

            // var result = table.ConvertRowToDict(res);
            //return result;
            return res;
        }

        //game
        private List<Guid> GetPlayersByGameId( TablesNames tableName , Guid gameId )
        {
            TableInform table;

            table = new TableInform( tableName.ToString() );

            var res = ( from r in table.Table.AsEnumerable()
                        where r.Field<Guid>( "GameId" ) == gameId
                        select r.Field<Guid>( "PlayerId" ) ).ToList();
            return res;
            //return table.Table.Select(row => row["GameId"]).Where(id => id == gameId.ToString()).ToList();
        }
        //game
        private List<Guid> GetTeamsByGameId( TablesNames tableName , Guid gameId )
        {
            TableInform table;

            table = new TableInform( tableName.ToString() );

            var res = ( from r in table.Table.AsEnumerable()
                        where r.Field<Guid>( "Id" ) == gameId
                        //select r.Field<Guid>("TeamOneId") && r.Field<Guid>("TeamTwoId")).ToList();
                        select r ).SingleOrDefault();
            List<Guid> result = new List<Guid>();
            result.Add( ( Guid ) res[ "TeamOneId" ] );
            result.Add( ( Guid ) res[ "TeamTwoId" ] );
            //.ToList();// && r.Field<string>("TeamTwoId")

            //select r.Field<string>("PlayerId")).ToList();
            return result;
            //return table.Table.Select(row => row["GameId"]).Where(id => id == gameId.ToString()).ToList();
        }

        private List<Dictionary<string , string>> ReadByIds( TablesNames tableName , List<Guid> idList )
        {
            TableInform table;
            //DataRow row;
            List<Dictionary<string , string>> resultedList;

            resultedList = new List<Dictionary<string , string>>();
            table = new TableInform( tableName.ToString() );

            foreach ( var id in idList )
            {
                var row = ( from r in table.Table.AsEnumerable()
                            where r.Field<Guid>( "Id" ) == id
                            select r ).SingleOrDefault();

                var result = table.ConvertRowToDict( row );
                resultedList.Add( result );
            }
            return resultedList;
        }
    }
}