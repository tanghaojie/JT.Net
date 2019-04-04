using JTDBCommon; 
using JTPostgreSQL.ManualCreateTable;
using JTExtensions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace JTPostgreSQL {
    public partial class Operater : JTDBCommon.Operater {
        public Operater(IDB db) : base(db) { }
    }
    public partial class Operater {
        public static void Update(DbConnection conn, DbTransaction transaction, string table, Dictionary<string, object> whereKv, Dictionary<string, object> kv) {
            if (conn == null || transaction == null || string.IsNullOrEmpty(table) || whereKv == null || kv == null) { throw new ArgumentNullException(); }
            string setsql = string.Empty;
            string wheresql = string.Empty;
            int counter = 0;
            List<DbParameter> parameters = new List<DbParameter>();
            foreach (var item in kv) {
                var key = item.Key;
                if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
                var parameterName = ParaPrefix + counter;
                counter++;
                setsql += JTStringExtension.Self.DoubleQuotationMarks + key + JTStringExtension.Self.DoubleQuotationMarks + " = " + parameterName + JTStringExtension.Self.Comma;
                parameters.Add(new NpgsqlParameter(parameterName, item.Value ?? DBNull.Value));
            }
            foreach (var item in whereKv) {
                var key = item.Key;
                if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
                var parameterName = ParaPrefix + counter;
                counter++;
                wheresql += JTStringExtension.Self.DoubleQuotationMarks + key + JTStringExtension.Self.DoubleQuotationMarks + " = " + parameterName + JTStringExtension.Self.Comma;
                parameters.Add(new NpgsqlParameter(parameterName, item.Value ?? DBNull.Value));
            }
            setsql = setsql.Remove(setsql.Length - 1, 1);
            wheresql = wheresql.Remove(wheresql.Length - 1, 1);
            var x = parameters.ToArray();
            string sql =
                "update " +
                JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
                " set " + setsql +
                " where " + wheresql;
            Base.ExecuteNonQuery(conn, sql, transaction, parameters: x);
        }
    }
    public partial class Operater {
        public static object[] Distinct(DbConnection conn, string table, string field) {
            if (conn == null || string.IsNullOrEmpty(table) || string.IsNullOrEmpty(field)) { throw new ArgumentNullException(); }
            if (conn.State != ConnectionState.Open) { conn.Open(); }
            string sql = "select distinct(" + field + ") from " + JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks;
            var ds = Base.ExecuteQuery(sql, conn);
            if (ds == null || ds.Tables.Count <= 0) { return null; }
            var t = ds.Tables[0];
            if (t.Rows.Count <= 0) { return new object[0]; }
            var count = t.Rows.Count;
            var r = new object[count];
            for (int i = 0; i < count; i++) {
                r[i] = t.Rows[i][field];
            }
            return r;
        }
        public static T[] Distinct<T>(DbConnection conn, string table, string field) {
            if (conn == null || string.IsNullOrEmpty(table) || string.IsNullOrEmpty(field)) { throw new ArgumentNullException(); }
            if (conn.State != ConnectionState.Open) { conn.Open(); }
            string sql = "select distinct(" + field + ") from " + JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks;
            var ds = Base.ExecuteQuery(sql, conn);
            if (ds == null || ds.Tables.Count <= 0) { return null; }
            var t = ds.Tables[0];
            if (t.Rows.Count <= 0) { return new T[0]; }
            var count = t.Rows.Count;
            var r = new T[count];
            for (int i = 0; i < count; i++) {
                var value = t.Rows[i][field];
                if (value is T v) {
                    r[i] = v;
                } else {
                    r[i] = default(T);
                }
            }
            return r;
        }
    }
    public partial class Operater {
        public static bool Insert(DbConnection conn, DbTransaction transaction, string table, Dictionary<string, object> kv, Dictionary<string, (string, int)> geomFromWKT) {
            if (string.IsNullOrEmpty(table) || kv == null || geomFromWKT == null || (kv.Count <= 0 && geomFromWKT.Count <= 0)) { throw new ArgumentNullException(); }
            string fields = string.Empty;
            string paraArguments = string.Empty;
            int counter = 0;
            List<DbParameter> parameters = new List<DbParameter>();
            foreach (var item in kv) {
                var key = item.Key;
                if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
                fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
                var parameterName = ParaPrefix + counter;
                counter++;
                paraArguments += parameterName + JTStringExtension.Self.Comma;
                parameters.Add(new NpgsqlParameter(parameterName, item.Value ?? DBNull.Value));
            }
            foreach (var item in geomFromWKT) {
                var key = item.Key;
                if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
                fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
                var parameterName = ParaPrefix + counter;
                counter++;
                var (t, s) = item.Value;
                var parameterName2 = ParaPrefix + counter;
                counter++;
                paraArguments += GeomFromText + JTStringExtension.Self.LeftParenthesis + parameterName + JTStringExtension.Self.Comma + parameterName2 + JTStringExtension.Self.RightParenthesis + JTStringExtension.Self.Comma;
                parameters.Add(new NpgsqlParameter(parameterName, t ?? (object)DBNull.Value));
                parameters.Add(new NpgsqlParameter(parameterName2, s));
            }
            fields = fields.Remove(fields.Length - 1, 1);
            paraArguments = paraArguments.Remove(paraArguments.Length - 1, 1);
            var x = parameters.ToArray();
            string sql =
                InsertInto +
                JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
                JTStringExtension.Self.LeftParenthesis + fields + JTStringExtension.Self.RightParenthesis +
                Values +
                JTStringExtension.Self.LeftParenthesis + paraArguments + JTStringExtension.Self.RightParenthesis;
            return Base.ExecuteNonQuery(conn, sql, transaction, parameters: x) > 0 ? true : false;
        }
        public static bool Insert(DbConnection conn, DbTransaction transaction, string table, Dictionary<string, object> kv) {
            if (string.IsNullOrEmpty(table) || kv == null || kv.Count <= 0) { throw new ArgumentNullException(); }
            string fields = string.Empty;
            string paraArguments = string.Empty;
            int counter = 0;
            List<DbParameter> parameters = new List<DbParameter>();
            foreach (var item in kv) {
                var key = item.Key;
                if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
                fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
                var parameterName = ParaPrefix + counter;
                counter++;
                paraArguments += parameterName + JTStringExtension.Self.Comma;
                parameters.Add(new NpgsqlParameter(parameterName, item.Value));
            }
            fields = fields.Remove(fields.Length - 1, 1);
            paraArguments = paraArguments.Remove(paraArguments.Length - 1, 1);
            var x = parameters.ToArray();
            string sql =
                InsertInto +
                JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
                JTStringExtension.Self.LeftParenthesis + fields + JTStringExtension.Self.RightParenthesis +
                Values +
                JTStringExtension.Self.LeftParenthesis + paraArguments + JTStringExtension.Self.RightParenthesis;
            return Base.ExecuteNonQuery(conn, sql, transaction, parameters: x) > 0 ? true : false;
        }
    }
    public partial class Operater {
        public bool Insert(string table, Dictionary<string, object> kv) {
            if (string.IsNullOrEmpty(table) || kv == null || kv.Count <= 0) { throw new ArgumentNullException(); }
            string fields = string.Empty;
            string paraArguments = string.Empty;
            int counter = 0;
            List<DbParameter> parameters = new List<DbParameter>();
            foreach (var item in kv) {
                var key = item.Key;
                if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
                fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
                var parameterName = ParaPrefix + counter;
                counter++;
                paraArguments += parameterName + JTStringExtension.Self.Comma;
                parameters.Add(new NpgsqlParameter(parameterName, item.Value));
            }
            fields = fields.Remove(fields.Length - 1, 1);
            paraArguments = paraArguments.Remove(paraArguments.Length - 1, 1);
            var x = parameters.ToArray();
            string sql =
                InsertInto +
                JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
                JTStringExtension.Self.LeftParenthesis + fields + JTStringExtension.Self.RightParenthesis +
                Values +
                JTStringExtension.Self.LeftParenthesis + paraArguments + JTStringExtension.Self.RightParenthesis;
            bool result = false;
            using (var conn = DB.Connection()) {
                conn.Open();
                using (var trans = conn.BeginTransaction()) {
                    try {
                        var count = DB.ExecuteNonQuery(trans, sql, parameters: x);
                        if (count > 0) {
                            trans.Commit();
                            result = true;
                        } else {
                            trans.Rollback();
                            result = false;
                        }
                    } catch {
                        trans.Rollback();
                        result = false;
                    }
                }
            }
            return result;
        }
        public bool Insert(string table, Dictionary<string, object> kv, Dictionary<string, (string, int?)> geomFromWKT) {
            if (string.IsNullOrEmpty(table) || kv == null || geomFromWKT == null || (kv.Count <= 0 && geomFromWKT.Count <= 0)) { throw new ArgumentNullException(); }
            string fields = string.Empty;
            string paraArguments = string.Empty;
            int counter = 0;
            List<DbParameter> parameters = new List<DbParameter>();
            foreach (var item in kv) {
                var key = item.Key;
                if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
                fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
                var parameterName = ParaPrefix + counter;
                counter++;
                paraArguments += parameterName + JTStringExtension.Self.Comma;
                parameters.Add(new NpgsqlParameter(parameterName, item.Value ?? DBNull.Value));
            }
            foreach (var item in geomFromWKT) {
                var key = item.Key;
                if (string.IsNullOrEmpty(key)) { throw new NoNullAllowedException(); }
                fields += JTStringExtension.Self.DoubleQuotationMarks + item.Key + JTStringExtension.Self.DoubleQuotationMarks + JTStringExtension.Self.Comma;
                var parameterName = ParaPrefix + counter;
                counter++;
                var (t, s) = item.Value;
                if (s == null) {
                    paraArguments += GeomFromText + JTStringExtension.Self.LeftParenthesis + parameterName + JTStringExtension.Self.RightParenthesis + JTStringExtension.Self.Comma;
                    parameters.Add(new NpgsqlParameter(parameterName, t ?? (object)DBNull.Value));
                } else {
                    var parameterName2 = ParaPrefix + counter;
                    counter++;
                    paraArguments += GeomFromText + JTStringExtension.Self.LeftParenthesis + parameterName + JTStringExtension.Self.Comma + parameterName2 + JTStringExtension.Self.RightParenthesis + JTStringExtension.Self.Comma;
                    parameters.Add(new NpgsqlParameter(parameterName, t ?? (object)DBNull.Value));
                    parameters.Add(new NpgsqlParameter(parameterName2, s ?? (object)DBNull.Value));
                }
            }
            fields = fields.Remove(fields.Length - 1, 1);
            paraArguments = paraArguments.Remove(paraArguments.Length - 1, 1);
            var x = parameters.ToArray();
            string sql =
                InsertInto +
                JTStringExtension.Self.DoubleQuotationMarks + table + JTStringExtension.Self.DoubleQuotationMarks +
                JTStringExtension.Self.LeftParenthesis + fields + JTStringExtension.Self.RightParenthesis +
                Values +
                JTStringExtension.Self.LeftParenthesis + paraArguments + JTStringExtension.Self.RightParenthesis;
            bool result = false;
            using (var conn = DB.Connection()) {
                conn.Open();
                using (var trans = conn.BeginTransaction()) {
                    try {
                        var count = DB.ExecuteNonQuery(trans, sql, parameters: x);
                        if (count > 0) {
                            trans.Commit();
                            result = true;
                        } else {
                            trans.Rollback();
                            result = false;
                        }
                    } catch {
                        trans.Rollback();
                        result = false;
                    }
                }
            }
            return result;
        }
    }
    public partial class Operater {
        public int GetSpatialReferenceSRID(string proj4) {
            string sridField = "srid";
            string sql = "select " + sridField + " from spatial_ref_sys where proj4text = " + ParaPrefix;
            var para = new DbParameter[1] {
                new NpgsqlParameter(ParaPrefix, proj4)
            };

            var ds = DB.ExecuteQuery(sql, para);
            if (ds == null || ds.Tables.Count <= 0) { return -1; }
            var tb = ds.Tables[0];
            if (
                tb == null ||
                tb.Rows.Count != 1 ||
                !tb.Columns.Contains(sridField)) { return -1; }

            var value = tb.Rows[0][sridField];
            if (int.TryParse(value?.ToString(), out int srid)) {
                return srid;
            }
            return -1;
        }
    }
    public partial class Operater {
        public static int ExcuteNonQuery(DbConnection conn, string sql, DbTransaction transaction = null, CommandType commandType = CommandType.Text, params DbParameter[] parameters) {
            return Base.ExecuteNonQuery(conn, sql, transaction, commandType, parameters);
        }
    }
    public partial class Operater {
        public static bool ExistView(DbConnection conn, string viewname) {
            string sql = "SELECT * FROM pg_views WHERE viewname = " + ParaPrefix;
            var ds = Base.ExecuteQuery(sql, conn, new DbParameter[1] { new NpgsqlParameter(ParaPrefix, viewname) });
            if (ds == null || ds.Tables.Count <= 0) { return false; }
            var tb = ds.Tables[0];
            if (tb == null || tb.Rows.Count <= 0) { return false; }
            return true;
        }

    }
    public partial class Operater {
        public bool ExistTable(string table) {
            string sql = "select * from pg_tables where tablename = " + ParaPrefix;
            var para = new DbParameter[1] {
                new NpgsqlParameter(ParaPrefix, table)
            };
            var ds = DB.ExecuteQuery(sql, para);
            if (ds == null || ds.Tables.Count <= 0) { return false; }
            var tb = ds.Tables[0];
            if (tb == null || tb.Rows.Count <= 0) { return false; }
            return true;
        }
        public bool CreateTable(string name, List<ManualCreateTableField> fields) {
            string sql = new ManualCreateTableSQLBuilder().CreateTable(name, fields);
            DB.ExecuteNonQuery(sql);
            return ExistTable(name);
        }
        public bool CreateTable(string name, List<ManualCreateTableField> fields, int srid, string type, string geoColumnName = "geom", int dimension = 2, bool? useTypemod = null) {
            string sql = new ManualCreateTableSQLBuilder().CreateTable(name, fields);
            if (!CreateTable(name, fields)) { return false; }
            try {
                if (!AddGeometryColumn(name, srid, type, geoColumnName, dimension, useTypemod)) {
                    DropTable(name);
                    return false;
                }
            } catch {
                DropTable(name);
                throw;
            }
            return true;
        }
        public void DropTable(string name) {
            string sql = "drop table \"" + name + "\"";
            DB.ExecuteNonQuery(sql);
        }
        public void TruncateTable(string name) {
            string sql = "truncate table \"" + name + "\"";
            DB.ExecuteNonQuery(sql);
        }
    }
    public partial class Operater {
        public static void TruncateTable(string tablename, DbConnection conn, DbTransaction transaction = null) {
            string sql = "truncate table \"" + tablename + "\"";
            Base.ExecuteNonQuery(conn, sql, transaction);
        }
        public static void DropTable(string tablename, DbConnection conn, DbTransaction transaction = null) {
            string sql = "drop table \"" + tablename + "\"";
            Base.ExecuteNonQuery(conn, sql, transaction);
        }
        public static int? GetSpatialReferenceSRID(string proj4, DbConnection conn) {
            var proj4TextField = "proj4text";
            var table = "spatial_ref_sys";
            var field = "srid";
            var sql = "select " + field + " from \"" + table + "\" where " + proj4TextField + " = " + ParaPrefix;
            var ds = Base.ExecuteQuery(sql, conn, new DbParameter[1] { new NpgsqlParameter(ParaPrefix, proj4) });
            if (ds == null || ds.Tables.Count <= 0) { return null; }
            var tb = ds.Tables[0];
            if (tb == null || tb.Rows.Count != 1 || !tb.Columns.Contains(field)) { return null; }
            var value = tb.Rows[0][field];
            if (int.TryParse(value?.ToString(), out int srid)) { return srid; }
            return null;
        }
    }
    public partial class Operater {
        public bool AddGeometryColumn(string tableName, int srid, string type, string columnName = "geom", int dimension = 2, bool? useTypemod = null) {
            string sql;
            if (useTypemod == null) {
                sql = "select addgeometrycolumn('" + tableName + "',  '" + columnName + "', " + srid + " ,  '" + type + "',  " + dimension + ")";
            } else {
                sql = "select addgeometrycolumn('" + tableName + "',  '" + columnName + "', " + srid + " ,  '" + type + "',  " + dimension + ", " + useTypemod.Value + ")";
            }
            var ds = DB.ExecuteQuery(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) { return true; }
            return false;
        }
    }
    public partial class Operater {
        public DBField<FieldType>[] Fields(string table) {
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
    partial class Operater {
        private const string InsertInto = "Insert into ";
        private const string Values = " Values ";
        private const string ParaPrefix = "@para";
        private const string GeomFromText = "ST_GeomFromText";
    }
    public class TypeNotSupportException : Exception {
        public TypeNotSupportException(string message) : base(message) { }
    }
}
