using ESRI.ArcGIS.Geodatabase;
using System;

namespace JT.ArcObject.Extension {
    public static partial class JTFeatureExt {
        public static bool JTFeatureAttributesSame(this IFeature f1, IFeature f2, string[] compareFields) {
            if (f1 == null || f2 == null) { throw new ArgumentNullException(); }
            return (f1 as IRow).JTRowSame(f2 as IRow, compareFields);
        }
    }

    public static partial class JTFeatureExt {

    }

    public static partial class JTFeatureExt {

    }

    public static partial class JTFeatureExt {

    }

    public static partial class JTFeatureExt {

    }

    public static partial class JTFeatureExt {

    }

    public static partial class JTFeatureExt {

    }
}
