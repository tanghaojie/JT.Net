using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
namespace JT.ArcObject {
    public static partial class JTField {

        public static IField ObjectID(string name = "ObjectID") {
            IField f = new FieldClass();
            IFieldEdit fieldEdit = f as IFieldEdit;
            fieldEdit.Name_2 = name;
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            return f;
        }

        public static IField Shape(esriGeometryType geoType, ISpatialReference sr = null, string name = "SHAPE") {
            IField f = new FieldClass();
            IFieldEdit fieldEdit = f as IFieldEdit;
            fieldEdit.Name_2 = name;
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            IGeometryDefEdit geoDef = new GeometryDefClass();
            IGeometryDefEdit geoDefEdit = geoDef as IGeometryDefEdit;
            geoDefEdit.GeometryType_2 = geoType;
            geoDefEdit.SpatialReference_2 = sr;
            fieldEdit.GeometryDef_2 = geoDef;
            return f;
        }

        public static IField Field(string name, esriFieldType type, string alias = null, object defaultValue = null, bool? editable = null, bool? isNullable = null, int? length = null, int? precision = null, bool? required = null, int? scale = null) {
            IField f = new FieldClass();
            IFieldEdit fieldEdit = f as IFieldEdit;
            fieldEdit.Name_2 = name;
            fieldEdit.Type_2 = type;
            if (!string.IsNullOrEmpty(alias)) { fieldEdit.AliasName_2 = alias; }
            if (defaultValue != null) { fieldEdit.DefaultValue_2 = defaultValue; }
            if (editable.HasValue) { fieldEdit.Editable_2 = editable.Value; }
            if (isNullable.HasValue) { fieldEdit.IsNullable_2 = isNullable.Value; }
            if (length.HasValue) { fieldEdit.Length_2 = length.Value; }
            if (precision.HasValue) { fieldEdit.Precision_2 = precision.Value; }
            if (required.HasValue) { fieldEdit.Required_2 = required.Value; }
            if (scale.HasValue) { fieldEdit.Scale_2 = scale.Value; }
            return f;
        }

    }

    public static partial class JTField {
    }

    public static partial class JTField {
    }

    public static partial class JTField {
    }

    public static partial class JTField {
    }

    public static partial class JTField {
    }

    public static partial class JTField {
    }
}
