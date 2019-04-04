namespace JT.Mapnumber {
    public struct NewMapnumberDefine {
        public const int MaxCount50W = 2;
        public const int MaxCount25W = 4;
        public const int MaxCount10W = 12;
        public const int MaxCount5W = 24;
        public const int MaxCount2_5W = 48;
        public const int MaxCount1W = 96;
        public const int MaxCount5K = 192;
        public const int MaxCount2K = 576;
        public const int MaxCount1K = 1152;
        public const int MaxCount500 = 2304;

        public static char[] Scales {
            get {
                if (scales == null) {
                    var allCount = All.Length;
                    scales = new char[allCount];
                    for (int i = 0; i < allCount; i++) {
                        var item = All[i];
                        scales[i] = item.ScaleChar;
                    }
                }
                return scales;
            }
        }
        private static char[] scales = null;

        public int MaxCount { get; }
        public char ScaleChar { get; }
        public decimal Longitude { get; }
        public decimal Latitude { get; }
        public decimal ScaleDenominator { get; }

        public NewMapnumberDefine(int maxCount, char scaleChar, decimal longitude, decimal latitude, decimal scaleDenominaroe) {
            MaxCount = maxCount;
            ScaleChar = scaleChar;
            Longitude = longitude;
            Latitude = latitude;
            ScaleDenominator = scaleDenominaroe;
        }

        public static NewMapnumberDefine NewMapnumber50W { get; } = new NewMapnumberDefine(MaxCount50W, 'B', 3M, 2M, 500000);
        public static NewMapnumberDefine NewMapnumber25W { get; } = new NewMapnumberDefine(MaxCount25W, 'C', 3 / 2M, 1M, 250000);
        public static NewMapnumberDefine NewMapnumber10W { get; } = new NewMapnumberDefine(MaxCount10W, 'D', 1 / 2M, 1 / 3M, 100000);
        public static NewMapnumberDefine NewMapnumber5W { get; } = new NewMapnumberDefine(MaxCount5W, 'E', 1 / 4M, 1 / 6M, 50000);
        public static NewMapnumberDefine NewMapnumber2_5W { get; } = new NewMapnumberDefine(MaxCount2_5W, 'F', 1 / 8M, 1 / 12M, 25000);
        public static NewMapnumberDefine NewMapnumber1W { get; } = new NewMapnumberDefine(MaxCount1W, 'G', 1 / 16M, 1 / 24M, 10000);
        public static NewMapnumberDefine NewMapnumber5K { get; } = new NewMapnumberDefine(MaxCount5K, 'H', 1 / 32M, 1 / 48M, 5000);
        public static NewMapnumberDefine NewMapnumber2K { get; } = new NewMapnumberDefine(MaxCount2K, 'I', 1 / 96M, 1 / 144M, 2000);
        public static NewMapnumberDefine NewMapnumber1K { get; } = new NewMapnumberDefine(MaxCount1K, 'J', 1 / 192M, 1 / 288M, 1000);
        public static NewMapnumberDefine NewMapnumber500 { get; } = new NewMapnumberDefine(MaxCount500, 'K', 1 / 384M, 1 / 576M, 500);

        public static NewMapnumberDefine[] All { get; } = new NewMapnumberDefine[] { NewMapnumber50W, NewMapnumber25W, NewMapnumber10W, NewMapnumber5W, NewMapnumber2_5W, NewMapnumber1W, NewMapnumber5K, NewMapnumber2K, NewMapnumber1K, NewMapnumber500, };

    }
}
