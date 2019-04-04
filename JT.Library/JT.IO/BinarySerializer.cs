using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JT.IO {
    public class BinarySerializer {
        public static MemoryStream Serializer<T>(T obj) {
            var binaryFormatter = new BinaryFormatter();
            var ms = new MemoryStream();
            binaryFormatter.Serialize(ms, obj);
            return ms;
        }

        public static bool Serializer<T>(T obj, string path, bool overwrite = true) {
            if (File.Exists(path) && !overwrite) { return false; }
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
            try {
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                    var binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fs, obj);
                }
            } catch { return false; }
            return true;
        }

        public static T Deserializer<T>(MemoryStream ms) {
            var binaryFormatter = new BinaryFormatter();
            var obj = binaryFormatter.Deserialize(ms);
            if (obj is T) { return (T)obj; }
            return default;
        }

        public static T Deserializer<T>(string path) {
            if (!File.Exists(path)) { return default; }
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                var binaryFormatter = new BinaryFormatter();
                var obj = binaryFormatter.Deserialize(fs);
                if (obj is T) { return (T)obj; }
                return default;
            }
        }
    }
}
