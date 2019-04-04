using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using System;

namespace JT.ArcObject {
    public static partial class JTGDB {
        public const string FILE_EXTENSION = ".gdb";
    }
    public static partial class JTGDB {

        public static IWorkspace CreateGDB(string directory, string gdbName) {
            if (!gdbName.ToLower().EndsWith(FILE_EXTENSION)) { gdbName = gdbName + FILE_EXTENSION; }
            if (!System.IO.Directory.Exists(directory)) { System.IO.Directory.CreateDirectory(directory); }
            var wsn = WorkspaceFactory.Create(directory, gdbName, null, 0);

            return WorkspaceFactory.OpenFromFile(wsn.PathName, 0);
        }

    }

    public static partial class JTGDB {

        public static IWorkspace OpenGDB(string fullname) {
            return WorkspaceFactory.OpenFromFile(fullname, 0);
        }
    }

    public static partial class JTGDB {


    }

    public static partial class JTGDB {

        public static IWorkspace CreateTempGDB() {
            var tmpDir = System.IO.Path.GetTempPath();
            var now = DateTime.Now;
            var nowStr = now.Year.ToString("0000") + now.Month.ToString("00") + now.Day.ToString("00") + now.Hour.ToString("00") + now.Minute.ToString("00") + now.Second.ToString("00");
            var gdbName = "temp" + nowStr;
            var index = 0;
            var newName = gdbName;
            while (System.IO.Directory.Exists(tmpDir + "\\" + newName + FILE_EXTENSION)) {
                index++;
                newName = gdbName + index.ToString();
            }
            newName += FILE_EXTENSION;
            return CreateGDB(tmpDir, newName);
        }
    }

    public static partial class JTGDB {

        private static object locker = new object();
        private static volatile IWorkspaceFactory workspaceFactory;
        public static IWorkspaceFactory WorkspaceFactory {
            get {
                if (null == workspaceFactory) { lock (locker) { if (null == workspaceFactory) { workspaceFactory = new FileGDBWorkspaceFactoryClass(); } } }
                return workspaceFactory;
            }
        }

    }

    public static partial class JTGDB {

    }

    public static partial class JTGDB {

    }

    public static partial class JTGDB {

    }

    public static partial class JTGDB {

    }

    public static partial class JTGDB {

    }

    public static partial class JTGDB {

    }
    public static partial class JTGDB {

    }
}
