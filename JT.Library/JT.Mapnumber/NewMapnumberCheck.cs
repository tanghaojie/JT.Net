namespace JT.Mapnumber {
    public static class NewMapnumberCheck {

        public static bool Check(string mapnumber) {
            if (string.IsNullOrEmpty(mapnumber)) { return false; }
            int length = mapnumber.Length;

            if (!CheckLength(length)) { return false; }

            if (!Check100W(mapnumber.Substring(0, 3))) { return false; }
            if (length == 3) { return true; }

            var scaleChr = mapnumber[3];
            if (!NewMapnumber.ValidateScaleChar(scaleChr)) { return false; }

            if (length == 10) {
                return NewMapnumber.ValidateRowColumnNumByScale(scaleChr, mapnumber.Substring(4, 3), mapnumber.Substring(7, 3));
            } else {
                return NewMapnumber.ValidateRowColumnNumByScale(scaleChr, mapnumber.Substring(4, 4), mapnumber.Substring(8, 4));
            }
        }

        private static bool CheckLength(int mapnumber) {
            return mapnumber == 3 || mapnumber == 10 || mapnumber == 12;
        }

        private static bool Check100W(string mapnumber100W) {
            if (mapnumber100W.Length != 3) { return false; }
            return Mapnumber100W.ValidateRowNum(mapnumber100W.Substring(0, 1)) && Mapnumber100W.ValidateColumnNum(mapnumber100W.Substring(1, 2));
        }

    }
}
