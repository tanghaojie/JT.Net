using ESRI.ArcGIS.Geodatabase;

namespace JT.ArcObject {
    public static partial class JTWorkspace {
        public static IWorkspace Open(string pathname) {
            try {
                if (pathname.EndsWith(JTGDB.FILE_EXTENSION, System.StringComparison.CurrentCultureIgnoreCase) && JTGDB.WorkspaceFactory.IsWorkspace(pathname)) {
                    return JTGDB.OpenGDB(pathname);
                } else if (pathname.EndsWith(JTMDB.FILE_EXTENSION, System.StringComparison.CurrentCultureIgnoreCase) && JTMDB.WorkspaceFactory.IsWorkspace(pathname)) {
                    return JTMDB.OpenMDB(pathname);
                } else if (System.IO.Directory.Exists(pathname)) {
                    return JTShape.OpenShapeDirectoryWorkspace(pathname);
                }
                return null;
            } catch {
                return null;
            }
        }
    }

    public static partial class JTWorkspace {
    }

    public static partial class JTWorkspace {
    }

    public static partial class JTWorkspace {
    }

    public static partial class JTWorkspace {
    }

    public static partial class JTWorkspace {
    }

    public static partial class JTWorkspace {
    }
}
