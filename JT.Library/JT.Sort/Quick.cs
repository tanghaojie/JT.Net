using System;
namespace JT.Sort {
    public static class Quick {
        public static void Sort<T>(T[] data, bool smallToLarge = true) where T : IComparable {
            if (data == null) { throw new ArgumentNullException(); }
            var len = data.Length;
            if (len < 2) { return; }
            Sort(data, 0, len - 1, smallToLarge);
        }

        public static void Sort<T>(T[] data, int left, int right, bool smallToLarge = true) where T : IComparable {
            if (data == null) { throw new ArgumentNullException(); }
            if (left >= right) { return; }
            Common.CompareDelegate<T> compare;
            if (smallToLarge) { compare = Common.AGreaterOrEqualB; } else { compare = Common.ALessOrEqualB; }
            var i = left; var j = right; var key = data[left];
            while (i < j) {
                while (i < j && compare(data[j], key)) { j--; }
                data[i] = data[j];
                while (i < j && compare(key, data[i])) { i++; }
                data[j] = data[i];
            }
            data[i] = key;
            Sort(data, left, i - 1, smallToLarge);
            Sort(data, j + 1, right, smallToLarge);
        }
    }
}
