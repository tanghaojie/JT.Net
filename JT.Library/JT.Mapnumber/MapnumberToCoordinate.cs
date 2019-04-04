using System;
namespace JT.Mapnumber {
    public static class MapnumberToCoordinate {

        public static void NewMapnumberCornerCoordinates(string newMapnumber, out bool success, out decimal west, out decimal north, out decimal east, out decimal south) {
            success = false;
            west = decimal.Zero;
            north = decimal.Zero;
            east = decimal.Zero;
            south = decimal.Zero;

            NewMapnumber.GetInfo(newMapnumber, out bool infoSuccess, out string m100WRow, out string m100WColumn, out string scale, out string row, out string column);
            if (!infoSuccess) { success = false; return; }

            if (scale.Length != 1) { throw new Exception(); }
            var scaleNumber = NewMapnumber.NewMapnumberGetScaleDenominatorNumberByScaleStr(scale[0]);

            if (scaleNumber <= 0) { success = false; return; }

            var longitudeDiff = decimal.Zero;
            var latitudeDiff = decimal.Zero;
            var r = decimal.Zero;
            var c = decimal.Zero;

            switch (scaleNumber) {
                case 1000000: {
                        west = NewMapnumberWest(m100WColumn);
                        south = NewMapnumberSouth(m100WRow);
                        north = south + LongitudeLatitudeDifferent.MAPNUMBER_100W_LATITUDE_DIFFERENT;
                        east = west + LongitudeLatitudeDifferent.MAPNUMBER_100W_LONGITUDE_DIFFERENT;
                        success = true;
                        return;
                    }
                case 500000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_50W_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_50W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 250000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_25W_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_25W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 100000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_10W_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_10W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 50000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_5W_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_5W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 25000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_2_5W_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_2_5W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 10000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_1W_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_1W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 5000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_5K_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_5K_LATITUDE_DIFFERENT;
                        break;
                    }
                case 2000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_2K_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_2K_LATITUDE_DIFFERENT;
                        break;
                    }
                case 1000: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_1K_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_1K_LATITUDE_DIFFERENT;
                        break;
                    }
                case 500: {
                        if (!decimal.TryParse(column, out c) || !decimal.TryParse(row, out r)) {
                            success = false;
                            return;
                        }
                        longitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_500_LONGITUDE_DIFFERENT;
                        latitudeDiff = LongitudeLatitudeDifferent.MAPNUMBER_500_LATITUDE_DIFFERENT;
                        break;
                    }
                default: {
                        success = false;
                        return;
                    }
            }

            west = NewMapnumberWest(m100WColumn, c, longitudeDiff);
            south = NewMapnumberSouth(m100WRow, r, latitudeDiff);
            north = south + latitudeDiff;
            east = west + longitudeDiff;
            success = true;
        }

        private static decimal NewMapnumberWest(string newMapnumber100WColumn, decimal subColumn = decimal.Zero, decimal subLongitudeDifference = decimal.Zero) {
            if (string.IsNullOrEmpty(newMapnumber100WColumn)) { throw new ArgumentNullException(); }
            if (!decimal.TryParse(newMapnumber100WColumn, out decimal n100WC_d)) { throw new Exception(); }
            return (n100WC_d - 31) * LongitudeLatitudeDifferent.MAPNUMBER_100W_LONGITUDE_DIFFERENT + (subColumn - 1) * subLongitudeDifference;
        }

        private static decimal NewMapnumberSouth(string newMapnumber_100W_Row, decimal subRow = decimal.Zero, decimal subLatitudeDifference = decimal.Zero) {
            if (string.IsNullOrEmpty(newMapnumber_100W_Row)) { throw new ArgumentNullException(); }
            int n100WRInt = Mapnumber100W.RowStringToDigital(newMapnumber_100W_Row);
            if (n100WRInt <= 0) { throw new Exception(); }
            decimal n100WR_d = n100WRInt;

            if (subLatitudeDifference != decimal.Zero) {
                return (n100WR_d - 1) * LongitudeLatitudeDifferent.MAPNUMBER_100W_LATITUDE_DIFFERENT + (LongitudeLatitudeDifferent.MAPNUMBER_100W_LATITUDE_DIFFERENT / subLatitudeDifference - subRow) * subLatitudeDifference;
            } else {
                return (n100WR_d - 1) * LongitudeLatitudeDifferent.MAPNUMBER_100W_LATITUDE_DIFFERENT; ;
            }
        }

        public static void OldMapnumberCornerCoordinates(string oldMapnumber, out bool success, out decimal west, out decimal north, out decimal east, out decimal south) {
            success = false;
            west = decimal.Zero;
            north = decimal.Zero;
            east = decimal.Zero;
            south = decimal.Zero;
            if (!OldMapnumberCheck.Check(oldMapnumber)) { success = false; return; }
            var newMapnumber = OldMapnumberToMapnumber.ToNewMapnumber(oldMapnumber);
            if (!string.IsNullOrEmpty(newMapnumber)) {
                NewMapnumberCornerCoordinates(newMapnumber, out success, out west, out north, out east, out south);
            } else {
                OldMapnumber20WCornerCoordinates(oldMapnumber, out success, out west, out north, out east, out south);
            }
        }

        public static void OldMapnumber20WCornerCoordinates(string oldMapnumber20W, out bool success, out decimal west, out decimal north, out decimal east, out decimal south) {
            success = false;
            west = decimal.Zero;
            north = decimal.Zero;
            east = decimal.Zero;
            south = decimal.Zero;
            if (!OldMapnumberCheck.Check20W(oldMapnumber20W)) { success = false; return; }

            string[] split = oldMapnumber20W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string o100WR = split[0];
            string o100WC = split[1];
            string o20W = split[2];
            string[] subSplit = o20W.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string o20WNum = subSplit[0];
            decimal o100WW = NewMapnumberWest(o100WC);
            decimal o100WS = NewMapnumberSouth(o100WR);
            if (!int.TryParse(o20WNum, out int i20WNum)) { throw new Exception(); }
            int o20WR = Old20WR(i20WNum);
            int o20WC = Old20WC(i20WNum);

            west = o100WW + (o20WC - 1) * LongitudeLatitudeDifferent.MAPNUMBER_20W_LONGITUDE_DIFFERENT;
            south = o100WS + (OldMapnumberDefine.MaxCount20W - o20WR) * LongitudeLatitudeDifferent.MAPNUMBER_20W_LATITUDE_DIFFERENT;
            north = south + LongitudeLatitudeDifferent.MAPNUMBER_20W_LATITUDE_DIFFERENT;
            east = west + LongitudeLatitudeDifferent.MAPNUMBER_20W_LONGITUDE_DIFFERENT;
            success = true;
        }

        private static int Old20WR(int o20WNum) {
            return ((o20WNum - 1) / OldMapnumberDefine.MaxCount20W) + 1;
        }
        private static int Old20WC(int o20WNum) {
            return ((o20WNum - 1) % OldMapnumberDefine.MaxCount20W) + 1;
        }

    }
}
