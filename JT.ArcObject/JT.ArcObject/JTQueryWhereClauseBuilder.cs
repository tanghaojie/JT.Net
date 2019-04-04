using System;

namespace JT.ArcObject {
    public static partial class JTQueryWhereClauseBuilder {
        public static string SingleWhereClause(string fieldname, object value) {
            if (string.IsNullOrEmpty(fieldname)) { throw new ArgumentNullException(); }
            if (value == null || value == DBNull.Value) {
                return $"{fieldname} is null";
            } else if (value is string s) {
                return $"{fieldname} = '{s}'";
            } else if (value is DateTime dateTime) {
                var y = dateTime.Year.ToString("0000");
                var m = dateTime.Month.ToString("00");
                var d = dateTime.Day.ToString("00");
                var h = dateTime.Hour.ToString("00");
                var minute = dateTime.Minute.ToString("00");
                var second = dateTime.Second.ToString("00");
                return $"{fieldname} = date '{y}-{m}-{d} {h}-{minute}-{second}'";
            } else {
                return $"{fieldname} = {value.ToString()}";
            }
        }
    }

    public static partial class JTQueryWhereClauseBuilder {
        public class FieldValue {
            public string FieldName { get; set; }
            public object Value { get; set; }
            public FieldValue(string fieldName, object value) {
                FieldName = fieldName;
                Value = value;
            }
        }
        public static string WhereClauses(FieldValue[] fieldValues) {
            if (fieldValues == null || fieldValues.Length <= 0) { throw new ArgumentNullException(); }
            var len = fieldValues.Length;
            var singles = new string[len];
            for (int i = 0; i < len; i++) {
                var fieldValue = fieldValues[i];
                singles[i] = SingleWhereClause(fieldValue.FieldName, fieldValue.Value);
            }
            return JT.DB.Common.SQLCombinater.CombinaterWhereClause(singles);
        }
    }

    public static partial class JTQueryWhereClauseBuilder {
        
    }

    public static partial class JTQueryWhereClauseBuilder {

    }

    public static partial class JTQueryWhereClauseBuilder {

    }

    public static partial class JTQueryWhereClauseBuilder {

    }
}
