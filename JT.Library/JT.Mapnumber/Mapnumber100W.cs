using System;
using static JT.Mapnumber.MapnumberCommon;
namespace JT.Mapnumber {
    public static class Mapnumber100W {

        public const int ColumnMinValue = 1;
        public const int ColumnMaxValue = 60;

        private static string[] columnNums = null;
        public static string[] ColumnNums {
            get {
                if (columnNums == null) {
                    columnNums = new string[ColumnMaxValue - ColumnMinValue + 1];
                    for (int i = ColumnMinValue; i <= ColumnMaxValue; i++) {
                        columnNums[i - 1] = i.ToString("00");
                    }
                }
                return columnNums;
            }
        }

        private static string[] rowNums = null;
        public static string[] RowNums {
            get {
                if (rowNums == null) {
                    rowNums = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", };
                }
                return rowNums;
            }
        }

        //public static readonly string[] MAPNUMBER_100W_ROWNUM = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", };

        //public static readonly string[] MAPNUMBER_100W_COLUMNNUM = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", };

        public static bool ValidateRowNum(string rownum) {
            return Contain(RowNums, rownum);
        }

        public static bool ValidateColumnNum(string columnnum) {
            return Contain(ColumnNums, columnnum);
        }

        public static string RowDigitalToString(int rownum) {
            switch (rownum) {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
                case 9:
                    return "I";
                case 10:
                    return "J";
                case 11:
                    return "K";
                case 12:
                    return "L";
                case 13:
                    return "M";
                case 14:
                    return "N";
                case 15:
                    return "O";
                case 16:
                    return "P";
                case 17:
                    return "Q";
                case 18:
                    return "R";
                case 19:
                    return "S";
                case 20:
                    return "T";
                case 21:
                    return "U";
                case 22:
                    return "V";
                default:
                    throw new Exception();
            }
        }

        public static int RowStringToDigital(string rowstr) {
            switch (rowstr) {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "J":
                    return 10;
                case "K":
                    return 11;
                case "L":
                    return 12;
                case "M":
                    return 13;
                case "N":
                    return 14;
                case "O":
                    return 15;
                case "P":
                    return 16;
                case "Q":
                    return 17;
                case "R":
                    return 18;
                case "S":
                    return 19;
                case "T":
                    return 20;
                case "U":
                    return 21;
                case "V":
                    return 22;
                default:
                    throw new Exception();
            }
        }

    }
}
