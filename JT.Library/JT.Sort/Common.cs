using System;

namespace JT.Sort {
    public static partial class Common {
        internal static bool AGreaterThanB<T>(T a, T b) where T : IComparable { return a.CompareTo(b) > 0; }
        internal static bool ALessThanB<T>(T a, T b) where T : IComparable { return a.CompareTo(b) < 0; }
        internal static bool AGreaterOrEqualB<T>(T a, T b) where T : IComparable { return a.CompareTo(b) >= 0; }
        internal static bool ALessOrEqualB<T>(T a, T b) where T : IComparable { return a.CompareTo(b) <= 0; }
    }
    public static partial class Common {
        internal delegate bool CompareDelegate<T>(T a, T b);
    }
}
