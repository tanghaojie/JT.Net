using JT.DB.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using S = JT.DB.Common.SQLString;
namespace JT.DB.PostgreSQL.Normal {

    #region Public Instance Constructors
    public partial class Operate : IOperate {
        public Operate(IDB db) { DB = db; }
    }
    #endregion

    #region Implementation of IOperate
    public partial class Operate {
        public IDB DB { get; }
    }
    #endregion

    #region Public Static Fields
    public partial class Operate {
        public const string PG_TABLES = "pg_tables";
        public const string PG_TABLES_TABLENAME_FIELD = "tablename";
        public const string PG_VIEWS = "pg_views";
        public const string PG_VIEWS_VIEWNAME_FIELD = "viewname";
    }
    #endregion

    #region Public Instance Methods

    #region Table Operate
    public partial class Operate {
        public bool ExistTable(string tablename) {
            //select * from "pg_tables" where "tablename" = tablename
            var sql = S.SELECT
                + " "
                + S.ASTERISK
                + " "
                + S.FROM
                + " "
                + S.DOUBLE_QUOTATION_MARKS + PG_TABLES + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.WHERE
                + " "
                + S.DOUBLE_QUOTATION_MARKS + PG_TABLES_TABLENAME_FIELD + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.EQUAL
                + " "
                + S.DBPARA;
            var dataSet = DB.ExecuteQuery(sql, new NpgsqlParameter[] { new NpgsqlParameter(S.DBPARA, tablename) });
            if (dataSet == null || dataSet.Tables.Count <= 0) { return false; }
            var dataTable = dataSet.Tables[0];
            if (dataTable == null || dataTable.Rows.Count <= 0) { return false; }
            return true;
        }
        public void DropTable(string tablename) {
            // drop table "tablename"
            var sql = S.DROP
                + " "
                + S.TABLE
                + " "
                + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
            DB.ExecuteNonQuery(sql);
        }
        public void TruncateTable(string tablename) {
            // truncate table "tablename"
            var sql = S.TRUNCATE
             + " "
             + S.TABLE
             + " "
             + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
            DB.ExecuteNonQuery(sql);
        }
    }
    #endregion

    #region View Operate
    public partial class Operate {
        public bool ExistView(string viewname) {
            // select * from "pg_views" where "viewname" = viewname
            var sql = S.SELECT
            + " "
            + S.ASTERISK
            + " "
            + S.FROM
            + " "
            + S.DOUBLE_QUOTATION_MARKS + PG_VIEWS + S.DOUBLE_QUOTATION_MARKS
            + " "
            + S.WHERE
            + " "
            + S.DOUBLE_QUOTATION_MARKS + PG_VIEWS_VIEWNAME_FIELD + S.DOUBLE_QUOTATION_MARKS
            + " "
            + S.EQUAL
            + " "
            + S.DBPARA;
            var dataSet = DB.ExecuteQuery(sql, new NpgsqlParameter[] { new NpgsqlParameter(S.DBPARA, viewname) });
            if (dataSet == null || dataSet.Tables.Count <= 0) { return false; }
            var dataTable = dataSet.Tables[0];
            if (dataTable == null || dataTable.Rows.Count <= 0) { return false; }
            return true;
        }
        public void DropView(string viewname) {
            // drop view "viewname"
            var sql = S.DROP
                + " "
                + S.VIEW
                + " "
                + S.DOUBLE_QUOTATION_MARKS + viewname + S.DOUBLE_QUOTATION_MARKS;
            DB.ExecuteNonQuery(sql);
        }
    }
    #endregion

