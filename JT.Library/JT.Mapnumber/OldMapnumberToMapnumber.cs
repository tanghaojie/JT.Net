using System;
namespace JT.Mapnumber {
    public static class OldMapnumberToMapnumber {

        public static string ToNewMapnumber(string oldMapnumber) {
            if (!OldMapnumberCheck.Check(oldMapnumber)) { return ""; }
            var result = "";
            result = ToNewMapnumber100W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) { return result; }

            result = ToNewMapnumber50W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) { return result; }

            result = ToNewMapnumber25W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) { return result; }

            result = ToNewMapnumber10W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) { return result; }

            result = ToNewMapnumber5W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) { return result; }

            result = ToNewMapnumber2_5W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) { return result; }

            result = ToNewMapnumber1W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) { return result; }

            result = ToNewMapnumber5K(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) { return result; }

            return result;
        }

        public static string ToNewMapnumber100W(string oldMapnumber100W) {
            if (!OldMapnumberCheck.Check100W(oldMapnumber100W)) { return ""; }
            var temp = oldMapnumber100W.Split('-');
            var new100 = temp[0] + temp[1].PadLeft(2, '0');
            return new100;
        }

        public static string ToNewMapnumber50W(string oldMapnumber50W) {
            if (!OldMapnumberCheck.Check50W(oldMapnumber50W)) { return ""; }
            var temp = oldMapnumber50W.Split('-');
            var new100 = temp[0] + temp[1].PadLeft(2, '0');
            var chrStr = temp[2];
            if (chrStr.Length != 1) { return ""; }
            var x = OldMapnumber.ChangeABCDabcdTo1234(chrStr[0]);
            if (x <= 0) { return ""; }
            var new50R = ToNew50WRow(x);
            var new50C = ToNew50WColumn(x);
            return new100 + "B" + new50R.ToString().PadLeft(3, '0') + new50C.ToString().PadLeft(3, '0');
        }

        public static string ToNewMapnumber25W(string oldMapnumber25W) {
            if (!OldMapnumberCheck.Check25W(oldMapnumber25W)) { return ""; }
            var temp = oldMapnumber25W.Split('-');
            var new100 = temp[0] + temp[1].PadLeft(2, '0');
            var sub25W = temp[2];
            var subTemp = sub25W.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            if (!int.TryParse(subTemp[0], out int x)) { return ""; }
            var new25R = ToNew25WRow(x);
            var new25C = ToNew25WColumn(x);
            return new100 + "C" + new25R.ToString().PadLeft(3, '0') + new25C.ToString().PadLeft(3, '0');
        }

        public static string ToNewMapnumber10W(string oldMapnumber10W) {
            if (!OldMapnumberCheck.Check10W(oldMapnumber10W)) { return ""; }
            var temp = oldMapnumber10W.Split('-');
            var new100 = temp[0] + temp[1].PadLeft(2, '0');
            var sub10W = temp[2];
            if (!int.TryParse(sub10W, out int x)) { return ""; }
            var new10R = ToNew10WRow(x);
            var new10C = ToNew10WColumn(x);
            return new100 + "D" + new10R.ToString().PadLeft(3, '0') + new10C.ToString().PadLeft(3, '0');
        }

        public static string ToNewMapnumber5W(string oldMapnumber5W) {
            if (!OldMapnumberCheck.Check5W(oldMapnumber5W)) { return ""; }
            var temp = oldMapnumber5W.Split('-');
            var new100 = temp[0] + temp[1].PadLeft(2, '0');
            var sub10W = temp[2];
            if (!int.TryParse(sub10W, out int x)) { return ""; }
            var new10R = ToNew10WRow(x);
            var new10C = ToNew10WColumn(x);
            var chrStr = temp[3];
            if (chrStr.Length != 1) { return ""; }
            var sub5W = OldMapnumber.ChangeABCDabcdTo1234(chrStr[0]);
            var new5R = ToNew5WRow(sub5W, new10R);
            var new5C = ToNew5WColumn(sub5W, new10C);
            return new100 + "E" + new5R.ToString().PadLeft(3, '0') + new5C.ToString().PadLeft(3, '0');

        }

        public static string ToNewMapnumber2_5W(string oldMapnumber2_5W) {
            if (!OldMapnumberCheck.Check2_5W(oldMapnumber2_5W)) { return ""; }
            var temp = oldMapnumber2_5W.Split('-');
            var new100 = temp[0] + temp[1].PadLeft(2, '0');
            var sub10W = temp[2];
            if (!int.TryParse(sub10W, out int x)) { return ""; }
            var new10R = ToNew10WRow(x);
            var new10C = ToNew10WColumn(x);
            var chrStr = temp[3];
            if (chrStr.Length != 1) { return ""; }
            var sub5W = OldMapnumber.ChangeABCDabcdTo1234(chrStr[0]);
            var new5R = ToNew5WRow(sub5W, new10R);
            var new5C = ToNew5WColumn(sub5W, new10C);
            var sub2_5W = int.Parse(temp[4]);
            var new2_5R = ToNew2_5WRow(sub2_5W, new5R);
            var new2_5C = ToNew2_5WColumn(sub2_5W, new5C);
            var new2 = new100 + "F" + new2_5R.ToString().PadLeft(3, '0') + new2_5C.ToString().PadLeft(3, '0');
            return new2;
        }

        public static string ToNewMapnumber1W(string oldMapnumber1W) {
            if (!OldMapnumberCheck.Check1W(oldMapnumber1W)) { return ""; }
            var temp = oldMapnumber1W.Split('-');
            var new100 = temp[0] + temp[1].PadLeft(2, '0');
            var sub10W = temp[2];
            if (!int.TryParse(sub10W, out int x)) { return ""; }
            var new10R = ToNew10WRow(x);
            var new10C = ToNew10WColumn(x);
            var sub1W = temp[3];
            var subTemp = sub1W.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            if (!int.TryParse(subTemp[0], out int k)) { return ""; }
            var new1R = ToNew1WRow(k, new10R);
            var new1C = ToNew1WColumn(k, new10C);
            return new100 + "G" + new1R.ToString().PadLeft(3, '0') + new1C.ToString().PadLeft(3, '0');

        }

        public static string ToNewMapnumber5K(string oldMapnumber5K) {
            if (!OldMapnumberCheck.Check5K(oldMapnumber5K)) { return ""; }
            var temp = oldMapnumber5K.Split('-');
            var new100 = temp[0] + temp[1].PadLeft(2, '0');
            var sub10W = temp[2];
            if (!int.TryParse(sub10W, out int x)) { return ""; }
            var new10R = ToNew10WRow(x);
            var new10C = ToNew10WColumn(x);
            var sub1W = temp[3];
            var subTemp = sub1W.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            if (!int.TryParse(subTemp[0], out int k)) { return ""; }
            var new1R = ToNew1WRow(k, new10R);
            var new1C = ToNew1WColumn(k, new10C);
            var sub0_5W = temp[4];
            var chrStr = temp[4];
            if (chrStr.Length != 1) { return ""; }
            var l = OldMapnumber.ChangeABCDabcdTo1234(chrStr[0]);
            var new0_5R = ToNew5KRow(l, new1R);
            var new0_5C = ToNew5KColumn(l, new1C);
            return new100 + "H" + new0_5R.ToString().PadLeft(3, '0') + new0_5C.ToString().PadLeft(3, '0');
        }


        private static int ToNew50WRow(int oldMapnumberSub50W) {
            return (oldMapnumberSub50W - 1) / 2 + 1;
        }

        private static int ToNew50WColumn(int oldMapnumberSub50W) {
            return (oldMapnumberSub50W + 1) % 2 + 1;
        }

        private static int ToNew25WRow(int oldMapnumberSub25W) {
            return ((oldMapnumberSub25W - 1) / 4) + 1;
        }

        private static int ToNew25WColumn(int oldMapnumberSub25W) {
            return ((oldMapnumberSub25W + 3) % 4) + 1;
        }

        private static int ToNew10WRow(int oldMapnumberSub10W) {
            return ((oldMapnumberSub10W - 1) / 12) + 1;
        }

        private static int ToNew10WColumn(int oldMapnumberSub10W) {
            return ((oldMapnumberSub10W + 11) % 12) + 1;
        }

        private static int ToNew5WRow(int oldMapnumberSub5W, int new10Row) {
            return (2 * new10Row) + ((oldMapnumberSub5W - 1) / 2 - 1);
        }

        private static int ToNew5WColumn(int oldMapnumberSub5W, int new10Column) {
            return (2 * new10Column) + ((oldMapnumberSub5W + 1) % 2 - 1);
        }

        private static int ToNew2_5WRow(int oldMapnumberSub2_5W, int new5Row) {
            return 2 * new5Row + (oldMapnumberSub2_5W - 1) / 2 - 1;
        }

        private static int ToNew2_5WColumn(int oldMapnumberSub2_5W, int new5Column) {
            return 2 * new5Column + (oldMapnumberSub2_5W + 1) % 2 - 1;
        }

        private static int ToNew1WRow(int oldMapnumberSub1W, int new10Row) {
            return 8 * new10Row + ((oldMapnumberSub1W - 1) / 8) - 7;
        }

        private static int ToNew1WColumn(int oldMapnumberSub1W, int new10Column) {
            return 8 * new10Column + ((oldMapnumberSub1W + 7) % 8) - 7;
        }

        private static int ToNew5KRow(int oldMapnumberSub5K, int new1Row) {
            return 2 * new1Row + (oldMapnumberSub5K - 1) / 2 - 1;
        }

        private static int ToNew5KColumn(int oldMapnumberSub5K, int new1Column) {
            return 2 * new1Column + (oldMapnumberSub5K + 1) % 2 - 1;
        }


        public static string ToOldMapnumber(string oldMapnumber, int scaleDenominator) {
            switch (scaleDenominator) {
                case 1000000: { return ToOldMapnumber100W(oldMapnumber); }
                case 500000: { return ToOldMapnumber50W(oldMapnumber); }
                case 250000: { return ToOldMapnumber25W(oldMapnumber); }
                case 100000: { return ToOldMapnumber10W(oldMapnumber); }
                case 50000: { return ToOldMapnumber5W(oldMapnumber); }
                case 25000: { return ToOldMapnumber2_5W(oldMapnumber); }
                case 10000: { return ToOldMapnumber1W(oldMapnumber); }
                case 5000: { return ToOldMapnumber5K(oldMapnumber); }
                default: { return ""; }
            }
        }

        private static string ChangeOldMapnumberChar(string oldMapnumber) {
            oldMapnumber = oldMapnumber.Replace("(", "");
            oldMapnumber = oldMapnumber.Replace(")", "");
            oldMapnumber = oldMapnumber.Replace("（", "");
            oldMapnumber = oldMapnumber.Replace("）", "");
            oldMapnumber = oldMapnumber.Replace("【", "");
            oldMapnumber = oldMapnumber.Replace("】", "");
            oldMapnumber = oldMapnumber.Replace("甲", "1");
            oldMapnumber = oldMapnumber.Replace("乙", "2");
            oldMapnumber = oldMapnumber.Replace("丙", "3");
            oldMapnumber = oldMapnumber.Replace("丁", "4");
            oldMapnumber = oldMapnumber.Replace("A", "1");
            oldMapnumber = oldMapnumber.Replace("B", "2");
            oldMapnumber = oldMapnumber.Replace("C", "3");
            oldMapnumber = oldMapnumber.Replace("D", "4");
            oldMapnumber = oldMapnumber.Replace("a", "1");
            oldMapnumber = oldMapnumber.Replace("b", "2");
            oldMapnumber = oldMapnumber.Replace("c", "3");
            oldMapnumber = oldMapnumber.Replace("d", "4");

            oldMapnumber = oldMapnumber.ToUpper();
            foreach (string m100WR in Mapnumber100W.RowNums) {
                oldMapnumber = oldMapnumber.Replace(m100WR, Mapnumber100W.RowStringToDigital(m100WR).ToString());
            }
            return oldMapnumber;
        }

        public static string ToOldMapnumber100W(string oldMapnumber100W) {
            if (string.IsNullOrEmpty(oldMapnumber100W)) { return ""; }
            if (OldMapnumberCheck.Check100W(oldMapnumber100W)) { return oldMapnumber100W; }

            oldMapnumber100W = ChangeOldMapnumberChar(oldMapnumber100W);
            if (!oldMapnumber100W.Contains("-")) { return ""; }
            var split = oldMapnumber100W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var length = split.Length;

            if (length != 2 || !int.TryParse(split[0], out int x100R) || !int.TryParse(split[1], out int x100C)) { return ""; }

            var s100R = Mapnumber100W.RowDigitalToString(x100R);
            var s100C = x100C.ToString("00");
            oldMapnumber100W = s100R + "-" + s100C;
            if (OldMapnumberCheck.Check100W(oldMapnumber100W)) { return oldMapnumber100W; }
            return "";
        }

        public static string ToOldMapnumber50W(string oldMapnumber50W) {
            if (string.IsNullOrEmpty(oldMapnumber50W)) { return ""; }
            if (OldMapnumberCheck.Check50W(oldMapnumber50W)) { return oldMapnumber50W; }

            oldMapnumber50W = ChangeOldMapnumberChar(oldMapnumber50W);
            if (!oldMapnumber50W.Contains("-")) { return ""; }
            var split = oldMapnumber50W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var length = split.Length;
            if (length != 3) { return ""; }
            var x100 = split[0] + "-" + split[1];
            var s100 = ToOldMapnumber100W(x100);

            if (string.IsNullOrEmpty(s100) || !int.TryParse(split[2], out int x50)) { return ""; }
            var s50 = OldMapnumber.Change1234ToABCD(x50);
            oldMapnumber50W = s100 + "-" + s50;
            if (OldMapnumberCheck.Check50W(oldMapnumber50W)) { return oldMapnumber50W; }
            return "";
        }

        public static string ToOldMapnumber25W(string oldMapnumber25W) {
            if (string.IsNullOrEmpty(oldMapnumber25W)) { return ""; }
            if (OldMapnumberCheck.Check25W(oldMapnumber25W)) { return oldMapnumber25W; }

            oldMapnumber25W = ChangeOldMapnumberChar(oldMapnumber25W);
            if (!oldMapnumber25W.Contains("-")) { return ""; }
            var split = oldMapnumber25W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var length = split.Length;
            if (length != 3) { return ""; }
            var x100 = split[0] + "-" + split[1];
            var s100 = ToOldMapnumber100W(x100);

            if (string.IsNullOrEmpty(s100) || !int.TryParse(split[2], out int x25)) { return ""; }
            var s25 = x25.ToString("00");
            oldMapnumber25W = s100 + "-[" + s25 + "]";
            if (OldMapnumberCheck.Check25W(oldMapnumber25W)) { return oldMapnumber25W; }
            return "";
        }

        public static string ToOldMapnumber10W(string oldMapnumber10W) {
            if (string.IsNullOrEmpty(oldMapnumber10W)) { return ""; }
            if (OldMapnumberCheck.Check10W(oldMapnumber10W)) { return oldMapnumber10W; }

            oldMapnumber10W = ChangeOldMapnumberChar(oldMapnumber10W);
            if (!oldMapnumber10W.Contains("-")) { return ""; }
            var split = oldMapnumber10W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var length = split.Length;
            if (length != 3) { return ""; }
            var x100 = split[0] + "-" + split[1];
            var s100 = ToOldMapnumber100W(x100);

            if (string.IsNullOrEmpty(s100) || !int.TryParse(split[2], out int x10)) { return ""; }
            var s10 = x10.ToString("000");
            oldMapnumber10W = s100 + "-" + s10;
            if (OldMapnumberCheck.Check10W(oldMapnumber10W)) { return oldMapnumber10W; }
            return "";
        }

        public static string ToOldMapnumber5W(string oldMapnumber5W) {
            if (string.IsNullOrEmpty(oldMapnumber5W)) { return ""; }
            if (OldMapnumberCheck.Check5W(oldMapnumber5W)) { return oldMapnumber5W; }

            oldMapnumber5W = ChangeOldMapnumberChar(oldMapnumber5W);
            if (!oldMapnumber5W.Contains("-")) { return ""; }
            var split = oldMapnumber5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 4) { return ""; }
            var x10 = split[0] + "-" + split[1] + "-" + split[2];
            var s10 = ToOldMapnumber10W(x10);

            if (string.IsNullOrEmpty(s10) || !int.TryParse(split[3], out int x5)) { return ""; }

            var s5 = OldMapnumber.Change1234ToABCD(x5);
            oldMapnumber5W = s10 + "-" + s5;
            if (OldMapnumberCheck.Check5W(oldMapnumber5W)) { return oldMapnumber5W; }
            return "";
        }

        public static string ToOldMapnumber2_5W(string oldMapnumber2_5W) {
            if (string.IsNullOrEmpty(oldMapnumber2_5W)) { return ""; }

            if (OldMapnumberCheck.Check2_5W(oldMapnumber2_5W)) { return oldMapnumber2_5W; }

            oldMapnumber2_5W = ChangeOldMapnumberChar(oldMapnumber2_5W);
            if (!oldMapnumber2_5W.Contains("-")) { return ""; }

            var split = oldMapnumber2_5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 5) { return ""; }

            var x5 = split[0] + "-" + split[1] + "-" + split[2] + "-" + split[3];
            var s5 = ToOldMapnumber5W(x5);

            if (string.IsNullOrEmpty(s5) || !int.TryParse(split[4], out int x2_5)) { return ""; }

            var s2_5 = x2_5.ToString();
            oldMapnumber2_5W = s5 + "-" + s2_5;
            if (OldMapnumberCheck.Check2_5W(oldMapnumber2_5W)) { return oldMapnumber2_5W; }

            return "";
        }

        public static string ToOldMapnumber1W(string oldMapnumber1W) {
            if (string.IsNullOrEmpty(oldMapnumber1W)) { return ""; }

            if (OldMapnumberCheck.Check1W(oldMapnumber1W)) { return oldMapnumber1W; }

            oldMapnumber1W = ChangeOldMapnumberChar(oldMapnumber1W);
            if (!oldMapnumber1W.Contains("-")) { return ""; }
            var split = oldMapnumber1W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var length = split.Length;
            if (length != 4) { return ""; }
            var x10 = split[0] + "-" + split[1] + "-" + split[2];
            var s10 = ToOldMapnumber10W(x10);

            if (string.IsNullOrEmpty(s10) || !int.TryParse(split[3], out int x1)) { return ""; }
            var s1 = x1.ToString("00");
            oldMapnumber1W = s10 + "-(" + s1 + ")";
            if (OldMapnumberCheck.Check1W(oldMapnumber1W)) { return oldMapnumber1W; }
            return "";
        }

        public static string ToOldMapnumber5K(string oldMapnumber5K) {
            if (string.IsNullOrEmpty(oldMapnumber5K)) { return ""; }

            if (OldMapnumberCheck.Check5K(oldMapnumber5K)) { return oldMapnumber5K; }

            oldMapnumber5K = ChangeOldMapnumberChar(oldMapnumber5K);
            if (!oldMapnumber5K.Contains("-")) { return ""; }

            var split = oldMapnumber5K.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var length = split.Length;
            if (length != 5) { return ""; }

            var x1 = split[0] + "-" + split[1] + "-" + split[2] + "-(" + split[3] + ")";
            var s1 = ToOldMapnumber1W(x1);

            if (string.IsNullOrEmpty(s1) || !int.TryParse(split[4], out int x0_5)) { return ""; }

            var s0_5 = OldMapnumber.Change1234Toabcd(x0_5);
            oldMapnumber5K = s1 + "-" + s0_5;
            if (OldMapnumberCheck.Check5K(oldMapnumber5K)) { return oldMapnumber5K; }

            return "";
        }

    }
}
