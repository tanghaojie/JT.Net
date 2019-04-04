using System;
namespace JT.Mapnumber {
    public static class OldMapnumberCheck {

        public static bool Check(string mapnumber) {
            if (string.IsNullOrEmpty(mapnumber) || !mapnumber.Contains("-")) { return false; }
            string[] split = mapnumber.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (!ValidateSplitedSegmentLength(length)) { return false; }
            if (length == 2) {
                return Check100W(mapnumber);
            } else if (length == 3) {
                return Check50W(mapnumber) || Check25W(mapnumber) || Check20W(mapnumber) || Check10W(mapnumber);
            } else if (length == 4) {
                return Check5W(mapnumber) || Check1W(mapnumber);
            } else if (length == 5) {
                return Check2_5W(mapnumber) || Check5K(mapnumber);
            }
            return false;
        }

        public static bool Check100W(string mapnumber100W) {
            if (string.IsNullOrEmpty(mapnumber100W) || !mapnumber100W.Contains("-")) { return false; }
            string[] split = mapnumber100W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            return split.Length == 2 && Mapnumber100W.ValidateRowNum(split[0]) && Mapnumber100W.ValidateColumnNum(split[1]);
        }

        public static bool Check50W(string mapnumber50W) {
            if (string.IsNullOrEmpty(mapnumber50W) || !mapnumber50W.Contains("-")) { return false; }
            string[] split = mapnumber50W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            return split.Length == 3 && Mapnumber100W.ValidateRowNum(split[0]) && Mapnumber100W.ValidateColumnNum(split[1]) && Contain(OldMapnumberDefine.ABCD, split[2]);
        }

        public static bool Check25W(string mapnumber25W) {
            if (string.IsNullOrEmpty(mapnumber25W) || !mapnumber25W.Contains("-") || !mapnumber25W.Contains("[") || !mapnumber25W.Contains("]")) { return false; }
            string[] split = mapnumber25W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 3 || !Mapnumber100W.ValidateRowNum(split[0]) || !Mapnumber100W.ValidateColumnNum(split[1])) { return false; }
            string k = split[2];
            string[] subSplit = k.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            int len = subSplit.Length;
            if (len != 1) { return false; }
            int sum = OldMapnumber.SumCount(OldMapnumberDefine.MaxCount25W);
            string[] strs = OldMapnumber.AllAllowedNums(sum);
            return MapnumberCommon.Contain(strs, subSplit[0]);
        }

        public static bool Check20W(string mapnumber20W) {
            if (string.IsNullOrEmpty(mapnumber20W) || !mapnumber20W.Contains("-") || !mapnumber20W.Contains("(") || !mapnumber20W.Contains(")")) { return false; }
            string[] split = mapnumber20W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 3 || !Mapnumber100W.ValidateRowNum(split[0]) || !Mapnumber100W.ValidateColumnNum(split[1])) { return false; }
            string k = split[2];
            string[] subSplit = k.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            if (subSplit.Length != 1) { return false; }
            string sub = subSplit[0];
            int sum = OldMapnumber.SumCount(OldMapnumberDefine.MaxCount20W);
            string[] strs = OldMapnumber.AllAllowedNums(sum);
            return MapnumberCommon.Contain(strs, sub);
        }

        public static bool Check10W(string mapnumber10W) {
            if (string.IsNullOrEmpty(mapnumber10W) || !mapnumber10W.Contains("-")) { return false; }
            string[] split = mapnumber10W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 3 || !Mapnumber100W.ValidateRowNum(split[0]) || !Mapnumber100W.ValidateColumnNum(split[1])) { return false; }
            string sub = split[2];
            int sum = OldMapnumber.SumCount(OldMapnumberDefine.MaxCount10W);
            string[] strs = OldMapnumber.AllAllowedNums(sum);
            return MapnumberCommon.Contain(strs, sub);
        }

        public static bool Check5W(string mapnumber5W) {
            if (string.IsNullOrEmpty(mapnumber5W) || !mapnumber5W.Contains("-")) { return false; }
            string[] split = mapnumber5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 4) { return false; }
            string o10W = split[0] + "-" + split[1] + "-" + split[2];
            return Check10W(o10W) && Contain(OldMapnumberDefine.ABCD, split[3]);
        }

        public static bool Check2_5W(string mapnumber2_5W) {
            if (string.IsNullOrEmpty(mapnumber2_5W) || !mapnumber2_5W.Contains("-")) { return false; }
            string[] split = mapnumber2_5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 5) { return false; }
            string o5W = split[0] + "-" + split[1] + "-" + split[2] + "-" + split[3];
            return Check5W(o5W) && Contain(OldMapnumberDefine.num1234, split[4]);
        }

        public static bool Check1W(string mapnumber1W) {
            if (string.IsNullOrEmpty(mapnumber1W) || !mapnumber1W.Contains("-") || !mapnumber1W.Contains("(") || !mapnumber1W.Contains(")")) { return false; }
            string[] split = mapnumber1W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 4) { return false; }
            string o10W = split[0] + "-" + split[1] + "-" + split[2];
            if (!Check10W(o10W)) { return false; }
            string k = split[3];
            string[] subSplit = k.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            if (subSplit.Length != 1) { return false; }
            string sub = subSplit[0];
            int sum = OldMapnumber.SumCount(OldMapnumberDefine.MaxCount1W);
            string[] strs = OldMapnumber.AllAllowedNums(sum);
            return MapnumberCommon.Contain(strs, sub);
        }

        public static bool Check5K(string mapnumber5K) {
            if (string.IsNullOrEmpty(mapnumber5K) || !mapnumber5K.Contains("-") || !mapnumber5K.Contains("(") || !mapnumber5K.Contains(")")) { return false; }
            string[] split = mapnumber5K.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 5) { return false; }
            string o1W = split[0] + "-" + split[1] + "-" + split[2] + "-" + split[3];
            return Check1W(o1W) && Contain(OldMapnumberDefine.abcd, split[4]);
        }

        private static bool ValidateSplitedSegmentLength(int splitedLength) {
            return splitedLength >= 2 && splitedLength <= 5;
        }

        private static bool Contain(char[] chrs, string str) {
            if (chrs == null || chrs.Length <= 0) { return false; }
            foreach (var chr in chrs) {
                if (chr.ToString() == str) { return true; }
            }
            return false;
        }

    }
}
