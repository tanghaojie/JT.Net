namespace JT.Mapnumber {
    public struct OldMapnumberDefine {
        public const int MaxCount50W = 2;
        public const int MaxCount25W = 4;
        public const int MaxCount20W = 6;
        public const int MaxCount10W = 12;
        public const int MaxCount5W = 2;
        public const int MaxCount2_5W = 2;
        public const int MaxCount1W = 8;
        public static char[] ABCD { get; } = { 'A', 'B', 'C', 'D' };
        public static char[] abcd { get; } = { 'a', 'b', 'c', 'd' };
        public static char[] num1234 { get; } = { '1', '2', '3', '4' };
    }
}
