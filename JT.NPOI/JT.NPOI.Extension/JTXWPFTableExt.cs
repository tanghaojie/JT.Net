using NPOI.XWPF.UserModel;
using System;
namespace JT.NPOI.Extension {
    public static partial class JTXWPFTableExt {
        public static void JTClearSingleParagraphCellAndSetText(this XWPFTable table, int rowIndex, int cellIndex, string text) {
            var rows = table.Rows;
            if (rowIndex >= rows.Count) { throw new IndexOutOfRangeException(rowIndex.ToString()); }
            var row = rows[rowIndex];
            var cells = row.GetTableCells();
            if (cellIndex >= cells.Count) { throw new IndexOutOfRangeException(rowIndex.ToString()); }
            var cell = cells[cellIndex];
            var paras = cell.Paragraphs;
            if (paras == null) { throw new JTNoParagraphExistInCellException(); }
            if (paras.Count != 1) { throw new JTTooMuchParagraphsInCellException(); }
            var para = paras[0];
            var runs = para.Runs;
            if (runs != null && runs.Count > 0) {
                var count = runs.Count;
                for (int i = 0; i < count; i++) { para.RemoveRun(0); }
            }
            var run = para.CreateRun();
            run.SetText(text);
        }

    }

    public static partial class JTXWPFTableExt {
        public static string JTGetCellText(this XWPFTable table, int rowIndex, int cellIndex) {
            var rows = table.Rows;
            if (rowIndex >= rows.Count) { throw new IndexOutOfRangeException(rowIndex.ToString()); }
            var row = rows[rowIndex];
            var cells = row.GetTableCells();
            if (cellIndex >= cells.Count) { throw new IndexOutOfRangeException(rowIndex.ToString()); }
            var cell = cells[cellIndex];

            var result = string.Empty;

            var paras = cell.Paragraphs;
            if (paras == null || paras.Count <= 1) {
                result = cell.GetText() ?? "";
            } else {
                var paraCount = paras.Count;
                for (int i = 0; i < paraCount; i++) {
                    var para = paras[i];
                    var paraText = para.Text;

                    result += paraText + "\r\n";
                }
            }
            return result;
        }


    }

}
