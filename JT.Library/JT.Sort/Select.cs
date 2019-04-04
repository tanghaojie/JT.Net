using System;
using System.Collections.Generic;
using System.Text;

namespace JT.Sort {
    public static class Select {
        public static void Sort<T>(T[] data, bool smallToLarge = true) where T : IComparable {
            if (data == null) { throw new ArgumentNullException(); }
            var len = data.Length;
            if (len < 2) { return; }

            Common.CompareDelegate<T> compare;
            if (smallToLarge) { compare = Common.ALessThanB; } else { compare = Common.AGreaterThanB; }

            int limit;
            for (int i = 0; i < len - 1; ++i) {
                limit = i;
                for (int j = i + 1; j < len; j++) {
                    if (compare(data[j], data[limit])) { limit = j; }
                }
                T tmp = data[limit];
                data[limit] = data[i];
                data[i] = tmp;
            }
        }
    }
}
