using System;
using System.Data;
using System.IO;
using System.Text;
namespace JT.DataTransfer {
    public partial class DataTableToCSVFile : ITransfer<DataTable, string> {
        public void Transfer(DataTable from, string to) {
            using (var fs = new FileStream(to, FileMode.OpenOrCreate, FileAccess.Write)) {
                using (var sw = new StreamWriter(fs, Encoding)) {
                    var data = "";
                    var count = from.Columns.Count;
                    for (int i = 0; i < count; i++) {
                        var value = from.Columns[i].ColumnName;
                        data += Format(value);
                        if (i < count - 1) { data += ","; }
                    }
                    sw.WriteLine(data);
                    var rowCount = from.Rows.Count;
                    for (int i = 0; i < rowCount; i++) {
                        data = "";
                        for (int j = 0; j < count; j++) {
                            var value = from.Rows[i][j];
                            data += Format(value);
                            if (j < count - 1) { data += ","; }
                        }
                        sw.WriteLine(data);
                    }
                }
            }
        }

        public void Transfer(DataTable from, string to, Encoding encoding) {
            Encoding = encoding;
            Transfer(from, to);
        }
    }
    public partial class DataTableToCSVFile {
        public Encoding Encoding { get; set; } = Encoding.Default;
    }
    public partial class DataTableToCSVFile {
        private string Format(object value) {
            switch (value) {
                case null: { return ""; }
                case string s: {
                    switch (s) {
                        case null: return "";
                        case "": return "\"\"";
                        default: {
                            if (s.Contains("\"")) {
                                return "\"" + s.Replace("\"", "\"\"") + "\"";
                            } else if (s.Contains(",") || s.Contains("\r") || s.Contains("\n")) {
                                return "\"" + s + "\"";
                            } else {
                                return s;
                            }
                        }
                    }
                }
                case DBNull db: { return db == DBNull.Value ? "" : db.ToString(); }
                default: { return value.ToString(); }
            }
        }

    }
}