    #region Distinct 
    public partial class Operate {
        public object[] Distinct(string tablename, string fieldname) {
            if (string.IsNullOrEmpty(tablename) || string.IsNullOrEmpty(fieldname)) { throw new ArgumentNullException(); }
            DataSet dataSet = null;
            using (var conn = DB.GetConnection()) {
                Common.DB.OpenConnection(conn);
                //  select distinct("field") from "tablename"
                var sql = S.SELECT
                    + " "
                    + S.DISTINCT + S.LEFT_PARENTHESIS + S.DOUBLE_QUOTATION_MARKS + fieldname + S.DOUBLE_QUOTATION_MARKS + S.RIGHT_PARENTHESIS
                    + " "
                    + S.FROM
                    + " "
                    + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
                dataSet = DB.ExecuteQuery(sql);
            }
            object[] result = null;
            if (dataSet == null || dataSet.Tables.Count <= 0) { return result; }
            var dataTable = dataSet.Tables[0];
            if (dataTable.Rows.Count <= 0) { return result; }
            var count = dataTable.Rows.Count;
            result = new object[count];
            for (int i = 0; i < count; i++) { result[i] = dataTable.Rows[i][fieldname]; }
            return result;
        }
        public T[] Distinct<T>(string tablename, string fieldname) {
            if (string.IsNullOrEmpty(tablename) || string.IsNullOrEmpty(fieldname)) { throw new ArgumentNullException(); }
            DataSet dataSet = null;
            using (var conn = DB.GetConnection()) {
                Common.DB.OpenConnection(conn);
                //  select distinct("field") from "tablename"
                var sql = S.SELECT
                    + " "
                    + S.DISTINCT + S.LEFT_PARENTHESIS + S.DOUBLE_QUOTATION_MARKS + fieldname + S.DOUBLE_QUOTATION_MARKS + S.RIGHT_PARENTHESIS
                    + " "
                    + S.FROM
                    + " "
                    + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
                dataSet = DB.ExecuteQuery(sql);
            }
            T[] result = null;
            if (dataSet == null || dataSet.Tables.Count <= 0) { return result; }
            var dataTable = dataSet.Tables[0];
            if (dataTable.Rows.Count <= 0) { return result; }
            var count = dataTable.Rows.Count;
            result = new T[count];
            for (int i = 0; i < count; i++) { var value = dataTable.Rows[i][fieldname]; if (value is T v) { result[i] = v; } else { throw new InvalidCastException(); } }
            return result;
        }
    }
    #endregion

    #endregion

    #region Public Static Methods

    #region Excute Query
    public partial class Operate {
        public static DataSet ExcuteQuery(DbConnection connection, string sql, params DbParameter[] parameters) {
            return Base.ExecuteQuery(connection, sql, parameters);
        }
    }
    #endregion

    #region Excute Non Query
    public partial class Operate {
        public static int ExcuteNonQuery(DbConnection connection, string command, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            return Base.ExecuteNonQuery(connection, command, commandType, parameters);
        }
        public static int ExcuteNonQuery(DbTransaction transaction, string command, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            return Base.ExecuteNonQuery(command, transaction, commandType, parameters);
        }
    }
    #endregion

    #region Table Operate
    public partial class Operate {
        public static bool ExistTable(DbConnection connection, string tablename) {
            //select * from "pg_tables" where "tablename" = tablename
            var sql = S.SELECT
                + " "
                + S.ASTERISK
                + " "
                + S.FROM
                + " "
                + S.DOUBLE_QUOTATION_MARKS + PG_TABLES + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.WHERE
                + " "
                + S.DOUBLE_QUOTATION_MARKS + PG_TABLES_TABLENAME_FIELD + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.EQUAL
                + " "
                + S.DBPARA;
            var dataSet = Base.ExecuteQuery(connection, sql, new NpgsqlParameter[] { new NpgsqlParameter(S.DBPARA, tablename) });
            if (dataSet == null || dataSet.Tables.Count <= 0) { return false; }
            var dataTable = dataSet.Tables[0];
            if (dataTable == null || dataTable.Rows.Count <= 0) { return false; }
            return true;
        }
        public static void DropTable(DbConnection connection, string tablename) {
            // drop table "tablename"
            var sql = S.DROP
                + " "
                + S.TABLE
                + " "
                + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
            Base.ExecuteNonQuery(connection, sql);
        }
        public static void TruncateTable(DbConnection connection, string tablename) {
            // truncate table "tablename"
            var sql = S.TRUNCATE
             + " "
             + S.TABLE
             + " "
             + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
            Base.ExecuteNonQuery(connection, sql);
        }
        public static void TruncateTable(DbTransaction transaction, string tablename) {
            // truncate table "tablename"
            var sql = S.TRUNCATE
             + " "
             + S.TABLE
             + " "
             + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
            Base.ExecuteNonQuery(sql, transaction);
        }
    }
    #endregion

