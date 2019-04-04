using System.IO;
using System.Xml;
namespace JT.Xml {
    public class Writer {
        public static void Write(string filePath, string xmlStr) {
            var doc = new XmlDocument();
            doc.LoadXml(xmlStr);
            doc.Save(File.Open(filePath, FileMode.OpenOrCreate));
        }
    }
}
