using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System.Collections.Generic;
using System;
namespace JT.ArcObject.Extension {

    public static partial class JTWorkspaceExt {

        public static bool JTExistFeatureClass(this IWorkspace ws, string featureClassName, bool ignoreCase = true) {
            if (ws == null || string.IsNullOrEmpty(featureClassName)) { throw new ArgumentNullException(); }

            var enumDS = ws.get_Datasets(esriDatasetType.esriDTFeatureClass);
            IDataset ds = null;
            while ((ds = enumDS.Next()) != null) { if (ds.Name == featureClassName || (ignoreCase && ds.Name.ToUpper() == featureClassName.ToUpper())) { return true; } }
            enumDS = ws.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            ds = null;
            while ((ds = enumDS.Next()) != null) {
                var fds = ds as IFeatureDataset;
                var subEnumDS = fds.Subsets;
                IDataset subDS = null;
                while ((subDS = subEnumDS.Next()) != null) { if ((subDS.Name == featureClassName) || (ignoreCase && subDS.Name.ToUpper() == featureClassName.ToUpper())) { return true; } }
            }
            return false;
        }

    }

    public static partial class JTWorkspaceExt {

        public static bool JTExistFeatureDataset(this IWorkspace ws, string featureDatasetName, bool ignoreCase = true) {
            if (ws == null || string.IsNullOrEmpty(featureDatasetName)) { throw new ArgumentNullException(); }

            var enumDS = ws.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            IDataset ds = null;
            while ((ds = enumDS.Next()) != null) { if ((ds.Name == featureDatasetName) || (ignoreCase && ds.Name.ToUpper() == featureDatasetName.ToUpper())) { return true; } }
            return false;
        }

    }

    public static partial class JTWorkspaceExt {

        public static bool JTExistTable(this IWorkspace ws, string tableName, bool ignoreCase = true) {
            if (ws == null || string.IsNullOrEmpty(tableName)) { throw new ArgumentNullException(); }

            var enumDS = ws.get_Datasets(esriDatasetType.esriDTTable);
            IDataset ds = null;
            while ((ds = enumDS.Next()) != null) { if (ds.Name == tableName || (ignoreCase && ds.Name.ToUpper() == tableName.ToUpper())) { return true; } }
            return false;
        }

    }

    public static partial class JTWorkspaceExt {

        public static IFeatureDataset JTCreateFeatureDataset(this IWorkspace ws, string featureDatasetName, ISpatialReference spatialReference) {
            if (ws == null || string.IsNullOrEmpty(featureDatasetName)) { throw new ArgumentNullException(); }

            if (!(ws is IFeatureWorkspace fws)) { throw new NotFeatureWorkspaceException(); }
            return fws.CreateFeatureDataset(featureDatasetName, spatialReference);
        }

    }

    public static partial class JTWorkspaceExt {

        public static IFeatureClass JTCreateFeatureClass(this IWorkspace ws, string name, IFields fields, esriFeatureType featureType = esriFeatureType.esriFTSimple, string shapeField = "SHAPE", string configKeyword = null) {
            if (!(ws is IFeatureWorkspace fws)) { throw new NotFeatureWorkspaceException(); }
            var fcd = JTFeatureClass.ObjectClassDescription;
            return fws.CreateFeatureClass(name, fields, fcd.InstanceCLSID, fcd.ClassExtensionCLSID, featureType, shapeField, configKeyword);
        }

    }

    public static partial class JTWorkspaceExt {

        public static IFeatureClass JTOpenFeatureClass(this IWorkspace ws, string featureClassName) {
            if (!(ws is IFeatureWorkspace fws)) { throw new NotFeatureWorkspaceException(); }
            return fws.OpenFeatureClass(featureClassName);
        }
    }

    public static partial class JTWorkspaceExt {

        public static ITable JTCreateTable(this IWorkspace ws, string name, IFields fields, string configKeyword = null) {
            if (!(ws is IFeatureWorkspace fws)) { throw new NotFeatureWorkspaceException(); }
            var td = JTTable.ObjectClassDescription;
            return fws.CreateTable(name, fields, td.InstanceCLSID, td.ClassExtensionCLSID, configKeyword);
        }

    }

    public static partial class JTWorkspaceExt {
        public static IFeatureDataset JTOpenFeatureDataset(this IWorkspace ws, string featureDatasetName) {
            if (!(ws is IFeatureWorkspace fws)) { throw new NotFeatureWorkspaceException(); }
            return fws.OpenFeatureDataset(featureDatasetName);
        }
    }

    public static partial class JTWorkspaceExt {
        public static ITopology JTOpenTopology(this IWorkspace ws, string featureDatasetName, string topologyName) {
            var fds = ws.JTOpenFeatureDataset(featureDatasetName);
            var topoContainer = fds as ITopologyContainer;
            return topoContainer.get_TopologyByName(topologyName);
        }
    }

    public static partial class JTWorkspaceExt {

        public static ITable JTOpenTable(this IWorkspace ws, string tableName) {
            if (!(ws is IFeatureWorkspace fws)) { throw new NotFeatureWorkspaceException(); }
            return fws.OpenTable(tableName);
        }

    }

    public static partial class JTWorkspaceExt {

        public static ITopologyContainer JTOpenTopologyContainer(this IWorkspace ws, string featureDatasetName) {
            var fds = ws.JTOpenFeatureDataset(featureDatasetName);
            return fds as ITopologyContainer;
        }

    }

    public static partial class JTWorkspaceExt {

        public static bool JTNameExist(this IWorkspace ws, esriDatasetType type, string name) {
            var ws2 = ws as IWorkspace2;
            return ws2.NameExists[type, name];
        }

    }

    public static partial class JTWorkspaceExt {

        public static string JTSuggestFeatureClassName(this IWorkspace ws, string name) {
            var fcName = name;
            var index = 0;
            while (ws.JTExistFeatureClass(fcName)) {
                index++;
                fcName = name + index.ToString();
            }
            return fcName;
        }

        public static string JTSuggestFeatureDatasetName(this IWorkspace ws, string name) {
            var fdsName = name;
            var index = 0;
            while (ws.JTExistFeatureDataset(fdsName)) {
                index++;
                fdsName = name + index.ToString();
            }
            return fdsName;
        }

    }

    public static partial class JTWorkspaceExt {

        public static IEnumerable<IDataset> JTDatasets(this IWorkspace ws, esriDatasetType dsType) {
            var enumDS = ws.Datasets[dsType];
            IDataset ds = null;
            while ((ds = enumDS.Next()) != null) { yield return ds; }

            var enumFDS = ws.Datasets[esriDatasetType.esriDTFeatureDataset];
            IDataset FDS = null;
            while ((FDS = enumFDS.Next()) != null) {
                var fds = FDS as IFeatureDataset;
                var fdsEnumDS = fds.Subsets;
                IDataset subDS = null;
                while ((subDS = fdsEnumDS.Next()) != null) {
                    if (subDS.Type == dsType) { yield return subDS; }
                }
            }
        }

    }

    public static partial class JTWorkspaceExt {

        public static void JTUnlock(this IWorkspace ws) {
            ws?.WorkspaceFactory?.JTUnlock();
        }

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

    public static partial class JTWorkspaceExt {

    }

}
