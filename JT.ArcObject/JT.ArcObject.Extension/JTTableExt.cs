using ESRI.ArcGIS.Geodatabase;
using JT.ADF;
using System;
using System.Collections.Generic;

namespace JT.ArcObject.Extension {
    public static partial class JTTableExt {

    }

    public static partial class JTTableExt {

    }

    public static partial class JTTableExt {

    }

    public static partial class JTTableExt {
        public static bool JTExistField(this ITable table, string fieldname) {
            return table.FindField(fieldname) >= 0;
        }
    }

    public static partial class JTTableExt {
#if NET_3_5
        public static IList<object> JTUniqueValues(this ITable table, string fieldname, string where = null) {
            if (table == null || string.IsNullOrEmpty(fieldname)) { throw new ArgumentNullException(); }
            var index = table.FindField(fieldname);
            if (index < 0) { throw new FieldNotExistException(); }
            var field = table.Fields.Field[index];
            switch (field.Type) {
                case esriFieldType.esriFieldTypeBlob:
                case esriFieldType.esriFieldTypeGeometry:
                case esriFieldType.esriFieldTypeRaster:
                case esriFieldType.esriFieldTypeXML: { throw new FieldTypeNotSupportException(); }
            }
            var ds = table as IDataset;
            var ws = ds.Workspace;
            var wsf = ws.WorkspaceFactory;
            var wsfType = wsf.WorkspaceType;
            var fws = ws as IFeatureWorkspace;
            IList<object> list = new List<object>(); ;
            if (wsfType == esriWorkspaceType.esriFileSystemWorkspace) {
                var queryFilter = new QueryFilterClass { WhereClause = where };
                var cursor = table.Search(queryFilter, true);
                IDataStatistics dataStatistics = new DataStatisticsClass {
                    Field = fieldname,
                    Cursor = cursor,
                };
                var enumerator = dataStatistics.UniqueValues;
                enumerator.Reset();
                while (enumerator.MoveNext()) {
                    object value = enumerator.Current;
                    if (value == null || value == DBNull.Value) { value = null; }
                    list.Add(value);
                }
                ComReleaser.ReleaseComObject(dataStatistics);
                ComReleaser.ReleaseComObject(cursor);
                ComReleaser.ReleaseComObject(queryFilter);
            } else if (wsfType == esriWorkspaceType.esriLocalDatabaseWorkspace || wsfType == esriWorkspaceType.esriRemoteDatabaseWorkspace) {
                var queryDef = fws.CreateQueryDef();
                queryDef.Tables = ds.Name;
                queryDef.SubFields = "DISTINCT(" + fieldname + ")";
                queryDef.WhereClause = where;
                var cursor = queryDef.Evaluate();
                IRow row = null;
                while ((row = cursor.NextRow()) != null) {
                    object value = row.get_Value(0);
                    if (value == null || value == DBNull.Value) { value = null; }
                    list.Add(value);
                }
                ComReleaser.ReleaseComObject(cursor);
                ComReleaser.ReleaseComObject(queryDef);
            } else { throw new UnsupportWorkspaceFactoryTypeException(); }
            return list;
        }
#endif

#if NET_4_0
        public static IList<dynamic> JTUniqueValues(this ITable table, string fieldname, string where = null) {
            if (table == null || string.IsNullOrEmpty(fieldname)) { throw new ArgumentNullException(); }
            var index = table.FindField(fieldname);
            if (index < 0) { throw new FieldNotExistException(); }
            var field = table.Fields.Field[index];
            switch (field.Type) {
                case esriFieldType.esriFieldTypeBlob:
                case esriFieldType.esriFieldTypeGeometry:
                case esriFieldType.esriFieldTypeRaster:
                case esriFieldType.esriFieldTypeXML: { throw new FieldTypeNotSupportException(); }
            }
            var ds = table as IDataset;
            var ws = ds.Workspace;
            var wsf = ws.WorkspaceFactory;
            var wsfType = wsf.WorkspaceType;
            var fws = ws as IFeatureWorkspace;

            IList<dynamic> list = new List<dynamic>(); ;

            if (wsfType == esriWorkspaceType.esriFileSystemWorkspace) {
                var queryFilter = new QueryFilterClass { WhereClause = where };
                var cursor = table.Search(queryFilter, true);
                IDataStatistics dataStatistics = new DataStatisticsClass();
                dataStatistics.Field = fieldname;
                dataStatistics.Cursor = cursor;
                var enumerator = dataStatistics.UniqueValues;
                enumerator.Reset();
                while (enumerator.MoveNext()) {
                    object value = enumerator.Current;
                    if (value == null || value == DBNull.Value) { value = null; }
                    list.Add(value);
                }
            } else if (wsfType == esriWorkspaceType.esriLocalDatabaseWorkspace || wsfType == esriWorkspaceType.esriRemoteDatabaseWorkspace) {
                var queryDef = fws.CreateQueryDef();
                queryDef.Tables = ds.Name;
                queryDef.SubFields = "DISTINCT(" + fieldname + ")";
                queryDef.WhereClause = where;
                var cursor = queryDef.Evaluate();
                IRow row = null;
                while ((row = cursor.NextRow()) != null) {
                    object value = row.get_Value(0);
                    if (value == null || value == DBNull.Value) { value = null; }
                    list.Add(value);
                }
            } else { throw new UnsupportWorkspaceFactoryType(); }

            return list;
        }
#endif

    }

    public static partial class JTTableExt {

        public static void JTClear(this ITable table, IQueryFilter queryFilter) {
            table.DeleteSearchedRows(queryFilter);
        }

        public static void JTClear(this ITable table) {
            var cursor = table.Update(null, true);
            IRow row = null;
            while ((row = cursor.NextRow()) != null) {
                cursor.DeleteRow();
            }
        }

    }

    public static partial class JTTableExt {

        public static void JTDelete(this ITable table) {
            var ds = table as IDataset;
            ds.JTDelete();
        }

    }

}
