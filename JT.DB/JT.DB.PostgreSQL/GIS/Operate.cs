using JT.DB.Common;
using Npgsql;
using JT.Standard;
using System.Data.Common;
using S = JT.DB.Common.SQLString;
using System;
using NpgsqlTypes;

namespace JT.DB.PostgreSQL.GIS {

    #region Public Instance Constructors
    public partial class Operate : Normal.Operate {
        public Operate(IDB db) : base(db) { }
    }
    #endregion

    #region Public Static Fields
    public partial class Operate {
        public const string SPATIAL_REF_SYS = "spatial_ref_sys";
        public const string SPATIAL_REF_SYS_SRID_FIELD = "srid";
        public const string SPATIAL_REF_SYS_PROJ4TEXT_FIELD = "proj4text";
        public const string ADD_GEOMETRY_COLUMN = "AddGeometryColumn";
    }
    #endregion

    #region Public Instance Methods

    #region SpatialReference
    public partial class Operate {
        public int? GetSpatialReferenceSRID(string proj4) {
            // select "srid" from "spatial_ref_sys" where "proj4text" = proj4
            var sql = S.SELECT
                + " "
                + S.DOUBLE_QUOTATION_MARKS + SPATIAL_REF_SYS_SRID_FIELD + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.FROM
                + " "
                + S.DOUBLE_QUOTATION_MARKS + SPATIAL_REF_SYS + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.WHERE
                + " "
                + S.DOUBLE_QUOTATION_MARKS + SPATIAL_REF_SYS_PROJ4TEXT_FIELD + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.EQUAL
                + " "
                + S.DBPARA;
            var dataSet = DB.ExecuteQuery(sql, new NpgsqlParameter[] { new NpgsqlParameter { ParameterName = S.DBPARA, Value = proj4, } });
            if (dataSet == null || dataSet.Tables.Count <= 0) { return null; }
            var dataTable = dataSet.Tables[0];
            if (dataTable == null || dataTable.Rows.Count != 1 || !dataTable.Columns.Contains(SPATIAL_REF_SYS_SRID_FIELD)) { return null; }
            var value = dataTable.Rows[0][SPATIAL_REF_SYS_SRID_FIELD];
            if (int.TryParse(value?.ToString() ?? "", out int srid)) { return srid; }
            return null;
        }
    }
    #endregion

    #region Add Geometry Column

