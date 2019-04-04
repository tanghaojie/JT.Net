using System.IO;

namespace JT.IO {
    public static partial class JTPath {

        public static bool ValidFilename(string filename) {
            return !string.IsNullOrEmpty(filename) && filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
        }

        public static bool ValidFileFullname(string fileFullname) {
            return !string.IsNullOrEmpty(fileFullname) && fileFullname.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 && fileFullname.IndexOfAny(Path.GetInvalidPathChars()) < 0 && !File.Exists(fileFullname);
        }

    }
}