    #region View Operate
    public partial class Operate {
        public static bool ExistView(DbConnection connection, string viewname) {
            // select * from "pg_views" where "viewname" = viewname
            var sql = S.SELECT
                + " "
                + S.ASTERISK
                + " "
                + S.FROM
                + " "
                + S.DOUBLE_QUOTATION_MARKS + PG_VIEWS + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.WHERE
                + " "
                + S.DOUBLE_QUOTATION_MARKS + PG_VIEWS_VIEWNAME_FIELD + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.EQUAL
                + " "
                + S.DBPARA;
            var dataSet = Base.ExecuteQuery(connection, sql, new NpgsqlParameter[] { new NpgsqlParameter(S.DBPARA, viewname) });
            if (dataSet == null || dataSet.Tables.Count <= 0) { return false; }
            var dataTable = dataSet.Tables[0];
            if (dataTable == null || dataTable.Rows.Count <= 0) { return false; }
            return true;
        }
        public static void DropView(DbConnection connection, string viewname) {
            // drop view "viewname"
            var sql = S.DROP
                + " "
                + S.VIEW
                + " "
                + S.DOUBLE_QUOTATION_MARKS + viewname + S.DOUBLE_QUOTATION_MARKS;
            Base.ExecuteNonQuery(connection, sql);
        }
    }
    #endregion

    #region Distinct 
    public partial class Operate {
        public static object[] Distinct(DbConnection connection, string tablename, string fieldname) {
            if (connection == null || string.IsNullOrEmpty(tablename) || string.IsNullOrEmpty(fieldname)) { throw new ArgumentNullException(); }
            DataSet dataSet = null;
            Common.DB.OpenConnection(connection);
            //  select distinct("field") from "tablename"
            var sql = S.SELECT
                + " "
                + S.DISTINCT + S.LEFT_PARENTHESIS + S.DOUBLE_QUOTATION_MARKS + fieldname + S.DOUBLE_QUOTATION_MARKS + S.RIGHT_PARENTHESIS
                + " "
                + S.FROM
                + " "
                + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
            dataSet = Base.ExecuteQuery(connection, sql);
            object[] result = null;
            if (dataSet == null || dataSet.Tables.Count <= 0) { return result; }
            var dataTable = dataSet.Tables[0];
            if (dataTable.Rows.Count <= 0) { return result; }
            var count = dataTable.Rows.Count;
            result = new object[count];
            for (int i = 0; i < count; i++) { result[i] = dataTable.Rows[i][fieldname]; }
            return result;
        }
        public static T[] Distinct<T>(DbConnection connection, string tablename, string fieldname) {
            if (connection == null || string.IsNullOrEmpty(tablename) || string.IsNullOrEmpty(fieldname)) { throw new ArgumentNullException(); }
            DataSet dataSet = null;
            Common.DB.OpenConnection(connection);
            //  select distinct("field") from "tablename"
            var sql = S.SELECT
                + " "
                + S.DISTINCT + S.LEFT_PARENTHESIS + S.DOUBLE_QUOTATION_MARKS + fieldname + S.DOUBLE_QUOTATION_MARKS + S.RIGHT_PARENTHESIS
                + " "
                + S.FROM
                + " "
                + S.DOUBLE_QUOTATION_MARKS + tablename + S.DOUBLE_QUOTATION_MARKS;
            dataSet = Base.ExecuteQuery(connection, sql);
            T[] result = null;
            if (dataSet == null || dataSet.Tables.Count <= 0) { return result; }
            var dataTable = dataSet.Tables[0];
            if (dataTable.Rows.Count <= 0) { return result; }
            var count = dataTable.Rows.Count;
            result = new T[count];
            for (int i = 0; i < count; i++) { var value = dataTable.Rows[i][fieldname]; if (value is T v) { result[i] = v; } else { throw new InvalidCastException(); } }
            return result;
        }
    }
    #endregion

    #endregion







