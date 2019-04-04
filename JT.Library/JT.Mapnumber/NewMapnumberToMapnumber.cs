using System;
namespace JT.Mapnumber {
    public static class NewMapnumberToMapnumber {
        public static string ToNewMapnumber(string mapnumber) {
            if (NewMapnumberCheck.Check(mapnumber)) { return mapnumber; }
            mapnumber = mapnumber.ToUpper();
            if (NewMapnumberCheck.Check(mapnumber)) { return mapnumber; }
            return "";
        }

        public static string ToOldMapnumber(string mapnumber) {
            if (!NewMapnumberCheck.Check(mapnumber)) { return ""; }
            NewMapnumber.GetInfo(mapnumber, out bool success, out string m100WRow, out string m100WColumn, out string scale, out string row, out string column);
            if (!success) { return ""; }

            if (scale.Length != 1) { throw new Exception(); }
            var scaleChr = scale[0];
            var scaleNumber = NewMapnumber.NewMapnumberGetScaleDenominatorNumberByScaleStr(scaleChr);

            switch (scaleNumber) {
                case 1000000: { return ToOldMapnumber100W(m100WRow, m100WColumn); }
                case 500000: {
                        var o100W = ToOldMapnumber100W(m100WRow, m100WColumn);
                        var o50W = ToOld50WNum(row, column);
                        var o50WStr = OldMapnumber.Change1234ToABCD(o50W);
                        if (string.IsNullOrEmpty(o50WStr)) { return ""; }
                        return o100W + "-" + o50WStr;
                    }
                case 250000: {
                        var o100W = ToOldMapnumber100W(m100WRow, m100WColumn);
                        var o25W = ToOld25WNum(row, column);
                        if (o25W <= 0 || o25W > 16) { return ""; }
                        return o100W + "-[" + o25W.ToString("00") + "]";
                    }
                case 100000: {
                        var o100W = ToOldMapnumber100W(m100WRow, m100WColumn);
                        var o10W = ToOld10WNum(row, column);
                        if (o10W <= 0 || o10W > 144) { return ""; }
                        return o100W + "-" + o10W.ToString("000");
                    }
                case 50000: {
                        var o100W = ToOldMapnumber100W(m100WRow, m100WColumn);
                        var o5W = ToOld5WNum(row, column);
                        var o5WStr = OldMapnumber.Change1234ToABCD(o5W);
                        if (string.IsNullOrEmpty(o5WStr)) { return ""; }
                        var n10WR = New5WRCToNew10WRC(int.Parse(row));
                        var n10WC = New5WRCToNew10WRC(int.Parse(column));
                        var o10W = ToOld10WNum(n10WR.ToString(), n10WC.ToString());
                        if (o10W <= 0 || o10W > 144) { return ""; }
                        return o100W + "-" + o10W.ToString("000") + "-" + o5WStr;
                    }
                case 25000: {
                        var o100W = ToOldMapnumber100W(m100WRow, m100WColumn);
                        var o2_5W = ToOld2_5WNum(row, column);
                        if (o2_5W <= 0 || o2_5W > 4) { return ""; }
                        var n5WR = New2_5WRCToNew5WRC(int.Parse(row));
                        var n5WC = New2_5WRCToNew5WRC(int.Parse(column));
                        var o5W = ToOld5WNum(n5WR.ToString(), n5WC.ToString());
                        var o5WStr = OldMapnumber.Change1234ToABCD(o5W);
                        if (string.IsNullOrEmpty(o5WStr)) { return ""; }
                        var n10WR = New5WRCToNew10WRC(n5WR);
                        var n10WC = New5WRCToNew10WRC(n5WC);
                        var o10W = ToOld10WNum(n10WR.ToString(), n10WC.ToString());
                        if (o10W <= 0 || o10W > 144) { return ""; }
                        return o100W + "-" + o10W.ToString("000") + "-" + o5WStr + "-" + o2_5W.ToString();
                    }
                case 10000: {
                        var o100W = ToOldMapnumber100W(m100WRow, m100WColumn);
                        var o1W = ToOld1WNum(row, column);
                        if (o1W <= 0 || o1W > 64) { return ""; }
                        var n10WR = New1WRCToNew10WRC(int.Parse(row));
                        var n10WC = New1WRCToNew10WRC(int.Parse(column));
                        var o10W = ToOld10WNum(n10WR.ToString(), n10WC.ToString());
                        if (o10W <= 0 || o10W > 144) { return ""; }
                        return o100W + "-" + o10W.ToString("000") + "-(" + o1W.ToString("00") + ")";
                    }
                case 5000: {
                        var o100W = ToOldMapnumber100W(m100WRow, m100WColumn);
                        var o0_5W = ToOld5KNum(row, column);
                        var o0_5WStr = OldMapnumber.Change1234Toabcd(o0_5W);
                        if (string.IsNullOrEmpty(o0_5WStr)) { return ""; }
                        var n1WR = New5KRCToNew1WRC(int.Parse(row));
                        var n1WC = New5KRCToNew1WRC(int.Parse(column));
                        var o1W = ToOld1WNum(n1WR.ToString(), n1WC.ToString());
                        if (o1W <= 0 || o1W > 64) { return ""; }
                        var n10WR = New1WRCToNew10WRC(n1WR);
                        var n10WC = New1WRCToNew10WRC(n1WC);
                        var o10W = ToOld10WNum(n10WR.ToString(), n10WC.ToString());
                        if (o10W <= 0 || o10W > 144) { return ""; }
                        return o100W + "-" + o10W.ToString("000") + "-(" + o1W.ToString("00") + ")-" + o0_5WStr;
                    }
                default: { return null; }
            }
        }

