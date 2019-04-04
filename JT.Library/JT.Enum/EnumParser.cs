using System;
namespace JT.Enum {
    public class CannotParseException : Exception { }
    public static partial class EnumParser {
        public static string EnumToString<T>(T @enum) where T : System.Enum {
            return System.Enum.GetName(@enum.GetType(), @enum);
        }

        public static T StringToEnum<T>(string enumStr, bool ignoreCase = false) where T : System.Enum {
            object obj = null;
            try { obj = System.Enum.Parse(typeof(T), enumStr, ignoreCase); } catch { throw new CannotParseException(); }
            if (obj == null || !(obj is T item)) { throw new CannotParseException(); }
            return item;
        }
    }
    public static partial class EnumParser {
        public static int EnumToInt<T>(T @enum) where T : System.Enum {
            return (int)(object)@enum;
        }

        public static T IntToEnum<T>(int enumInt) where T : System.Enum {
            if (System.Enum.IsDefined(typeof(T), enumInt)) {
                var obj = System.Enum.ToObject(typeof(T), enumInt);
                if (obj == null || !(obj is T item)) { throw new CannotParseException(); }
                return item;
            }
            throw new CannotParseException();
        }
    }
}
