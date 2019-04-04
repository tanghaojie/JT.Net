using System.Collections.Generic;
namespace JT.Enum {
    public static partial class EnumValues {
        public static List<T> AllValues<T>() where T : System.Enum {
            List<T> list = null;
            System.Array arr = null;
            try { arr = System.Enum.GetValues(typeof(T)); } catch { }
            if (arr == null || arr.Length <= 0) { return list; }
            var len = arr.Length;
            list = new List<T>();
            for (int i = 0; i < len; ++i) {
                var item = arr.GetValue(i);
                if (item != null && item is T tItem) { list.Add(tItem); }
            }
            return list;
        }

        public static T[] AllValues2<T>() where T : System.Enum {
            System.Array arr = null;
            try { arr = System.Enum.GetValues(typeof(T)); } catch { }
            if (arr == null || arr.Length <= 0) { return null; }
            var len = arr.Length;
            var list = new List<T>();
            for (int i = 0; i < len; ++i) {
                var item = arr.GetValue(i);
                if (item != null && item is T tItem) { list.Add(tItem); }
            }
            return list.ToArray();
        }

        public static IEnumerable<T> EnumerateAllValues<T>() where T : System.Enum {
            System.Array arr = null;
            try { arr = System.Enum.GetValues(typeof(T)); } catch { }
            if (arr == null || arr.Length <= 0) { yield break; }
            var len = arr.Length;
            var list = new List<T>();
            for (int i = 0; i < len; ++i) {
                var item = arr.GetValue(i);
                if (item != null && item is T tItem) { yield return tItem; }
            }
        }


    }
}
