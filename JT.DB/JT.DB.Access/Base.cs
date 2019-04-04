using JT.DB.Common;
using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
namespace JT.DB.Access {
    public partial class Base {
        private readonly Provider provider;
        private readonly string dataSource;
        private readonly string password;
        public Base(Provider provider, string dataSource, string password = null) {
            this.provider = provider;
            this.dataSource = dataSource;
            this.password = password;
        }
        public Base(string dataSource, string password = null) {
            this.dataSource = dataSource;
            if (dataSource.ToUpper().EndsWith(".MDB")) {
                provider = Provider.JetOleDB4_0;
            } else if (dataSource.ToUpper().EndsWith(".ACCDB")) {
                provider = Provider.AceOleDb12_0;
            } else {
                provider = Provider.AceOleDb12_0;
            }
            this.password = password;
        }
        public string ConnectionString =>
            "Provider=" + ProviderStr(provider) +
            ";Data Source=" + dataSource +
            "; " + (string.IsNullOrEmpty(password) ? "Persist Security Info=False;" : "Jet OleDb:DataBase Password='" + password + "';");
    }
    public partial class Base {
        public static DataSet ExecuteQuery(DbConnection conn, string textCommand, params DbParameter[] parameters) {
            var ds = new DataSet();
            if (conn == null) { throw new ArgumentNullException(); }
            if (conn.State != ConnectionState.Open) { conn.Open(); }
            using (var cmd = new OleDbCommand() as DbCommand) {
                cmd.CommandText = textCommand;
                cmd.Connection = conn;
                cmd.Parameters.AddRange(parameters);
                using (var dataAdapter = new OleDbDataAdapter() as DbDataAdapter) {
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(ds);
                }
            }
            return ds;
        }
    }
    public partial class Base : IDB {
        public DbConnection GetConnection() {
            return new OleDbConnection(ConnectionString);
        }
        public int ExecuteNonQuery(DbTransaction transaction, string textCommand, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            var conn = transaction.Connection;
            OpenConnection(conn);
            int count;
            using (var cmd = new OleDbCommand() as DbCommand) {
                cmd.Transaction = transaction;
                cmd.CommandText = textCommand;
                cmd.Connection = conn;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                count = cmd.ExecuteNonQuery();
            }
            return count;
        }
        public int ExecuteNonQuery(string textCommand, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            int count = 0;
            using (var conn = GetConnection()) {
                OpenConnection(conn);
                using (var cmd = new OleDbCommand() as DbCommand) {
                    cmd.CommandText = textCommand;
                    cmd.Connection = conn;
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);
                    count = cmd.ExecuteNonQuery();
                }
            }
            return count;
        }
        public DataSet ExecuteQuery(DbTransaction transaction, string textCommand, params DbParameter[] parameters) {
            var conn = transaction.Connection;
            OpenConnection(conn);
            var ds = new DataSet();
            using (var cmd = new OleDbCommand() as DbCommand) {
                cmd.Transaction = transaction;
                cmd.CommandText = textCommand;
                cmd.Connection = conn;
                cmd.Parameters.AddRange(parameters);
                using (var dataAdapter = new OleDbDataAdapter() as DbDataAdapter) {
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(ds);
                }
            }
            return ds;
        }
        public DataSet ExecuteQuery(string textCommand, params DbParameter[] parameters) {
            var ds = new DataSet();
            using (var conn = GetConnection()) {
                OpenConnection(conn);
                using (var cmd = new OleDbCommand() as DbCommand) {
                    cmd.CommandText = textCommand;
                    cmd.Connection = conn;
                    cmd.Parameters.AddRange(parameters);
                    using (var dataAdapter = new OleDbDataAdapter() as DbDataAdapter) {
                        dataAdapter.SelectCommand = cmd;
                        dataAdapter.Fill(ds);
                    }
                }
            }
            return ds;
        }
    }
    public partial class Base {
        private const string AceOleDb12_0ProviderStr = "Microsoft.Ace.OleDb.12.0";
        private const string JetOleDb4_0ProviderStr = "Microsoft.Jet.OleDb.4.0";
        public enum Provider {
            AceOleDb12_0,
            JetOleDB4_0,
        }
        public static string ProviderStr(Provider provider) {
            switch (provider) {
                case Provider.AceOleDb12_0: return AceOleDb12_0ProviderStr;
                case Provider.JetOleDB4_0: return JetOleDb4_0ProviderStr;
                default: return null;
            }
        }
        public static Provider? ProviderByStr(string providerStr) {
            if (string.IsNullOrEmpty(providerStr)) { return null; }
            switch (providerStr) {
                case string x when x.ToUpper() == "MICROSOFT.ACE.OLEDB.12.0": return Provider.AceOleDb12_0;
                case string x when x.ToUpper() == "MICROSOFT.JET.OLEDB.4.0": return Provider.JetOleDB4_0;
                default: return null;
            }
        }
    }
    partial class Base {
        private void OpenConnection(DbConnection connection) {
            if (connection == null) { throw new ArgumentNullException(); }
            if (connection.State != ConnectionState.Open) { connection.Open(); }
        }
    }

}
