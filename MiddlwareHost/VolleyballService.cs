using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Data.Common;
using Middleware;
using System.Data.SqlClient;

namespace MiddlewareHost
{
    public class VolleyballService : IVolleyballService
    {
        #region General methods
        public void Insert(Dictionary<string, string> dictionary, TablesNames tableName)
        {
            TableInform table;
            DbConnection connection;
            DataRow result;

            table = new TableInform(tableName.ToString());
            connection = TableInform.Connection;
            result = table.ConvertDictToRow(dictionary);

            table.Table.Rows.Add(result);
            table.Update(new DataRow[] { result });
        }

        public void Update(Dictionary<string, string> dictionary, TablesNames tableName)
        {
            TableInform table;
            DbConnection connection;
            string IdValue;
            DataRow row;

            IdValue = null;
            table = new TableInform(tableName.ToString());
            connection = TableInform.Connection;
            table.Table.PrimaryKey = new DataColumn[] { table.Table.Columns["Id"] };

            if (dictionary.TryGetValue("Id", out IdValue))
            {
                row = table.Table.Rows.Find(IdValue);
                foreach (KeyValuePair<string, string> pair in dictionary)
                {
                    row[pair.Key] = pair.Value;
                }

                table.Update(new DataRow[] { row });
            }
        }

        public void Delete(Dictionary<string, string> dictionary, TablesNames tableName)
        {
            TableInform table;
            DbConnection connection;
            DataRow row;
            string IdValue;

            IdValue = null;
            table = new TableInform(tableName.ToString());
            table.Table.PrimaryKey = new DataColumn[] { table.Table.Columns["Id"] };
            connection = TableInform.Connection;

            if (dictionary.TryGetValue("Id", out IdValue))
            {
                row = table.Table.Rows.Find(IdValue);
                row.Delete();
                table.Update(new DataRow[] { row });
            }
        }

        public Dictionary<string, string> Read(Guid Id, TablesNames tableName)
        {
            TableInform table;
            DbConnection connection;
            DataRow result;

            connection = TableInform.Connection;
            table = new TableInform(tableName.ToString());

            DataRow dr = table.Table.AsEnumerable().SingleOrDefault(r => r.Field<Guid>("ID") == Id);
            var dict = table.ConvertRowToDict(dr);
            return dict;
        }

        public List<Dictionary<string, string>> ReadAll(TablesNames tableName, Gender gender)
        {
            TableInform table;
            DbConnection connection;
            DataRow[] rows;
            List<Dictionary<string, string>> resultedList;

            connection = TableInform.Connection;
            resultedList = new List<Dictionary<string, string>>();
            table = new TableInform(tableName.ToString());

            if (gender == Gender.NotSpecified)
            {
                rows = table.Table.Select();
            }
            else
            {
                string param = String.Format("LEAGUE = '{0}'", gender.ToString());
                rows = table.Table.Select(param);
            }

            foreach (var row in rows)
            {
                var result = table.ConvertRowToDict(row);
                resultedList.Add(result);
            }
            return resultedList;
        }

        public List<Dictionary<string, string>> ReadPlayerStatisticsInGames(Guid playerId, PlayersInfo playersInfo)
        {
            TableInform table;
            DbConnection connection;
            //List<DataRow> rows;
            List<Dictionary<string, string>> resultedList;

            connection = TableInform.Connection;
            resultedList = new List<Dictionary<string, string>>();
            table = new TableInform(TablesNames.PlayerInGames.ToString());

            //if (playersInfo == PlayersInfo.BestPlayer)
            //{
            var rows = table.Table.AsEnumerable().Where(r => r.Field<Guid>("PlayerId") == playerId && r.Field<bool>(playersInfo.ToString()) == true).Select(r => r.Field<Guid>("gameId")).ToList();
            resultedList = ReadByIds(TablesNames.Games, rows);
            //}
            //else if (playersInfo == PlayersInfo.YellowCard)
            //{
            //    var rows = table.Table.AsEnumerable().Where(r => r.Field<Guid>("playerId") == playerId && r.Field<bool>("YellowCard") == true).Select(r => r.Field<Guid>("PlayerId")).ToList();
            //    resultedList = ReadByIds(TablesNames.Players, rows);
            //}
            //else if (playersInfo == PlayersInfo.RedCard)
            //{
            //    var rows = table.Table.AsEnumerable().Where(r => r.Field<Guid>("playerId") == playerId && r.Field<bool>("RedCard") == true).Select(r => r.Field<Guid>("PlayerId")).ToList();
            //    resultedList = ReadByIds(TablesNames.Players, rows);
            //}
            return resultedList;
        }

