using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JT.ArcObject {
    public static partial class JTRaster {
        public static IRasterDataset OpenRaster(string fullname) {
            var parent = Path.GetDirectoryName(fullname);
            var name = Path.GetFileName(fullname);
            var rws = OpenRasterWorkspace(parent);
            return rws.OpenRasterDataset(name);
        }
    }

    public static partial class JTRaster {
        public static IRasterWorkspace OpenRasterWorkspace(string fullname) {
            return WorkspaceFactory.OpenFromFile(fullname, 0) as IRasterWorkspace;
        }
    }

    public static partial class JTRaster {
     
    }

    public static partial class JTRaster {

    }

    public static partial class JTRaster {

    }

    public static partial class JTRaster {

    }

    public static partial class JTRaster {

    }

    public static partial class JTRaster {
        private static object locker = new object();
        private static volatile IWorkspaceFactory workspaceFactory;
        public static IWorkspaceFactory WorkspaceFactory {
            get {
                if (null == workspaceFactory) { lock (locker) { if (null == workspaceFactory) { workspaceFactory = new RasterWorkspaceFactoryClass(); } } }
                return workspaceFactory;
            }
        }
    }

    public static partial class JTRaster {

    }

    public static partial class JTRaster {

    }
}
