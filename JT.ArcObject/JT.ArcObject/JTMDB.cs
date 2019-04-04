using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
namespace JT.ArcObject {

    public static partial class JTMDB {
        public const string FILE_EXTENSION = ".mdb";
    }

    public static partial class JTMDB {

        public static IWorkspace CreateMDB(string directory, string mdbName) {
            if (!mdbName.ToLower().EndsWith(FILE_EXTENSION)) { mdbName = mdbName + FILE_EXTENSION; }
            if (!System.IO.Directory.Exists(directory)) { System.IO.Directory.CreateDirectory(directory); }
            var wsn = WorkspaceFactory.Create(directory, mdbName, null, 0);
            return WorkspaceFactory.OpenFromFile(wsn.PathName, 0);
        }
    }

    public static partial class JTMDB {
        public static IWorkspace OpenMDB(string fullname) {
            return WorkspaceFactory.OpenFromFile(fullname, 0);
        }
    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {


    }

    public static partial class JTMDB {

        private static object locker = new object();
        private static volatile IWorkspaceFactory workspaceFactory;
        public static IWorkspaceFactory WorkspaceFactory {
            get {
                if (null == workspaceFactory) { lock (locker) { if (null == workspaceFactory) { workspaceFactory = new AccessWorkspaceFactoryClass(); } } }
                return workspaceFactory;
            }
        }

    }

    public static partial class JTMDB {


    }
}
