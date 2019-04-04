namespace JT.Mapnumber {
    public static class LongitudeLatitudeDifferent {

        public const decimal MAPNUMBER_100W_LONGITUDE_DIFFERENT = 6M;

        public const decimal MAPNUMBER_100W_LATITUDE_DIFFERENT = 4M;

        public const decimal MAPNUMBER_50W_LONGITUDE_DIFFERENT = 3M;

        public const decimal MAPNUMBER_50W_LATITUDE_DIFFERENT = 2M;

        public const decimal MAPNUMBER_25W_LONGITUDE_DIFFERENT = 3 / 2M;

        public const decimal MAPNUMBER_25W_LATITUDE_DIFFERENT = 1M;

        public const decimal MAPNUMBER_20W_LONGITUDE_DIFFERENT = 1M;

        public const decimal MAPNUMBER_20W_LATITUDE_DIFFERENT = 2 / 3M;

        public const decimal MAPNUMBER_10W_LONGITUDE_DIFFERENT = 1 / 2M;

        public const decimal MAPNUMBER_10W_LATITUDE_DIFFERENT = 1 / 3M;

        public const decimal MAPNUMBER_5W_LONGITUDE_DIFFERENT = 1 / 4M;

        public const decimal MAPNUMBER_5W_LATITUDE_DIFFERENT = 1 / 6M;

        public const decimal MAPNUMBER_2_5W_LONGITUDE_DIFFERENT = 1 / 8M;

        public const decimal MAPNUMBER_2_5W_LATITUDE_DIFFERENT = 1 / 12M;

        public const decimal MAPNUMBER_1W_LONGITUDE_DIFFERENT = 1 / 16M;

        public const decimal MAPNUMBER_1W_LATITUDE_DIFFERENT = 1 / 24M;

        public const decimal MAPNUMBER_5K_LONGITUDE_DIFFERENT = 1 / 32M;

        public const decimal MAPNUMBER_5K_LATITUDE_DIFFERENT = 1 / 48M;

        public const decimal MAPNUMBER_2K_LONGITUDE_DIFFERENT = 1 / 96M;

        public const decimal MAPNUMBER_2K_LATITUDE_DIFFERENT = 1 / 144M;

        public const decimal MAPNUMBER_1K_LONGITUDE_DIFFERENT = 1 / 192M;

        public const decimal MAPNUMBER_1K_LATITUDE_DIFFERENT = 1 / 288M;

        public const decimal MAPNUMBER_500_LONGITUDE_DIFFERENT = 1 / 384M;

        public const decimal MAPNUMBER_500_LATITUDE_DIFFERENT = 1 / 576M;

        public static void LongitudeLatitudeDifferenceByScaleDenominator(int scaleDenominator, out bool success, out decimal longitudeDifferent, out decimal latitudeDifferent) {
            switch (scaleDenominator) {
                case 1000000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_100W_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_100W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 500000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_50W_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_50W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 250000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_25W_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_25W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 200000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_20W_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_20W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 100000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_10W_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_10W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 50000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_5W_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_5W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 25000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_2_5W_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_2_5W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 10000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_1W_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_1W_LATITUDE_DIFFERENT;
                        break;
                    }
                case 5000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_5K_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_5K_LATITUDE_DIFFERENT;
                        break;
                    }
                case 2000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_2K_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_2K_LATITUDE_DIFFERENT;
                        break;
                    }
                case 1000: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_1K_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_1K_LATITUDE_DIFFERENT;
                        break;
                    }
                case 500: {
                        success = true;
                        longitudeDifferent = MAPNUMBER_500_LONGITUDE_DIFFERENT;
                        latitudeDifferent = MAPNUMBER_500_LATITUDE_DIFFERENT;
                        break;
                    }
                default: {
                        success = false;
                        longitudeDifferent = decimal.Zero;
                        latitudeDifferent = decimal.Zero;
                        break;
                    }
            }
        }
    }
}
