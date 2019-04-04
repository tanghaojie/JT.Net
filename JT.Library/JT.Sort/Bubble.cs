using System;
namespace JT.Sort {
    public static partial class Bubble {

        public static void Sort<T>(T[] data, bool smallToLarge = true) where T : IComparable {
            if (data == null) { throw new ArgumentNullException(); }
            var len = data.Length;
            if (len < 2) { return; }

            Common.CompareDelegate<T> compare;
            if (smallToLarge) { compare = Common.AGreaterThanB; } else { compare = Common.ALessThanB; }
            T tmp;
            var swapped = false;
            for (int i = 0; i < len - 1; ++i) {
                swapped = false;
                for (int j = i + 1; j < len; ++j) {
                    if (compare(data[i], data[j])) {
                        tmp = data[i];
                        data[i] = data[j];
                        data[j] = tmp;
                        swapped = true;
                    }
                }
                if (!swapped) { break; }
            }
        }

    }
}
