using ESRI.ArcGIS.Geodatabase;
namespace JT.ArcObject.Extension {
    public static partial class JTFeatureDatasetExt {

    }

    public static partial class JTFeatureDatasetExt {

        public static bool JTExistFeatureClass(this IFeatureDataset fds, string featureClassName) {
            var enumDS = fds.Subsets;
            IDataset ds = null;
            while ((ds = enumDS.Next()) != null) {
                if (ds.Type != esriDatasetType.esriDTFeatureClass) { continue; }
                if (ds.Name == featureClassName) { return true; }
            }
            return false;
        }

    }

    public static partial class JTFeatureDatasetExt {

        public static IFeatureClass JTOpenFeatureClass(this IFeatureDataset fds, string featureClassName) {
            var ws = fds.Workspace;
            if (!(ws is IFeatureWorkspace fws)) { throw new NotFeatureWorkspaceException(); }
            return fws.OpenFeatureClass(featureClassName);
        }
    }

    public static partial class JTFeatureDatasetExt {

        public static ITopology JTOpenTopology(this IFeatureDataset fds, string topoName) {
            return ((ITopologyContainer)fds).get_TopologyByName(topoName);
        }

    }

    public static partial class JTFeatureDatasetExt {
    }

    public static partial class JTFeatureDatasetExt {
    }

    public static partial class JTFeatureDatasetExt {
    }

    public static partial class JTFeatureDatasetExt {
    }

    public static partial class JTFeatureDatasetExt {
    }

    public static partial class JTFeatureDatasetExt {
    }
}