    #region 
    //public partial class Operate {
    //    public static void Update(DbConnection conn, DbTransaction transaction, string table, Dictionary<string, object> whereKv, Dictionary<string, object> kv) {
    //        var ParaPrefix = "@para";
    //        if (conn == null || transaction == null || string.IsNullOrEmpty(table) || whereKv == null || kv == null) { throw new ArgumentNullException(); }
    //        string setsql = string.Empty;
    //        string wheresql = string.Empty;
    //        int counter = 0;
    //        List<DbParameter> parameters = new List<DbParameter>();
    //        foreach (var item in kv) {
    //            var key = item.Key;
    //            if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
    //            var parameterName = ParaPrefix + counter;
    //            counter++;
    //            setsql += JTStringExtension.Self.DoubleQuotationMarks + key + JTStringExtension.Self.DoubleQuotationMarks + " = " + parameterName + JTStringExtension.Self.Comma;
    //            parameters.Add(new NpgsqlParameter(parameterName, item.Value ?? DBNull.Value));
    //        }
    //        foreach (var item in whereKv) {
    //            var key = item.Key;
    //            if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
    //            var parameterName = ParaPrefix + counter;
    //            counter++;
    //            wheresql += JTStringExtension.Self.DoubleQuotationMarks + key + JTStringExtension.Self.DoubleQuotationMarks + " = " + parameterName + JTStringExtension.Self.Comma;
    //            parameters.Add(new NpgsqlParameter(parameterName, item.Value ?? DBNull.Value));
    //        }
    //        setsql = setsql.Remove(setsql.Length - 1, 1);
    //        wheresql = wheresql.Remove(wheresql.Length - 1, 1);
    //        var x = parameters.ToArray();
    //        string sql =
    //            "update " +
    //            JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
    //            " set " + setsql +
    //            " where " + wheresql;
    //        Base.ExecuteNonQuery(sql, transaction, parameters: x);

    //    }
    //}

