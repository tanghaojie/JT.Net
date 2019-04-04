using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;

namespace JT.ArcObject {
    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

        public static IFeatureClass Open(string fullpath) {
            if (string.IsNullOrEmpty(fullpath)) { throw new ArgumentNullException(); }
            try {
                var dirPath = System.IO.Path.GetDirectoryName(fullpath);
                var name = System.IO.Path.GetFileName(fullpath);
                var ws = JTWorkspace.Open(dirPath);
                if (ws == null) {
                    var parPath = System.IO.Path.GetDirectoryName(dirPath);
                    ws = JTWorkspace.Open(parPath);
                }
                if (ws != null) {
                    if (ws is IFeatureWorkspace fws) {
                        return fws.OpenFeatureClass(name);
                    }
                }
                return null;
            } catch {
                return null;
            }
        }

    }

    public static partial class JTFeatureClass {
        public static IFields NecessaryFields(esriGeometryType geoType, ISpatialReference sr, string oidFieldname = "ObjectID") {
            IFields fields = new FieldsClass();
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;
            fieldsEdit.AddField(JTField.ObjectID(oidFieldname));
            fieldsEdit.AddField(JTField.Shape(geoType, sr));
            return fields;
        }
    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {
        public static IObjectClassDescription ObjectClassDescription {
            get { return new FeatureClassDescriptionClass(); }
        }
    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }

    public static partial class JTFeatureClass {

    }
}
