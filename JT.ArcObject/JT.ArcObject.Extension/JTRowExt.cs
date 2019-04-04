using ESRI.ArcGIS.Geodatabase;
using System;

namespace JT.ArcObject.Extension {
    public static partial class JTRowExt {
        public static bool JTRowSame(this IRow row1, IRow row2, string[] compareFields) {
            if (row1 == null || row2 == null) { throw new ArgumentNullException(); }
            if (compareFields == null || compareFields.Length <= 0) { return true; }
            var table1 = row1.Table;
            var table2 = row2.Table;
            var index1 = -1;
            var index2 = -1;
            foreach (var field in compareFields) {
                index1 = table1.FindField(field); if (index1 < 0) { return false; }
                index2 = table2.FindField(field); if (index2 < 0) { return false; }
                object value1 = row1.get_Value(index1);
                object value2 = row2.get_Value(index2);
                if (!Equals(value1, value2)) { return false; }
            }
            return true;
        }
    }

    public static partial class JTRowExt {

    }

    public static partial class JTRowExt {

    }

    public static partial class JTRowExt {

    }

    public static partial class JTRowExt {

    }

    public static partial class JTRowExt {

    }

    public static partial class JTRowExt {

    }
}