    //public partial class Operate {
    //    public static bool Insert(DbConnection conn, DbTransaction transaction, string table, Dictionary<string, object> kv, Dictionary<string, (string, int)> geomFromWKT) {
    //        var ParaPrefix = "@para";
    //        if (string.IsNullOrEmpty(table) || kv == null || geomFromWKT == null || (kv.Count <= 0 && geomFromWKT.Count <= 0)) { throw new ArgumentNullException(); }
    //        string fields = string.Empty;
    //        string paraArguments = string.Empty;
    //        int counter = 0;
    //        List<DbParameter> parameters = new List<DbParameter>();
    //        foreach (var item in kv) {
    //            var key = item.Key;
    //            if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
    //            fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
    //            var parameterName = ParaPrefix + counter;
    //            counter++;
    //            paraArguments += parameterName + JTStringExtension.Self.Comma;
    //            parameters.Add(new NpgsqlParameter(parameterName, item.Value ?? DBNull.Value));
    //        }
    //        foreach (var item in geomFromWKT) {
    //            var key = item.Key;
    //            if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
    //            fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
    //            var parameterName = ParaPrefix + counter;
    //            counter++;
    //            var (t, s) = item.Value;
    //            var parameterName2 = ParaPrefix + counter;
    //            counter++;
    //            paraArguments += "ST_GeomFromText" + JTStringExtension.Self.LeftParenthesis + parameterName + JTStringExtension.Self.Comma + parameterName2 + JTStringExtension.Self.RightParenthesis + JTStringExtension.Self.Comma;
    //            parameters.Add(new NpgsqlParameter(parameterName, t ?? (object)DBNull.Value));
    //            parameters.Add(new NpgsqlParameter(parameterName2, s));
    //        }
    //        fields = fields.Remove(fields.Length - 1, 1);
    //        paraArguments = paraArguments.Remove(paraArguments.Length - 1, 1);
    //        var x = parameters.ToArray();
    //        string sql =
    //            "Insert into " +
    //            JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
    //            JTStringExtension.Self.LeftParenthesis + fields + JTStringExtension.Self.RightParenthesis +
    //            " Values " +
    //            JTStringExtension.Self.LeftParenthesis + paraArguments + JTStringExtension.Self.RightParenthesis;
    //        return Base.ExecuteNonQuery(sql, transaction, parameters: x) > 0 ? true : false;
    //    }
    //    public static bool Insert(DbConnection conn, DbTransaction transaction, string table, Dictionary<string, object> kv) {
    //        var ParaPrefix = "@para";
    //        if (string.IsNullOrEmpty(table) || kv == null || kv.Count <= 0) { throw new ArgumentNullException(); }
    //        string fields = string.Empty;
    //        string paraArguments = string.Empty;
    //        int counter = 0;
    //        List<DbParameter> parameters = new List<DbParameter>();
    //        foreach (var item in kv) {
    //            var key = item.Key;
    //            if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
    //            fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
    //            var parameterName = ParaPrefix + counter;
    //            counter++;
    //            paraArguments += parameterName + JTStringExtension.Self.Comma;
    //            parameters.Add(new NpgsqlParameter(parameterName, item.Value));
    //        }
    //        fields = fields.Remove(fields.Length - 1, 1);
    //        paraArguments = paraArguments.Remove(paraArguments.Length - 1, 1);
    //        var x = parameters.ToArray();
    //        string sql =
    //            "Insert into " +
    //            JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
    //            JTStringExtension.Self.LeftParenthesis + fields + JTStringExtension.Self.RightParenthesis +
    //            " Values " +
    //            JTStringExtension.Self.LeftParenthesis + paraArguments + JTStringExtension.Self.RightParenthesis;
    //        return Base.ExecuteNonQuery(sql, transaction, parameters: x) > 0 ? true : false;
    //    }
    //}
    //public partial class Operate {
    //    public bool Insert(string table, Dictionary<string, object> kv) {
    //        var ParaPrefix = "@para";
    //        if (string.IsNullOrEmpty(table) || kv == null || kv.Count <= 0) { throw new ArgumentNullException(); }
    //        string fields = string.Empty;
    //        string paraArguments = string.Empty;
    //        int counter = 0;
    //        List<DbParameter> parameters = new List<DbParameter>();
    //        foreach (var item in kv) {
    //            var key = item.Key;
    //            if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
    //            fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
    //            var parameterName = ParaPrefix + counter;
    //            counter++;
    //            paraArguments += parameterName + JTStringExtension.Self.Comma;
    //            parameters.Add(new NpgsqlParameter(parameterName, item.Value));
    //        }
    //        fields = fields.Remove(fields.Length - 1, 1);
    //        paraArguments = paraArguments.Remove(paraArguments.Length - 1, 1);
    //        var x = parameters.ToArray();
    //        string sql =
    //            "Insert into " +
    //            JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
    //            JTStringExtension.Self.LeftParenthesis + fields + JTStringExtension.Self.RightParenthesis +
    //            " Values " +
    //            JTStringExtension.Self.LeftParenthesis + paraArguments + JTStringExtension.Self.RightParenthesis;
    //        bool result = false;
    //        using (var conn = DB.GetConnection()) {
    //            conn.Open();
    //            using (var trans = conn.BeginTransaction()) {
    //                try {
    //                    var count = DB.ExecuteNonQuery(trans, sql, parameters: x);
    //                    if (count > 0) {
    //                        trans.Commit();
    //                        result = true;
    //                    } else {
    //                        trans.Rollback();
    //                        result = false;
    //                    }
    //                } catch {
    //                    trans.Rollback();
    //                    result = false;
    //                }
    //            }
    //        }
    //        return result;
    //    }
    //    public bool Insert(string table, Dictionary<string, object> kv, Dictionary<string, (string, int?)> geomFromWKT) {
    //        var ParaPrefix = "@para";
    //        if (string.IsNullOrEmpty(table) || kv == null || geomFromWKT == null || (kv.Count <= 0 && geomFromWKT.Count <= 0)) { throw new ArgumentNullException(); }
    //        string fields = string.Empty;
    //        string paraArguments = string.Empty;
    //        int counter = 0;
    //        List<DbParameter> parameters = new List<DbParameter>();
    //        foreach (var item in kv) {
    //            var key = item.Key;
    //            if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
    //            fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
    //            var parameterName = ParaPrefix + counter;
    //            counter++;
    //            paraArguments += parameterName + JTStringExtension.Self.Comma;
    //            parameters.Add(new NpgsqlParameter(parameterName, item.Value ?? DBNull.Value));
    //        }
    //        foreach (var item in geomFromWKT) {
    //            var key = item.Key;
    //            if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
    //            fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
    //            var parameterName = ParaPrefix + counter;
    //            counter++;
    //            var (t, s) = item.Value;
    //            if (s == null) {
    //                paraArguments += "ST_GeomFromText" + JTStringExtension.Self.LeftParenthesis + parameterName + JTStringExtension.Self.RightParenthesis + JTStringExtension.Self.Comma;
    //                parameters.Add(new NpgsqlParameter(parameterName, t ?? (object)DBNull.Value));
    //            } else {
    //                var parameterName2 = ParaPrefix + counter;
    //                counter++;
    //                paraArguments += "ST_GeomFromText" + JTStringExtension.Self.LeftParenthesis + parameterName + JTStringExtension.Self.Comma + parameterName2 + JTStringExtension.Self.RightParenthesis + JTStringExtension.Self.Comma;
    //                parameters.Add(new NpgsqlParameter(parameterName, t ?? (object)DBNull.Value));
    //                parameters.Add(new NpgsqlParameter(parameterName2, s ?? (object)DBNull.Value));
    //            }
    //        }
    //        fields = fields.Remove(fields.Length - 1, 1);
    //        paraArguments = paraArguments.Remove(paraArguments.Length - 1, 1);
    //        var x = parameters.ToArray();
    //        string sql =
    //            "Insert into " +
    //            JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
    //            JTStringExtension.Self.LeftParenthesis + fields + JTStringExtension.Self.RightParenthesis +
    //            " Values " +
    //            JTStringExtension.Self.LeftParenthesis + paraArguments + JTStringExtension.Self.RightParenthesis;
    //        bool result = false;
    //        using (var conn = DB.GetConnection()) {
    //            conn.Open();
    //            using (var trans = conn.BeginTransaction()) {
    //                try {
    //                    var count = DB.ExecuteNonQuery(trans, sql, parameters: x);
    //                    if (count > 0) {
    //                        trans.Commit();
    //                        result = true;
    //                    } else {
    //                        trans.Rollback();
    //                        result = false;
    //                    }
    //                } catch {
    //                    trans.Rollback();
    //                    result = false;
    //                }
    //            }
    //        }
    //        return result;
    //    }
    //}
    #endregion



