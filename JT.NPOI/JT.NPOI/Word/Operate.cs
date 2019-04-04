using NPOI.XWPF.UserModel;
using N = NPOI;
namespace JT.NPOI.Word {
    public class Operate {
        public static XWPFRun Run(XWPFRun run, string fontFamily, int fontSize, string text = null) {
            run.FontFamily = fontFamily;
            run.FontSize = fontSize;
            run.SetText(text);
            return run;
        }
        public static XWPFParagraph Paragraph(XWPFParagraph paragraph, int spacingAfter = -1, int spacingAfterLines = -1, int indentationFirstLine = -1, ParagraphAlignment alignment = ParagraphAlignment.LEFT) {
            if (spacingAfter > 0) { paragraph.SpacingAfter = spacingAfter; }
            if (spacingAfterLines > 0) { paragraph.SpacingAfterLines = spacingAfterLines; }
            if (indentationFirstLine > 0) { paragraph.IndentationFirstLine = indentationFirstLine; }
            paragraph.Alignment = alignment;
            return paragraph;
        }
        public static XWPFParagraph Paragraph(XWPFDocument doc, int spacingAfter = -1, int spacingAfterLines = -1, int indentationFirstLine = -1, ParagraphAlignment alignment = ParagraphAlignment.LEFT, string lineSpacing = null) {
            var p = doc?.Document?.body?.AddNewP();
            if (p == null) { return null; }
            if (!string.IsNullOrEmpty(lineSpacing)) {
                var ppr = p?.AddNewPPr();
                var spacing = ppr?.AddNewSpacing();
                if (spacing != null) {
                    spacing.line = lineSpacing;
                    
                    spacing.lineRule = N.OpenXmlFormats.Wordprocessing.ST_LineSpacingRule.auto;
                }
            }
            var paragraph = new XWPFParagraph(p, doc) { Alignment = alignment };
            if (spacingAfter > 0) { paragraph.SpacingAfter = spacingAfter; }
            if (spacingAfterLines > 0) { paragraph.SpacingAfterLines = spacingAfterLines; }
            if (indentationFirstLine > 0) { paragraph.IndentationFirstLine = indentationFirstLine; }
            return paragraph;
        }
    }
}
