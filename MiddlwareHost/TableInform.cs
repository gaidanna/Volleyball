﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;

namespace Middleware
{
    [DataContract]
    public class TableInform
    {
        private static Dictionary<string , TableInform> tableInfoList = new Dictionary<string , TableInform>();
        private static DbProviderFactory dbProviderFactory;
        private static DbConnection connection;
        private static bool connected = false;

        private DbDataAdapter dataAdapter;
        private DataTable dataTable;        
        private DbCommand command;

        static TableInform()
        {
            ObtainSqlConfiguration();
            connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[ "VB" ].ConnectionString;
            SetTables();
        }

        public TableInform( string tableName )
        {
            try
            {
                dataAdapter = TableInform.dbProviderFactory.CreateDataAdapter();

                command = TableInform.dbProviderFactory.CreateCommand();
                command.Connection = TableInform.Connection;

                DbCommandBuilder commandBuilder = TableInform.dbProviderFactory.CreateCommandBuilder();
                commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                commandBuilder.DataAdapter = dataAdapter;

                dataTable = new DataTable();
                dataTable.TableName = tableName;

                command.CommandText = "Select * from " + Table.TableName;

                dataAdapter.SelectCommand = command;
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();

                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                dataAdapter.Fill( dataTable );
            }
            catch ( Exception ex )
            { }
        }

        public static DbConnection Connection
        {
            get
            {
                while ( !connected )
                {
                    try
                    {
                        if ( connection.State == ConnectionState.Broken )
                        {
                            connection.Close();
                        }
                        if ( connection.State == ConnectionState.Closed )
                        {
                            connection.Open();
                        }
                        connected = true;

                    }
                    catch ( Exception ex )
                    {
                        connection.Close();
                        connected = false;
                        return null;
                    }
                }
                return connection;
            }
        }

        [DataMember]
        public DataTable Table
        {
            get
            {
                return dataTable;
            }
        }

        private static void ObtainSqlConfiguration()
        {
            try
            {
                var sql = ConfigurationManager.ConnectionStrings[ "VB" ];
                dbProviderFactory = DbProviderFactories.GetFactory( sql.ProviderName );

            }
            catch
            { }
        }

        public static void RemoveTableManager( string tableName )
        {
            try
            {
                tableInfoList.Remove( tableName );
            }
            catch { }
        }

        public static TableInform GetTableInfo( string tableName )
        {
            TableInform table = null;
            try
            {
                table = tableInfoList[ tableName ];
            }
            catch
            {
                try
                {
                    table = new TableInform( tableName );
                    tableInfoList.Add( tableName , table );
                }
                catch { }
            }
            return table;
        }

        private static void SetTables()
        {
            TableInform table = null;
            DbConnection connection = Connection;
            var existingTables = GetTableNames();

            foreach ( var t in existingTables )
            {
                tableInfoList.Add( t , new TableInform( t ) );
            }
        }

        private static List<string> GetTableNames()
        {
            DataTable schema;
            List<string> TableNames;

            schema = connection.GetSchema( "Tables" );
            TableNames = new List<string>();

            foreach ( DataRow row in schema.Rows )
            {
                TableNames.Add( row[ 2 ].ToString() );
            }
            return TableNames;
        }

        public static void TryCreateTable( string TableName , Func<string> getRowNames )
        {
            string stringRowNames;
            List<string> TableNames;

            if ( Connection != null )
            {
                try
                {
                    TableNames = GetTableNames();
                    if ( !TableNames.Contains( TableName ) )
                    {
                        using ( DbCommand command = TableInform.dbProviderFactory.CreateCommand() )
                        {
                            stringRowNames = getRowNames();
                            command.Connection = connection;
                            command.CommandText = String.Format( "CREATE TABLE {0} {1}" , TableName , stringRowNames );
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch
                { }
            }
        }

        public int Update( Dictionary<string , string> dictionary )
        {
            var result = this.ConvertDictToRow( dictionary );
            return Update( new DataRow[] { result } );
        }

        public int Update( DataRow[] drs )
        {
            return dataAdapter.Update( drs );
        }

        public DataRow ConvertDictToRow( Dictionary<string , string> dictionary )
        {
            DataRow row = this.dataTable.NewRow();

            foreach ( var key in dictionary.Keys )
            {
                row[ key ] = dictionary[ key ];
            }
            return row;
        }

        public Dictionary<string , string> ConvertRowToDict( DataRow row )
        {
            Dictionary<string , string> dictionary = row.Table.Columns.Cast<DataColumn>().ToDictionary( col => col.ColumnName , col => row.Field<object>( col.ColumnName ).ToString() );
            return dictionary;
        }
    }
}