    public partial class Operate {
        public DBField<FieldType>[] Fields(string table) {
            var ParaPrefix = "@para";
            string name = "name";
            string typename = "typename";
            string length = "length";
            string modify = "modify";
            string notnull = "notnull";
            string sql = "select a.attname as " + name + ",(select typname from pg_type where oid = a.atttypid) as " + typename + ", a.attlen as " + length + " ,a.atttypmod as " + modify
                + ",a.attnotnull as " + notnull + " from pg_class as c,pg_attribute as a where c.relname = " + ParaPrefix + " and a.attrelid = c.oid and a.attnum > 0 and a.atttypid > 0";
            var para = new DbParameter[1] { new NpgsqlParameter(ParaPrefix, table) };
            var ds = DB.ExecuteQuery(sql, para);
            if (ds == null || ds.Tables.Count <= 0) { return null; }
            var tb = ds.Tables[0];
            if (
                tb == null ||
                tb.Rows.Count <= 0 ||
                !tb.Columns.Contains(name) ||
                !tb.Columns.Contains(typename) ||
                !tb.Columns.Contains(length) ||
                !tb.Columns.Contains(modify) ||
                !tb.Columns.Contains(notnull)) { return null; }
            List<DBField<FieldType>> list = new List<DBField<FieldType>>();
            var textInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
            foreach (DataRow row in tb.Rows) {
                var n = row[name];
                var t = row[typename];
                var l = row[length];
                var m = row[modify];
                var not = row[notnull];
                if (
                    n == null ||
                    t == null ||
                    l == null ||
                    m == null ||
                    not == null) { throw new NullReferenceException(); }
                var ty = t.ToString();
                if (string.IsNullOrEmpty(ty)) { throw new NoNullAllowedException(); }
                ty = textInfo.ToTitleCase(ty.ToLower());
                if (!Enum.IsDefined(typeof(FieldType), ty)) { throw new TypeNotSupportException("PostgreSQLType:" + ty); }
                var type = (FieldType)Enum.Parse(typeof(FieldType), ty);
                var len = -1;
                var mod = -1;
                if (!int.TryParse(l.ToString(), out len) || !int.TryParse(m.ToString(), out mod)) { throw new FormatException(); }
                bool Notnull = false;
                var no = not.ToString().ToUpper();
                if (no == "T" || no == "TRUE" || no == "1") { Notnull = true; }
                list.Add(new Field(n.ToString(), type, len, mod, Notnull));
            }
            return list.ToArray();
        }
        public DBField<FieldType>[] GeomFields(string table, params FieldType[] geomFieldTypes) {
            var fields = Fields(table);
            return GeomFields(fields, geomFieldTypes);
        }
        public DBField<FieldType>[] GeomFields(DBField<FieldType>[] fields, params FieldType[] geomFieldTypes) {
            var list = new List<DBField<FieldType>>();
            if (fields == null || fields.Length <= 0 || geomFieldTypes == null || geomFieldTypes.Length <= 0) { return list.ToArray(); }
            foreach (var field in fields) {
                var type = field.Type;
                if (Array.Exists(geomFieldTypes, x => x == type)) { list.Add(field); }
            }
            return list.ToArray();
        }
    }
    public class TypeNotSupportException : Exception {
        public TypeNotSupportException(string message) : base(message) { }
    }
}