    public partial class Operate {
        public bool AddGeometryColumn(string catalogName, string schemaName, string tableName, int srid, OGCGeometricTypes type, string columnName = "geom", int dimension = 2, bool useTypemod = true) {
            /*
             *  text AddGeometryColumn(varchar table_name, varchar column_name, integer srid, varchar type, integer dimension, boolean use_typmod=true);
             *  text AddGeometryColumn(varchar schema_name, varchar table_name, varchar column_name, integer srid, varchar type, integer dimension, boolean use_typmod=true);
             *  text AddGeometryColumn(varchar catalog_name, varchar schema_name, varchar table_name, varchar column_name, integer srid, varchar type, integer dimension, boolean use_typmod=true);
             * 
             * */
            string sql;
            if (string.IsNullOrEmpty(columnName)) { throw new ArgumentNullException("Column Name."); }
            var cPara = S.DBPara(1);
            var sPara = S.DBPara(2);
            var tPara = S.DBPara(3);
            var namePara = S.DBPara(4);
            var sridPara = S.DBPara(5);
            var typePara = S.DBPara(6);
            var dimensionPara = S.DBPara(7);
            var useTypeModPara = S.DBPara(8);
            if (string.IsNullOrEmpty(catalogName)) {
                if (string.IsNullOrEmpty(schemaName)) {
                    if (string.IsNullOrEmpty(tableName)) { throw new ArgumentNullException("Table Name."); }
                    sql = S.SELECT
                        + " "
                        + ADD_GEOMETRY_COLUMN
                        + S.LEFT_PARENTHESIS
                        + tPara + S.COMMA
                        + namePara + S.COMMA
                        + sridPara + S.COMMA
                        + typePara + S.COMMA
                        + dimensionPara + S.COMMA
                        + useTypeModPara
                        + S.RIGHT_PARENTHESIS;
                } else {
                    if (string.IsNullOrEmpty(tableName)) { throw new ArgumentNullException("Table Name."); }
                    sql = S.SELECT
                        + " "
                        + ADD_GEOMETRY_COLUMN
                        + S.LEFT_PARENTHESIS
                        + sPara + S.COMMA
                        + tPara + S.COMMA
                        + namePara + S.COMMA
                        + sridPara + S.COMMA
                        + typePara + S.COMMA
                        + dimensionPara + S.COMMA
                        + useTypeModPara
                        + S.RIGHT_PARENTHESIS;
                }
            } else {
                if (string.IsNullOrEmpty(schemaName)) { throw new ArgumentNullException("Schema Name."); }
                if (string.IsNullOrEmpty(tableName)) { throw new ArgumentNullException("Table Name."); }
                sql = S.SELECT
                    + " "
                    + ADD_GEOMETRY_COLUMN
                    + S.LEFT_PARENTHESIS
                    + cPara + S.COMMA
                    + sPara + S.COMMA
                    + tPara + S.COMMA
                    + namePara + S.COMMA
                    + sridPara + S.COMMA
                    + typePara + S.COMMA
                    + dimensionPara + S.COMMA
                    + useTypeModPara
                    + S.RIGHT_PARENTHESIS;
            }
            var dataSet = DB.ExecuteQuery(sql, new NpgsqlParameter[] {
                new NpgsqlParameter { ParameterName = cPara,            Value = catalogName,        NpgsqlDbType = NpgsqlDbType.Varchar, },
                new NpgsqlParameter { ParameterName = sPara ,           Value = schemaName,         NpgsqlDbType = NpgsqlDbType.Varchar, },
                new NpgsqlParameter { ParameterName = tPara ,           Value = tableName ,         NpgsqlDbType = NpgsqlDbType.Varchar, },
                new NpgsqlParameter { ParameterName = namePara ,        Value = columnName,         NpgsqlDbType = NpgsqlDbType.Varchar, },
                new NpgsqlParameter { ParameterName = sridPara ,        Value = srid ,              NpgsqlDbType = NpgsqlDbType.Integer, },
                new NpgsqlParameter { ParameterName = typePara ,        Value = type.ToString() ,   NpgsqlDbType = NpgsqlDbType.Varchar, },
                new NpgsqlParameter { ParameterName = dimensionPara ,   Value = dimension ,         NpgsqlDbType = NpgsqlDbType.Integer, },
                new NpgsqlParameter { ParameterName = useTypeModPara,   Value = useTypemod ,        NpgsqlDbType = NpgsqlDbType.Boolean, },
            });
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0) { return true; }
            return false;
        }
    }

    #endregion

    #endregion

    #region Public Static Methods

    #region SpatialReference
    public partial class Operate {
        public static int? GetSpatialReferenceSRID(DbConnection connection, string proj4) {
            // select "srid" from "spatial_ref_sys" where "proj4text" = proj4
            var sql = S.SELECT
                + " "
                + S.DOUBLE_QUOTATION_MARKS + SPATIAL_REF_SYS_SRID_FIELD + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.FROM
                + " "
                + S.DOUBLE_QUOTATION_MARKS + SPATIAL_REF_SYS + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.WHERE
                + " "
                + S.DOUBLE_QUOTATION_MARKS + SPATIAL_REF_SYS_PROJ4TEXT_FIELD + S.DOUBLE_QUOTATION_MARKS
                + " "
                + S.EQUAL
                + " "
                + S.DBPARA;
            var dataSet = Base.ExecuteQuery(connection, sql, new NpgsqlParameter[] { new NpgsqlParameter { ParameterName = S.DBPARA, Value = proj4, } });
            if (dataSet == null || dataSet.Tables.Count <= 0) { return null; }
            var dataTable = dataSet.Tables[0];
            if (dataTable == null || dataTable.Rows.Count != 1 || !dataTable.Columns.Contains(SPATIAL_REF_SYS_SRID_FIELD)) { return null; }
            var value = dataTable.Rows[0][SPATIAL_REF_SYS_SRID_FIELD];
            if (int.TryParse(value?.ToString() ?? "", out int srid)) { return srid; }
            return null;
        }
    }
    #endregion

    #endregion
}
