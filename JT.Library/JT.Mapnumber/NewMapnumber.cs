using System;
using static JT.Mapnumber.MapnumberCommon;
namespace JT.Mapnumber {
    public static class NewMapnumber {
        public static string[] AllAllowedNums(int maxCount) {
            string[] numStr = new string[maxCount];
            if (maxCount < 999) {
                for (int q = 1; q <= maxCount; q++) {
                    numStr[q - 1] = q.ToString("000");
                }
            } else {
                for (int q = 1; q <= maxCount; q++) {
                    numStr[q - 1] = q.ToString("0000");
                }
            }
            return numStr;
        }

        public static string[] AllNumsByScale(char scaleChr) {
            var all = NewMapnumberDefine.All;
            var allCount = all.Length;
            for (int i = 0; i < allCount; i++) {
                var item = all[i];
                if (item.ScaleChar == scaleChr) {
                    return AllAllowedNums(item.MaxCount);
                }
            }
            return new string[0];
        }

        public static bool ValidateScaleChar(char scaleChr) {
            return Contain(NewMapnumberDefine.Scales, scaleChr);
        }

        public static bool ValidateNumByScale(char scale, string num) {
            if (!Contain(NewMapnumberDefine.Scales, scale)) { return false; }
            string[] all = AllNumsByScale(scale);
            return Contain(all, num);
        }

        public static bool ValidateRowColumnNumByScale(char scale, string rowNum, string columnNum) {
            return ValidateNumByScale(scale, rowNum) && ValidateNumByScale(scale, columnNum);
        }

        public static decimal NewMapnumberGetScaleDenominatorNumberByScaleStr(char scaleChr) {
            var all = NewMapnumberDefine.All;
            var allCount = all.Length;
            for (int i = 0; i < allCount; i++) {
                var item = all[i];
                if (item.ScaleChar == scaleChr) {
                    return item.ScaleDenominator;
                }
            }
            throw new Exception();
        }

        public static void GetInfo(string mapnumber, out bool succcess, out string m100WRow, out string m100WColumn, out string scale, out string rownum, out string columnnum) {
            m100WRow = null;
            m100WColumn = null;
            scale = null;
            rownum = null;
            columnnum = null;
            if (!NewMapnumberCheck.Check(mapnumber)) {
                succcess = false;
                return;
            }
            int length = mapnumber.Length;
            m100WRow = mapnumber.Substring(0, 1);
            m100WColumn = mapnumber.Substring(1, 2);
            if (length > 3) {
                scale = mapnumber.Substring(3, 1);
                if (length == 10) {
                    rownum = mapnumber.Substring(4, 3);
                    columnnum = mapnumber.Substring(7, 3);
                } else {
                    rownum = mapnumber.Substring(4, 4);
                    columnnum = mapnumber.Substring(8, 4);
                }
            }
            succcess = true;
        }

        public static string ScaleString(int scaleDenominator) {
            switch (scaleDenominator) {
                case 1000000:
                    return "";
                case 500000:
                    return "B";
                case 250000:
                    return "C";
                case 100000:
                    return "D";
                case 50000:
                    return "E";
                case 25000:
                    return "F";
                case 10000:
                    return "G";
                case 5000:
                    return "H";
                case 2000:
                    return "I";
                case 1000:
                    return "J";
                case 500:
                    return "K";
                default:
                    return null;
            }
        }

    }
}
