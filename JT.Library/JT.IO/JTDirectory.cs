using System.IO;
namespace JT.IO {
    public static class JTDirectory {
        public static string GetTempDirectory { get { return Path.GetTempPath(); } }

        public static void ConfirmExist(string fullname) {
            if (Directory.Exists(fullname)) { return; }
            Directory.CreateDirectory(fullname);
        }

        public static bool Copy(string SourceFilename, string TargetFilename) {
            if (!Directory.Exists(SourceFilename)) { return false; }
            var dirInfo = new DirectoryInfo(SourceFilename);
            if (!Directory.Exists(TargetFilename)) { Directory.CreateDirectory(TargetFilename); }
            var files = dirInfo.GetFiles();
            if (files != null && files.Length > 0) {
                foreach (var file in files) {
                    var newFilename = TargetFilename + "\\" + file.Name;
                    file.CopyTo(newFilename, true);
                }
            }
            var dirs = dirInfo.GetDirectories();
            if (dirs != null && dirs.Length > 0) {
                foreach (var dir in dirs) {
                    var newDirFilename = TargetFilename + "\\" + dir.Name;
                    Copy(dir.FullName, newDirFilename);
                }
            }
            return true;
        }

        public static void Clear(string fullname) {
            var dirInfo = new DirectoryInfo(fullname);
            var fileInfos = dirInfo.GetFiles();
            if (fileInfos != null) {
                foreach (var fileInfo in fileInfos) {
                    fileInfo.Delete();
                }
            }
            var dirInfos = dirInfo.GetDirectories();
            if (dirInfos != null) {
                foreach (var dir in dirInfos) {
                    Clear(dir.FullName);
                }
            }
        }

        

    }
}