        public List<Dictionary<string, string>> ReadPlayersInfoInGame(Guid gameId, PlayersInfo playersInfo)
        {
            TableInform table;
            DbConnection connection;
            //List<DataRow> rows;
            List<Dictionary<string, string>> resultedList;

            connection = TableInform.Connection;
            resultedList = new List<Dictionary<string, string>>();
            table = new TableInform(TablesNames.PlayerInGames.ToString());

            //if (playersInfo == PlayersInfo.BestPlayer)
            //{
                var rows = table.Table.AsEnumerable().Where(r => r.Field<Guid>("gameId") == gameId && r.Field<bool>(playersInfo.ToString()) == true).Select(r => r.Field<Guid>("PlayerId")).ToList();
                resultedList = ReadByIds(TablesNames.Players, rows);
                //foreach (var row in rows)
                //{ 
                //    //var result = table.ConvertRowToDict(row);
                //    //resultedList.Add(result);
                //}
            //}
            //else if (playersInfo == PlayersInfo.YellowCard)
            //{
            //    var rows = table.Table.AsEnumerable().Where(r => r.Field<Guid>("gameId") == gameId && r.Field<bool>("YellowCard") == true).Select(r => r.Field<Guid>("PlayerId")).ToList();
            //    resultedList = ReadByIds(TablesNames.Players, rows);
            //    //foreach (var row in rows)
            //    //{
            //    //    var result = table.ConvertRowToDict(row);
            //    //    resultedList.Add(result);
            //    //}
            //}
            //else if (playersInfo == PlayersInfo.RedCard)
            //{
            //    var rows = table.Table.AsEnumerable().Where(r => r.Field<Guid>("gameId") == gameId && r.Field<bool>("RedCard") == true).Select(r => r.Field<Guid>("PlayerId")).ToList();
            //    resultedList = ReadByIds(TablesNames.Players, rows);
            //    //foreach (var row in rows)
            //    //{
            //    //    var result = table.ConvertRowToDict(row);
            //    //    resultedList.Add(result);
            //    //}
            //}


            return resultedList;
        }
        #endregion

        #region Team+
        public List<Dictionary<string, string>> ReadPlayers_Team(Guid teamId)
        {
            DbConnection connection;
            List<Guid> playerIds;
            List<Dictionary<string, string>> resultedList;

            resultedList = new List<Dictionary<string, string>>();
            connection = TableInform.Connection;

            playerIds = GetPlayersByTeamId(TablesNames.PlayerInTeams, teamId);
            resultedList = ReadByIds(TablesNames.Players, playerIds);

            return resultedList;
        }

        public List<Dictionary<string, string>> ReadGames_Team(Guid teamId)
        {
            DbConnection connection;
            List<Guid> gameIds;
            List<Dictionary<string, string>> resultedList;

            resultedList = new List<Dictionary<string, string>>();
            connection = TableInform.Connection;

            gameIds = GetGamesByTeamId(TablesNames.Games, teamId);
            resultedList = ReadByIds(TablesNames.Games, gameIds);

            return resultedList;
        }
        #endregion

        #region Player+
        public List<Dictionary<string, string>> ReadTeams_Player(Guid playerId)
        {
            DbConnection connection;
            List<Guid> teamIds;
            List<Dictionary<string, string>> resultedList;

            resultedList = new List<Dictionary<string, string>>();
            connection = TableInform.Connection;

            teamIds = GetInfoByPlayerId(TablesNames.PlayerInTeams, playerId);
            resultedList = ReadByIds(TablesNames.Teams, teamIds);

            return resultedList;
        }

        public List<Dictionary<string, string>> ReadGames_Player(Guid playerId)
        {
            DbConnection connection;
            List<Guid> gameIds;
            List<Dictionary<string, string>> resultedList;

            resultedList = new List<Dictionary<string, string>>();
            connection = TableInform.Connection;

            gameIds = GetInfoByPlayerId(TablesNames.PlayerInGames, playerId);
            resultedList = ReadByIds(TablesNames.Games, gameIds);

            return resultedList;
        }

        #endregion

        #region
        public List<Dictionary<string, string>> ReadTeams_Game(Guid gameId)
        {
            DbConnection connection;
            List<Guid> teamIds;
            List<Dictionary<string, string>> resultedList;

            resultedList = new List<Dictionary<string, string>>();
            connection = TableInform.Connection;

            teamIds = GetTeamsByGameId(TablesNames.Games, gameId);
            resultedList = ReadByIds(TablesNames.Teams, teamIds);

            return resultedList;
        }

        public List<Dictionary<string, string>> ReadPlaeyrs_Game(Guid gameId)
        {
            DbConnection connection;
            List<Guid> playerIds;
            List<Dictionary<string, string>> resultedList;

            resultedList = new List<Dictionary<string, string>>();
            connection = TableInform.Connection;

            playerIds = GetPlayersByGameId(TablesNames.PlayerInGames, gameId);
            resultedList = ReadByIds(TablesNames.Players, playerIds);

            return resultedList;
        }
        #endregion

        //player
        private List<Guid> GetInfoByPlayerId(TablesNames tableName, Guid playerId)
        {
            TableInform table;

            table = new TableInform(tableName.ToString());
            string param = (tableName.ToString().Substring(8, 4) + "Id");

            var res = (from r in table.Table.AsEnumerable()
                       where r.Field<Guid>("PlayerId") == playerId
                       select r.Field<Guid>(param)).ToList();
            return res;
        }

