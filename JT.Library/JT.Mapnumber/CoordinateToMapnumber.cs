using System;
namespace JT.Mapnumber {
    public static class CoordinateToMapnumber {
        public static string NewMapnumberFromLongitudeLatitude(decimal longitude, decimal latitude, int scaleDenominator) {
            var newMapnumber_100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(newMapnumber_100W)) { return null; }
            LongitudeLatitudeDifferent.LongitudeLatitudeDifferenceByScaleDenominator(scaleDenominator, out bool success, out decimal longitudeDifference, out decimal latitudeDifference);
            if (!success) { throw new Exception(); }

            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, longitudeDifference, latitudeDifference, out int row, out int column);
            string scaleStr = NewMapnumber.ScaleString(scaleDenominator);
            string r = "";
            string c = "";
            if (scaleStr == "J" || scaleStr == "K") {
                r = row.ToString("0000");
                c = column.ToString("0000");
            } else {
                r = row.ToString("000");
                c = column.ToString("000");
            }
            if (string.IsNullOrEmpty(scaleStr)) {
                scaleStr = "";
                r = "";
                c = "";
            }
            string newMapnumber = newMapnumber_100W + scaleStr + r + c;
            if (!NewMapnumberCheck.Check(newMapnumber)) { return null; }
            return newMapnumber;
        }

        public static string NewMapnumber100WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var rNum = (int)(latitude / LongitudeLatitudeDifferent.MAPNUMBER_100W_LATITUDE_DIFFERENT) + 1;
            var cNum = (int)(longitude / LongitudeLatitudeDifferent.MAPNUMBER_100W_LONGITUDE_DIFFERENT) + 31;
            var rStr = Mapnumber100W.RowDigitalToString(rNum);
            var n100W = rStr + cNum.ToString("00");
            if (!NewMapnumberCheck.Check(n100W)) { return null; }
            return n100W;
        }

        public static string NewMapnumber50WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_50W_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_50W_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("000");
            var c = column.ToString("000");
            var n50W = n100W + "B" + r + c;
            if (!NewMapnumberCheck.Check(n50W)) { return null; }
            return n50W;
        }

        public static string NewMapnumber25WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_25W_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_25W_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("000");
            var c = column.ToString("000");
            var n25W = n100W + "C" + r + c;
            if (!NewMapnumberCheck.Check(n25W)) { return null; }
            return n25W;
        }

        public static string NewMapnumber10WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_10W_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_10W_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("000");
            var c = column.ToString("000");
            var n10W = n100W + "D" + r + c;
            if (!NewMapnumberCheck.Check(n10W)) { return null; }
            return n10W;
        }

        public static string NewMapnumber5WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_5W_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_5W_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("000");
            var c = column.ToString("000");
            var n5W = n100W + "E" + r + c;
            if (!NewMapnumberCheck.Check(n5W)) { return null; }
            return n5W;
        }

        public static string NewMapnumber2_5WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_2_5W_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_2_5W_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("000");
            var c = column.ToString("000");
            var n2_5W = n100W + "F" + r + c;
            if (!NewMapnumberCheck.Check(n2_5W)) { return null; }
            return n2_5W;
        }

        public static string NewMapnumber1WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_1W_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_1W_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("000");
            var c = column.ToString("000");
            var n1W = n100W + "G" + r + c;
            if (!NewMapnumberCheck.Check(n1W)) { return null; }
            return n1W;
        }

        public static string NewMapnumber5KFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_5K_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_5K_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("000");
            var c = column.ToString("000");
            var n0_5W = n100W + "H" + r + c;
            if (!NewMapnumberCheck.Check(n0_5W)) { return null; }
            return n0_5W;
        }

        public static string NewMapnumber2KFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_2K_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_2K_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("000");
            var c = column.ToString("000");
            var n0_2W = n100W + "I" + r + c;
            if (!NewMapnumberCheck.Check(n0_2W)) { return null; }
            return n0_2W;
        }

        public static string NewMapnumber1KFromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_1K_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_1K_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("0000");
            var c = column.ToString("0000");
            var n0_1W = n100W + "J" + r + c;
            if (!NewMapnumberCheck.Check(n0_1W)) { return null; }
            return n0_1W;
        }

        public static string NewMapnumber500FromLongitudeLatitude(decimal longitude, decimal latitude) {
            var n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_500_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_500_LATITUDE_DIFFERENT, out int row, out int column);
            var r = row.ToString("0000");
            var c = column.ToString("0000");
            var n500 = n100W + "K" + r + c;
            if (!NewMapnumberCheck.Check(n500)) { return null; }
            return n500;
        }

        private static void NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(decimal longitude, decimal latitude, decimal longitudeDifferent, decimal latitudeDifferent, out int row, out int column) {
            row = (int)(Math.Round(LongitudeLatitudeDifferent.MAPNUMBER_100W_LONGITUDE_DIFFERENT / latitudeDifferent, MidpointRounding.AwayFromZero)) - (int)(latitude % LongitudeLatitudeDifferent.MAPNUMBER_100W_LONGITUDE_DIFFERENT / latitudeDifferent);
            column = (int)((int)((longitude % LongitudeLatitudeDifferent.MAPNUMBER_100W_LATITUDE_DIFFERENT) / longitudeDifferent)) + 1;
        }

        public static string OldMapnumberFromLongitudeLatitude(decimal longitude, decimal latitude, int scaleDenominator) {
            string n100W = NewMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(n100W)) { return null; }
            LongitudeLatitudeDifferent.LongitudeLatitudeDifferenceByScaleDenominator(scaleDenominator, out bool success, out decimal JC, out decimal WC);

            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, JC, WC, out int row, out int column);
            string scaleStr = NewMapnumber.ScaleString(scaleDenominator);
            if (scaleDenominator == 200000) {
                return OldMapnumber20WFromLongitudeLatitude(longitude, latitude);
            } else {
                string r = "";
                string c = "";
                if (scaleStr == "J" || scaleStr == "K") {
                    r = row.ToString("0000");
                    c = column.ToString("0000");
                } else {
                    r = row.ToString("000");
                    c = column.ToString("000");
                }
                if (string.IsNullOrEmpty(scaleStr)) {
                    scaleStr = "";
                    r = "";
                    c = "";
                }
                string newMapnumber = n100W + scaleStr + r + c;
                if (NewMapnumberCheck.Check(newMapnumber)) {
                    string oldMapnumber = NewMapnumberToMapnumber.ToOldMapnumber(newMapnumber);
                    if (OldMapnumberCheck.Check(oldMapnumber)) {
                        return oldMapnumber;
                    }
                }
                return null;
            }
        }

        public static string OldMapnumber100WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            int rNum = (int)(latitude / LongitudeLatitudeDifferent.MAPNUMBER_100W_LONGITUDE_DIFFERENT) + 1;
            int cNum = (int)(longitude / LongitudeLatitudeDifferent.MAPNUMBER_100W_LATITUDE_DIFFERENT) + 31;
            string rStr = Mapnumber100W.RowDigitalToString(rNum);
            string o100W = rStr + "-" + cNum.ToString("00");
            if (OldMapnumberCheck.Check100W(o100W)) { return o100W; }
            return null;
        }

        public static string OldMapnumber20WFromLongitudeLatitude(decimal longitude, decimal latitude) {
            string o100W = OldMapnumber100WFromLongitudeLatitude(longitude, latitude);
            if (string.IsNullOrEmpty(o100W)) { return null; }
            NewMapnumberRowColumnNumIn100WFromLongitudeLatitude(longitude, latitude, LongitudeLatitudeDifferent.MAPNUMBER_20W_LONGITUDE_DIFFERENT, LongitudeLatitudeDifferent.MAPNUMBER_20W_LATITUDE_DIFFERENT, out int row, out int column);
            int o20WNum = OldMapnumber20WNum(row, column);
            string o20W = o100W + "-(" + o20WNum.ToString("00") + ")";
            if (OldMapnumberCheck.Check20W(o20W)) {
                return o20W;
            }
            return null;
        }

        private static int OldMapnumber20WNum(int n20WRow, int n20WColumn) {
            return OldMapnumberDefine.MaxCount20W * (n20WRow - 1) + n20WColumn;
        }

    }
}
