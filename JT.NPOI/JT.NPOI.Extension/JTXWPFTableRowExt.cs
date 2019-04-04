using NPOI.XWPF.UserModel;
namespace JT.NPOI.Extension {
    public static partial class JTXWPFTableRowExt {
        public static void JTClearRuns(this XWPFTableRow row) {
            var cells = row.GetTableCells();
            var count = cells.Count;
            for (int i = 0; i < count; i++) {
                var cell = cells[i];
                var paragraphs = cell.Paragraphs;
                if (paragraphs == null) { throw new JTNoParagraphExistInCellException(); }
                var pCount = paragraphs.Count;
                for (int j = 0; j < pCount; j++) {
                    var paragraph = paragraphs[j];
                    var runs = paragraph.Runs;
                    if (runs != null) {
                        var rCount = runs.Count;
                        for (int k = 0; k < rCount; k++) {
                            paragraph.RemoveRun(0);
                        }
                    }
                }
            }
        }

    }
}