        private static string ToOldMapnumber100W(string newMapnumber100WRow, string newMapnumber100WColumn) {
            return newMapnumber100WRow + "-" + newMapnumber100WColumn;
        }

        private static int ToOld50WNum(string newMapnumber50WR, string newMapnumber50WC) {
            int n50WR = int.Parse(newMapnumber50WR);
            int n50WC = int.Parse(newMapnumber50WC);
            return 2 * (n50WR - 1) + n50WC;
        }

        private static int ToOld25WNum(string newMapnumber25WR, string newMapnumber25WC) {
            int n25WR = int.Parse(newMapnumber25WR);
            int n25WC = int.Parse(newMapnumber25WC);
            return 4 * (n25WR - 1) + n25WC;
        }

        private static int ToOld10WNum(string newMapnumber10WR, string newMapnumber10WC) {
            int n10WR = int.Parse(newMapnumber10WR);
            int n10WC = int.Parse(newMapnumber10WC);
            return 12 * (n10WR - 1) + n10WC;
        }

        private static int ToOld5WNum(string newMapnumber5WR, string newMapnumber5WC) {
            int n5WR = int.Parse(newMapnumber5WR);
            int n5WC = int.Parse(newMapnumber5WC);
            return 2 * n5WR + n5WC - (4 * ((n5WR - 1) / 2)) - (2 * ((n5WC - 1) / 2)) - 2;
        }

        private static int ToOld2_5WNum(string newMapnumber2_5WR, string newMapnumber2_5WC) {
            int n2_5WR = int.Parse(newMapnumber2_5WR);
            int n2_5WC = int.Parse(newMapnumber2_5WC);
            return 2 * n2_5WR + n2_5WC - (4 * ((n2_5WR - 1) / 2)) - (2 * ((n2_5WC - 1) / 2)) - 2;
        }

        private static int ToOld1WNum(string newMapnumber1WR, string newMapnumber1WC) {
            int n1WR = int.Parse(newMapnumber1WR);
            int n1WC = int.Parse(newMapnumber1WC);
            return 8 * n1WR + n1WC - (64 * ((n1WR - 1) / 8)) - (8 * ((n1WC - 1) / 8)) - 8;
        }

        private static int ToOld5KNum(string newMapnumber5KR, string newMapnumber5KC) {
            int n0_5WR = int.Parse(newMapnumber5KR);
            int n0_5WC = int.Parse(newMapnumber5KC);
            return 2 * n0_5WR + n0_5WC - (4 * ((n0_5WR - 1) / 2)) - (2 * ((n0_5WC - 1) / 2)) - 2;
        }

        private static int New5WRCToNew10WRC(int newMapnumber5WRC) {
            return (newMapnumber5WRC - 1) / 2 + 1;
        }

        private static int New2_5WRCToNew5WRC(int newMapnumber2_5WRC) {
            return (newMapnumber2_5WRC - 1) / 2 + 1;
        }

        private static int New1WRCToNew10WRC(int newMapnumber1WRC) {
            return (newMapnumber1WRC - 1) / 8 + 1;
        }

        private static int New5KRCToNew1WRC(int newMapnumber5KRC) {
            return (newMapnumber5KRC - 1) / 2 + 1;
        }

    }
}
