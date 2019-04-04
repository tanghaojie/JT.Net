using ESRI.ArcGIS.Geodatabase;
using System;
namespace JT.ArcObject {
    public static partial class JTRowCompare {
#if NET_4_0
        public static bool RowSame(IRow row1, IRow row2, string[] compareFields = null) {
            if (row1 == null || row2 == null) { throw new ArgumentNullException(); }

            var table1 = row1.Table;
            var table2 = row2.Table;

            if (compareFields == null || compareFields.Length <= 0) {
                List<string> allFields = new List<string>();
                var field = table1.Fields;
                var count = field.FieldCount;
                for (int i = 0; i < count; i++) {
                    var fieldName = field.Field[i].Name;
                    if (fieldName.ToUpper() == table1.OIDFieldName.ToUpper() || fieldName.ToUpper() == "SHAPE" || fieldName.ToUpper() == "SHAPE_LENGTH" || fieldName.ToUpper() == "SHAPE_AREA") { continue; }
                    if (!allFields.Contains(fieldName)) {
                        allFields.Add(fieldName);
                    }
                }
                field = table2.Fields;
                count = field.FieldCount;
                for (int i = 0; i < count; i++) {
                    var fieldName = field.Field[i].Name;
                    if (fieldName.ToUpper() == table2.OIDFieldName.ToUpper() || fieldName.ToUpper() == "SHAPE" || fieldName.ToUpper() == "SHAPE_LENGTH" || fieldName.ToUpper() == "SHAPE_AREA") { continue; }
                    if (!allFields.Contains(fieldName)) {
                        allFields.Add(fieldName);
                    }
                }
                compareFields = allFields.ToArray();
            }

            var index1 = -1;
            var index2 = -1;

            foreach (var field in compareFields) {
                index1 = table1.FindField(field); if (index1 < 0) { return false; }
                index2 = table2.FindField(field); if (index2 < 0) { return false; }
                dynamic value1 = row1.get_Value(index1);
                dynamic value2 = row2.get_Value(index2);
                if (value1 == null && value2 == null) {
                    continue;
                } else if (value1 != null && value2 != null) {
                    if (value1.GetType() != value2.GetType()) { return false; }
                    if (value1 != value2) { return false; }
                } else {
                    return false;
                }
            }
            return true;
        }
#endif
    }
    public static partial class JTRowCompare {

    }
}
