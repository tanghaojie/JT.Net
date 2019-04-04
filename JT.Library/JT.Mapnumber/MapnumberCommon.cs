using System;
namespace JT.Mapnumber {
    public static class MapnumberCommon {
        public static bool Contain(string[] strs, string str) {
            if (strs == null || strs.Length <= 0) { return false; }
            var len = strs.Length;
            for (int i = 0; i < len; i++) {
                if (strs[i] == str) { return true; }
            }
            return false;
        }

        public static bool Contain<T>(T[] items, T item) where T : IEquatable<T> {
            if (items == null || items.Length <= 0) { return false; }
            var len = items.Length;
            for (int i = 0; i < len; i++) {
                if (items[i].Equals(item)) { return true; }
            }
            return false;
        }

    }
}
