using JT.DB.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
namespace JT.DB.Access {
    public partial class Operate : IOperate {
        public IDB DB { get; }
        public Operate(IDB db)  {
            DB = db;
        }
    }
    public partial class Operate {
        public static DataTable Query(DbConnection conn, string table, params FieldValue[] fieldValues) {
            string sql = string.Empty;
            List<DbParameter> parameters = new List<DbParameter>();
            if (fieldValues == null || fieldValues.Length <= 0) { sql = "select * from " + table; } else {
                string wClause = string.Empty;
                int counter = 0;
                foreach (var fv in fieldValues) {
                    var f = fv.FieldName;
                    if (string.IsNullOrEmpty(f)) { throw new NoNullAllowedException(); }
                    var parameterName = ParaPrefix + counter;
                    counter++;
                    var v = fv.Value;
                    wClause = (v == null || v == DBNull.Value) ? (f + " is null and ") : (f + " = " + parameterName + " and ");
                    parameters.Add(new OleDbParameter(parameterName, fv.Value));
                }
                if (wClause.Length > 3) { wClause = wClause.Remove(wClause.Length - 4, 4); }
                sql = "select * from " + table + " where " + wClause;
            }
            var ds = Base.ExecuteQuery(conn, sql, parameters.ToArray());
            if (ds.Tables != null && ds.Tables.Count > 0) { return ds.Tables[0]; }
            return null;
        }
    }
    public partial class Operate {
        public DataTable SelectTop1(string tablename) {
            var sql = "SELECT top 1 * from " + tablename;
            var ds = DB.ExecuteQuery(sql);
            if (ds?.Tables?.Count <= 0) { return null; }
            return ds.Tables[0];
        }
        public bool ExistTable(string name) {
            //var sql = "SELECT * from MSysObjects where lcase(name) = @para";
            //var ds = DB.ExecuteQuery(sql, new DbParameter[] { new OleDbParameter("@para", name) });
            //if (ds?.Tables?.Count <= 0) { return false; }
            //if (ds?.Tables[0].Rows.Count <= 0) { return false; }
            //return true;
            var conn = DB.GetConnection();
            if (conn.State != ConnectionState.Open) { conn.Open(); }
            var dt = conn.GetSchema("Tables");
            if (dt?.Rows?.Count <= 0) {
                return false;
            }
            var rows = dt.Select("TABLE_NAME = '" + name + "'");
            if (rows.Length == 1) { return true; }
            return false;
        }
        public DataTable Query(string table, params FieldValue[] fieldValues) {
            string sql = string.Empty;
            List<DbParameter> parameters = new List<DbParameter>();
            if (fieldValues == null || fieldValues.Length <= 0) { sql = "select * from " + table; } else {
                string wClause = string.Empty;
                int counter = 0;
                foreach (var fv in fieldValues) {
                    var f = fv.FieldName;
                    if (string.IsNullOrEmpty(f)) { throw new NoNullAllowedException(); }
                    var parameterName = ParaPrefix + counter;
                    counter++;
                    var v = fv.Value;
                    wClause = (v == null || v == DBNull.Value) ? (f + " is null and ") : (f + " = " + parameterName + " and ");
                    parameters.Add(new OleDbParameter(parameterName, fv.Value));
                }
                if (wClause.Length > 3) { wClause = wClause.Remove(wClause.Length - 4, 4); }
                sql = "select * from " + table + " where " + wClause;
            }
            var ds = DB.ExecuteQuery(sql, parameters.ToArray());
            if (ds.Tables.Count > 0) {
                return ds.Tables[0];
            }
            return null;
        }
    }
    partial class Operate {
        private string InsertInto => "Insert into ";
        private string Values => " Values ";
        private const string ParaPrefix = "@para";
        private string GeomFromText => "ST_GeomFromText";
    }
    public partial class Operate {
        public class FieldValue {
            public FieldValue(string fieldName, object value) {
                FieldName = fieldName;
                Value = value;
            }
            public string FieldName { get; }
            public object Value { get; }
        }
    }
}
