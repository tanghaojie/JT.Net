using System.IO;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
namespace JT.ArcObject {
    public static partial class JTShape {
        public const string FILE_EXTENSION = ".shp";
    }
    public static partial class JTShape {

        public static IFeatureClass Open(string fullname) {
            return Open(Path.GetDirectoryName(fullname), Path.GetFileNameWithoutExtension(fullname));
        }

        public static IFeatureClass Open(string directory, string filename) {
            return (WorkspaceFactory.OpenFromFile(directory, 0) as IFeatureWorkspace).OpenFeatureClass(filename);
        }
    }

    public static partial class JTShape {

        public static IWorkspace OpenShapeDirectoryWorkspace(string directory) {
            return WorkspaceFactory.OpenFromFile(directory, 0);
        }

        public static IWorkspace OpenShapeFileWorkspace(string fullname) {
            var dir = Path.GetDirectoryName(fullname);
            return OpenShapeDirectoryWorkspace(dir);
        }
    }

    public static partial class JTShape {

        public static IWorkspace CreateShapeWorkspace(string fullDirectoryName) {
            if (!Directory.Exists(fullDirectoryName)) { Directory.CreateDirectory(fullDirectoryName); }
            return WorkspaceFactory.OpenFromFile(fullDirectoryName, 0);
        }

        public static IWorkspace CreateShapeWorkspace(string directory, string dirName) {
            var path = directory + "\\" + dirName;
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            return WorkspaceFactory.OpenFromFile(path, 0);
        }
    }

    public static partial class JTShape {
    }

    public static partial class JTShape {
    }

    public static partial class JTShape {
    }

    public static partial class JTShape {

        private static object locker = new object();
        private static volatile IWorkspaceFactory workspaceFactory;
        public static IWorkspaceFactory WorkspaceFactory {
            get {
                if (null == workspaceFactory) { lock (locker) { if (null == workspaceFactory) { workspaceFactory = new ShapefileWorkspaceFactoryClass(); } } }
                return workspaceFactory;
            }
        }

    }
}
