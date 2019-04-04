using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace JT.Xml {
    public class Serializer {
        public static string Serialize<T>(T obj, Encoding encoding) {
            string result = null;
            if (obj == null) { return result; }
            var xml = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream()) {
                using (var writer = new XmlTextWriter(stream, encoding)) {
                    writer.Formatting = Formatting.Indented;
                    xml.Serialize(writer, obj);
                    stream.Position = 0;
                    var sb = new StringBuilder();
                    using (var reader = new StreamReader(stream, encoding)) {
                        string line = null;
                        while ((line = reader.ReadLine()) != null) { sb.Append(line); }
                        reader.Close();
                    }
                    result = sb.ToString();
                    writer.Close();
                }
                stream.Close();
            }
            return result;

        }
        public static T Deserialize<T>(string xmlPath, Encoding encoding) {
            T obj = default(T);
            var xml = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(xmlPath, encoding)) {
                obj = (T)xml.Deserialize(reader);
                reader.Close();
            }
            return obj;
        }
    }
}
