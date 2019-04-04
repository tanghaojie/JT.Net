
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace JT.ArcObject.Extension {
    public static partial class JTTopologyExt {
        public static List<string> JTFeatureClassNamesInTopology(this ITopology topology) {
            List<string> list = new List<string>();
            var container = topology as IFeatureClassContainer;
            var count = container.ClassCount;
            if (count <= 0) { return list; }
            for (int i = 0; i < count; i++) {
                list.Add((container.get_Class(i) as IDataset).Name);
            }
            return list;
        }
        public static bool JTContainsFeatureClassByName(this ITopology topology, string name, StringComparison sc = StringComparison.OrdinalIgnoreCase) {
            var container = topology as IFeatureClassContainer;
            var count = container.ClassCount;
            if (count <= 0) { return false; }
            for (int i = 0; i < count; i++) {
                var n = (container.get_Class(i) as IDataset).Name;
                if (string.Equals(n, name, sc)) { return true; }
            }
            return false;
        }
    }

    public static partial class JTTopologyExt {
        public static ITopologyRuleContainer JTTopologyRuleContainer(this ITopology topology) {
            return topology as ITopologyRuleContainer;
        }
    }

    public static partial class JTTopologyExt {
        public static int JTFeatureClassIDByNameInTopology(this ITopology topology, string name) {
            var container = topology as IFeatureClassContainer;
            var fc = container.get_ClassByName(name);
            if (fc != null) {
                return fc.FeatureClassID;
            }
            return -1;
        }
    }

    public static partial class JTTopologyExt {
        public static bool JTAddRule(this ITopology topology, ITopologyRule rule) {
            var container = topology as ITopologyRuleContainer;
            if (container.get_CanAddRule(rule)) {
                container.AddRule(rule);
                return true;
            }
            return false;
        }
    }

    public static partial class JTTopologyExt {

        public static Dictionary<string, int> JTGetFeatureClassNameWithIDs(this ITopology topology) {
            var nameWithIDs = new Dictionary<string, int>();
            var container = topology as IFeatureClassContainer;
            var enumFeatureClasses = container.Classes;
            IFeatureClass fc = null;
            while ((fc = enumFeatureClasses.Next()) != null) {
                var name = (fc as IDataset).Name;
                var id = fc.FeatureClassID;
                nameWithIDs.Add(name, id);
            }
            return nameWithIDs;
        }

    }

    public static partial class JTTopologyExt {

        public static Dictionary<int, string> JTGetFeatureClassIDWithNames(this ITopology topology) {
            var idWithNames = new Dictionary<int, string>();
            var container = topology as IFeatureClassContainer;
            var enumFeatureClasses = container.Classes;
            IFeatureClass fc = null;
            while ((fc = enumFeatureClasses.Next()) != null) {
                var name = (fc as IDataset).Name;
                var id = fc.FeatureClassID;
                idWithNames.Add(id, name);
            }
            return idWithNames;
        }


    }

    public static partial class JTTopologyExt {
    }

    public static partial class JTTopologyExt {
    }

    public static partial class JTTopologyExt {
    }

    public static partial class JTTopologyExt {
    }

    public static partial class JTTopologyExt {
    }

    public static partial class JTTopologyExt {
    }

    public static partial class JTTopologyExt {
    }
}
