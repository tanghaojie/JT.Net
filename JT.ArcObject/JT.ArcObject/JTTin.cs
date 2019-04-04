using System;
using System.IO;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
namespace JT.ArcObject {
    public static partial class JTTin {
        public static ITin OpenTin(string tinFullname) {
            if (!Directory.Exists(tinFullname)) { throw new Exception("Tin不存在"); }
            var tinName = Path.GetFileName(tinFullname);
            return (WorkspaceFactory.OpenFromFile(Path.GetDirectoryName(tinFullname), 0) as ITinWorkspace).OpenTin(tinName);
        }
    }

    public static partial class JTTin {
    }

    public static partial class JTTin {
    }

    public static partial class JTTin {
    }

    public static partial class JTTin {

    }

    public static partial class JTTin {

        private static object locker = new object();
        private static volatile IWorkspaceFactory workspaceFactory;
        public static IWorkspaceFactory WorkspaceFactory {
            get {
                if (null == workspaceFactory) { lock (locker) { if (null == workspaceFactory) { workspaceFactory = new TinWorkspaceFactoryClass(); } } }
                return workspaceFactory;
            }
        }

    }
}
