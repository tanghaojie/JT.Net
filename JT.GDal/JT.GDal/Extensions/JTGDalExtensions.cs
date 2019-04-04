using OSGeo.OGR;
using System.Collections.Generic;
namespace JT.GDal {
    public static class JTGDalExtensions {
        public static FieldDefn[] Fields(this OSGeo.OGR.Layer layer) {
            var defn = layer.GetLayerDefn();
            var count = defn.GetFieldCount();
            List<FieldDefn> fields = new List<FieldDefn>();
            for (int i = 0; i < count; i++) {
                var field = defn.GetFieldDefn(i);
                fields.Add(field);
            }
            return fields.ToArray();
        }
        /// <summary>
        /// only for gdal 1.11+
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static GeomFieldDefn[] GeomFields(this OSGeo.OGR.Layer layer) {
            var defn = layer.GetLayerDefn();
            var count = defn.GetGeomFieldCount();
            List<GeomFieldDefn> fields = new List<GeomFieldDefn>();
            for (int i = 0; i < count; i++) {
                var field = defn.GetGeomFieldDefn(i);
                fields.Add(field);
            }
            return fields.ToArray();
        }
    }
}
