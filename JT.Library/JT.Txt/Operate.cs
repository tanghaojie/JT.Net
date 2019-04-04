using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JT.Txt {
    public static partial class Operate {

        public static IEnumerable<string> Read(string filename) {
            using (var sr = new StreamReader(filename)) {
                string line = null;
                while ((line = sr.ReadLine()) != null) {
                    yield return line;
                }
            }
        }

        public static IEnumerable<string> Read(string filename, Encoding encoding) {
            using (var sr = new StreamReader(filename, encoding)) {
                string line = null;
                while ((line = sr.ReadLine()) != null) {
                    yield return line;
                }
            }
        }

    }
}
