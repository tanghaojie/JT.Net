using System.IO;
using System.Xml;
namespace JT.Xml {
    public class Validator {
        public static bool XmlValid(string xmlPath) {
            var strXml = "";
            using (var sr = new StreamReader(xmlPath)) { strXml = sr.ReadToEnd(); }
            try {
                new XmlDocument().LoadXml(strXml);
                return true;
            } catch { return false; }
        }
    }
}