        //team
        private List<Guid> GetPlayersByTeamId(TablesNames tableName, Guid teamId)
        {
            TableInform table;

            table = new TableInform(tableName.ToString());

            var res = (from r in table.Table.AsEnumerable()
                       where r.Field<Guid>("TeamId") == teamId
                       select r.Field<Guid>("PlayerId")).ToList();
            return res;
        }

        //team
        private List<Guid> GetGamesByTeamId(TablesNames tableName, Guid teamId)
        {
            TableInform table;
            List<Dictionary<string, string>> resultedList;

            resultedList = new List<Dictionary<string, string>>();
            table = new TableInform(tableName.ToString());

            var res = (from r in table.Table.AsEnumerable()
                       where r.Field<Guid>("TeamOneId") == teamId || r.Field<Guid>("TeamTwoId") == teamId
                       select r.Field<Guid>("Id")).ToList();
            return res;
        }

        //game
        private List<Guid> GetPlayersByGameId(TablesNames tableName, Guid gameId)
        {
            TableInform table;

            table = new TableInform(tableName.ToString());

            var res = (from r in table.Table.AsEnumerable()
                       where r.Field<Guid>("GameId") == gameId
                       select r.Field<Guid>("PlayerId")).ToList();
            return res;
        }
        //game
        private List<Guid> GetTeamsByGameId(TablesNames tableName, Guid gameId)
        {
            TableInform table;

            table = new TableInform(tableName.ToString());

            var res = (from r in table.Table.AsEnumerable()
                       where r.Field<Guid>("Id") == gameId
                       select r).SingleOrDefault();
            List<Guid> result = new List<Guid>();
            result.Add((Guid)res["TeamOneId"]);
            result.Add((Guid)res["TeamTwoId"]);

            return result;
        }

        private List<Dictionary<string, string>> ReadByIds(TablesNames tableName, List<Guid> idList)
        {
            TableInform table;
            List<Dictionary<string, string>> resultedList;

            resultedList = new List<Dictionary<string, string>>();
            table = new TableInform(tableName.ToString());
            if (idList.Count > 0)
            {
                foreach (var id in idList)
                {
                    var row = (from r in table.Table.AsEnumerable()
                               where r.Field<Guid>("Id") == id
                               select r).SingleOrDefault();

                    var result = table.ConvertRowToDict(row);
                    resultedList.Add(result);
                }
                return resultedList;
            }
            return null;
        }

        public void TryCreateTable(string TableName, Func<string> getRowNames)
        {
            TableInform.TryCreateTable(TableName, getRowNames);
        }

        public bool IsIdentifiedDuplicate(int number, Guid teamId, bool captain)
        {
            var result = ReadPlayers_Team(teamId);
            if (result != null)
            {
                foreach (var item in result)
                {
                    if (!captain)
                    {
                        if (item["Number"] == number.ToString())
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (item["Number"] == number.ToString() || item["Captain"] == "true")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<Dictionary<string, string>> FindDuplicatedPlayers(int number, Guid teamId, bool captain)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> allPlayers = ReadPlayers_Team(teamId);
            if (allPlayers != null)
            {
                foreach (var item in allPlayers)
                {
                    if (!captain)
                    {
                        if (item["Number"] == number.ToString())
                        {
                            result.Add(item);
                        }
                    }
                    else
                    {
                        if (item["Number"] == number.ToString() || item["Captain"] == "true")
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public void SaveImage(byte[] bytes, string file)
        {
            DbConnection connection;
            connection = TableInform.Connection;

            string strQuery = "INSERT INTO FileStreamTest([Name], [Data]) VALUES (@Name, @Data)";
            SqlCommand command = new SqlCommand(strQuery);
            var parameter = new System.Data.SqlClient.SqlParameter("@Name",
                            System.Data.SqlDbType.NVarChar, 100);
            parameter.Value = file.Substring(file.LastIndexOf('\\') + 1);
            command.Parameters.Add(parameter);

            var parameter2 = new System.Data.SqlClient.SqlParameter("@Data",
                            System.Data.SqlDbType.VarBinary);
            parameter2.Value = bytes;
            command.Parameters.Add(parameter2);

            InsertUpdateData(command);

        }

        private Boolean InsertUpdateData(SqlCommand cmd)
        {
            //TableInform table;
            DbConnection connection;
            DataRow result;

            //table = new TableInform(tableName.ToString());
            connection = TableInform.Connection;
            //result = table.ConvertDictToRow(dictionary);

            //table.Table.Rows.Add(result);
            //table.Update(new DataRow[] { result });


            //String strConnString = System.Configuration.ConfigurationManager
            //.ConnectionStrings["conString"].ConnectionString;
            //SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            //cmd.Connection = connection;
            try
            {
                //connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                return false;
            }
            finally
            {
                //con.Close();
                //con.Dispose();
            }
        }
    }
}
