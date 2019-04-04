using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JT.IO.Extension {
    public static partial class JTDirectoryExt {
        public static void JTClear(this DirectoryInfo directoryInfo) {
            var fileInfos = directoryInfo.GetFiles();
            if (fileInfos != null) {
                foreach (var fileInfo in fileInfos) {
                    fileInfo.Delete();
                }
            }
            var dirInfos = directoryInfo.GetDirectories();
            if (dirInfos != null) {
                foreach (var dirInfo in dirInfos) {
                    dirInfo.JTClear();
                }
            }
        }

    }


}
