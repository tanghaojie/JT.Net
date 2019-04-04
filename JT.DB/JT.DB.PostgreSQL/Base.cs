#region 
/***
 *  JT.MIT
***/
#endregion 

using JT.DB.Common;
using Npgsql;
using System.Data;
using System.Data.Common;
namespace JT.DB.PostgreSQL {

    #region Public Instance Constructors
    public sealed partial class Base {
        public Base(string server, int port, string username, string password, string database, int commandTimeout = 0) {
            this.server = server;
            this.port = port;
            this.username = username;
            this.password = password;
            this.database = database;
            this.commandTimeout = commandTimeout;
        }
        public Base(ConnectionInfo info) {
            server = info.Server;
            port = info.Port;
            username = info.Username;
            password = info.Password;
            database = info.Database;
            commandTimeout = info.CommandTimeout;
        }
    }
    #endregion

    #region Implementation of IDB
    public sealed partial class Base : IDB {
        public DataSet ExecuteQuery(string textCommand, params DbParameter[] parameters) {
            var ds = new DataSet();
            using (var conn = GetConnection()) {
                Common.DB.OpenConnection(conn);
                using (var cmd = new NpgsqlCommand() as DbCommand) {
                    cmd.CommandText = textCommand;
                    cmd.Connection = conn;
                    if (parameters != null && parameters.Length > 0) { cmd.Parameters.AddRange(parameters); }
                    using (var dataAdapter = new NpgsqlDataAdapter() as DbDataAdapter) {
                        dataAdapter.SelectCommand = cmd;
                        dataAdapter.Fill(ds);
                    }
                }
            }
            return ds;
        }
        public DataSet ExecuteQuery(DbTransaction transaction, string textCommand, params DbParameter[] parameters) {
            var ds = new DataSet();
            using (var cmd = new NpgsqlCommand() as DbCommand) {
                cmd.Transaction = transaction;
                cmd.CommandText = textCommand;
                cmd.Connection = transaction.Connection;
                if (parameters != null && parameters.Length > 0) { cmd.Parameters.AddRange(parameters); }
                using (var dataAdapter = new NpgsqlDataAdapter() as DbDataAdapter) {
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(ds);
                }
            }
            return ds;
        }
    }
    public sealed partial class Base {
        public int ExecuteNonQuery(string textCommand, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            int count = 0;
            using (var conn = GetConnection()) {
                Common.DB.OpenConnection(conn);
                using (var cmd = new NpgsqlCommand() as DbCommand) {
                    cmd.CommandText = textCommand;
                    cmd.Connection = conn;
                    cmd.CommandType = commandType;
                    if (parameters != null && parameters.Length > 0) { cmd.Parameters.AddRange(parameters); }
                    count = cmd.ExecuteNonQuery();
                }
            }
            return count;
        }
        public int ExecuteNonQuery(DbTransaction transaction, string textCommand, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            int count;
            using (var cmd = new NpgsqlCommand() as DbCommand) {
                cmd.Transaction = transaction;
                cmd.CommandText = textCommand;
                cmd.Connection = transaction.Connection;
                cmd.CommandType = commandType;
                if (parameters != null && parameters.Length > 0) { cmd.Parameters.AddRange(parameters); }
                count = cmd.ExecuteNonQuery();
            }
            return count;
        }
    }
    public sealed partial class Base {
        public DbConnection GetConnection() {
            return new NpgsqlConnection(ConnectionString);
        }
    }
    #endregion

    #region Public Static Methods
    public sealed partial class Base {
        public static DataSet ExecuteQuery(DbConnection conn, string textCommand, params DbParameter[] parameters) {
            var ds = new DataSet();
            Common.DB.OpenConnection(conn);
            using (var cmd = new NpgsqlCommand() as DbCommand) {
                cmd.CommandText = textCommand;
                cmd.Connection = conn;
                if (parameters != null && parameters.Length > 0) { cmd.Parameters.AddRange(parameters); }
                using (var dataAdapter = new NpgsqlDataAdapter() as DbDataAdapter) {
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(ds);
                }
            }
            return ds;
        }
    }
    public sealed partial class Base {
        public static int ExecuteNonQuery(DbConnection connection, string textCommand, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            int count;
            Common.DB.OpenConnection(connection);
            using (var cmd = new NpgsqlCommand() as DbCommand) {
                cmd.Connection = connection;
                cmd.CommandText = textCommand;
                cmd.CommandType = commandType;
                if (parameters != null && parameters.Length > 0) { cmd.Parameters.AddRange(parameters); }
                count = cmd.ExecuteNonQuery();
            }
            return count;
        }
        public static int ExecuteNonQuery(string textCommand, DbTransaction transaction, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            int count;
            using (var cmd = new NpgsqlCommand() as DbCommand) {
                cmd.CommandText = textCommand;
                cmd.Connection = transaction.Connection;
                cmd.CommandType = commandType;
                cmd.Transaction = transaction;
                if (parameters != null && parameters.Length > 0) { cmd.Parameters.AddRange(parameters); }
                count = cmd.ExecuteNonQuery();
            }
            return count;
        }
    }
    #endregion

    #region Public Instance Properties
    public sealed partial class Base {
        public string ConnectionString =>
    "Server = " + server +
    ";Port=" + port.ToString() +
    ";User Id = " + username +
    "; Password=" + (password ?? "") +
    "; Database=" + database +
    ";CommandTimeout=" + commandTimeout;
    }
    #endregion

    #region Private Instance Fields
    public sealed partial class Base {
        private readonly string server;
        private readonly int port;
        private readonly string username;
        private readonly string password;
        private readonly string database;
        private readonly int commandTimeout;
    }
    #endregion
}
