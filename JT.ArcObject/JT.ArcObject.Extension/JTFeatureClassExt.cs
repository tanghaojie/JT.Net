using ESRI.ArcGIS.Geodatabase;
using System;
using ESRI.ArcGIS.Geometry;
using System.Collections.Generic;

namespace JT.ArcObject.Extension {

    public static partial class JTFeatureClassExt {



    }

    public static partial class JTFeatureClassExt {
#if NET_3_5
        public static IList<object> JTUniqueValues(this IFeatureClass fc, string fieldname, string where = null) {
            if (fc == null || !(fc is ITable table)) { throw new ArgumentNullException(); }
            return table.JTUniqueValues(fieldname, where);
        }
#endif

#if NET_4_0
        public static IList<dynamic> JTUniqueValues(this IFeatureClass fc, string fieldname, string where = null) {
            if (fc == null || !(fc is ITable table)) { throw new ArgumentNullException(); }
            return table.JTUniqueValues(fieldname, where);
        }
#endif
    }

    public static partial class JTFeatureClassExt {

        public static bool JTExistField(this IFeatureClass fc, string fieldname) {
            return fc.FindField(fieldname) >= 0;
        }

    }

    public static partial class JTFeatureClassExt {

        public static void JTClearFeatures(this IFeatureClass fc) {
            var cursor = fc.Update(null, true);
            IFeature feature = null;
            while ((feature = cursor.NextFeature()) != null) {
                cursor.DeleteFeature();
            }
        }

        public static void JTDeleteFeatures(this IFeatureClass fc, IQueryFilter queryFilter) {
            var table = fc as ITable;
            table.JTClear(queryFilter);
        }

    }

    public static partial class JTFeatureClassExt {

        public static bool JTContain(this IFeatureClass fc, IFeature f) {
            var shape = f.ShapeCopy;
            if (shape == null || shape.IsEmpty) { return false; }

            var cursor = fc.Search(new SpatialFilterClass { Geometry = shape, SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects }, true);

            IFeature fea = null;
            while ((fea = cursor.NextFeature()) != null) {
                var s = fea.Shape;
                if (s == null || s.IsEmpty) { continue; }
                var ro = s as IRelationalOperator;
                if (ro.Contains(shape)) {
                    ADF.ComReleaser.ReleaseComObject(s);
                    ADF.ComReleaser.ReleaseComObject(fea);
                    ADF.ComReleaser.ReleaseComObject(cursor);
                    ADF.ComReleaser.ReleaseComObject(shape);
                    return true;
                } else {
                    var to = shape as ITopologicalOperator;
                    shape = to.Difference(s);
                    if (shape == null || shape.IsEmpty) {
                        ADF.ComReleaser.ReleaseComObject(s);
                        ADF.ComReleaser.ReleaseComObject(fea);
                        ADF.ComReleaser.ReleaseComObject(cursor);
                        ADF.ComReleaser.ReleaseComObject(shape);
                        return true;
                    }
                }
                s = null;
            }

            ADF.ComReleaser.ReleaseComObject(cursor);
            ADF.ComReleaser.ReleaseComObject(shape);

            GC.Collect();
            return false;
        }

    }

    public static partial class JTFeatureClassExt {
        public static string JTFeatureClassName(this IFeatureClass fc) {
            if (fc == null) { throw new NullReferenceException(); }
            return (fc as IDataset).Name;
        }
    }

    public static partial class JTFeatureClassExt {
        public static void JTUpdateExtent(this IFeatureClass fc) {
            if (fc == null) { return; }
            if (fc is IFeatureClassManage fcm) { fcm.UpdateExtent(); }
        }
    }

    public static partial class JTFeatureClassExt {
        public static int JTLockCount(this IFeatureClass fc) {
            if (fc == null) { throw new NullReferenceException(); }
            if (!(fc is ISchemaLock sl)) { throw new NullReferenceException(); }
            sl.GetCurrentSchemaLocks(out IEnumSchemaLockInfo enumSLI);
            if (enumSLI == null) { return 0; }
            ISchemaLockInfo sli = null;
            var count = 0;
            while ((sli = enumSLI.Next()) != null) { ++count; }
            ADF.ComReleaser.ReleaseComObject(sli);
            ADF.ComReleaser.ReleaseComObject(enumSLI);
            ADF.ComReleaser.ReleaseComObject(sl);
            return count;
        }

        public static bool JTHasExclusiveSchemaLock(this IFeatureClass fc) {
            if (fc == null) { throw new NullReferenceException(); }
            if (!(fc is ISchemaLock sl)) { throw new NullReferenceException(); }
            sl.GetCurrentSchemaLocks(out IEnumSchemaLockInfo enumSLI);
            if (enumSLI == null) { return false; }
            ISchemaLockInfo sli = null;
            var hasExclusiveSchemaLock = false;
            while ((sli = enumSLI.Next()) != null) {
                if (sli.SchemaLockType == esriSchemaLock.esriExclusiveSchemaLock) {
                    hasExclusiveSchemaLock = true;
                    break;
                }
            }
            ADF.ComReleaser.ReleaseComObject(sli);
            ADF.ComReleaser.ReleaseComObject(enumSLI);
            ADF.ComReleaser.ReleaseComObject(sl);
            return hasExclusiveSchemaLock;
        }

        public static bool JTExclusiveSchemaLockEnable(this IFeatureClass fc) {
            if (fc == null) { throw new NullReferenceException(); }
            if (!(fc is ISchemaLock sl)) { throw new NullReferenceException(); }
            sl.GetCurrentSchemaLocks(out IEnumSchemaLockInfo enumSLI);
            if (enumSLI == null) { return true; }
            ISchemaLockInfo sli = null;
            var count = 0;
            var hasExclusiveLock = false;
            while ((sli = enumSLI.Next()) != null) {
                ++count;
                if (sli.SchemaLockType == esriSchemaLock.esriExclusiveSchemaLock) {
                    hasExclusiveLock = true;
                    break;
                }
            }
            ADF.ComReleaser.ReleaseComObject(sli);
            ADF.ComReleaser.ReleaseComObject(enumSLI);
            ADF.ComReleaser.ReleaseComObject(sl);
            return !hasExclusiveLock && count <= 1;
        }

    }

    public static partial class JTFeatureClassExt {

    }

    public static partial class JTFeatureClassExt {

        public static void JTDelete(this IFeatureClass fc) {
            var ds = fc as IDataset;
            ds.JTDelete();
        }

    }


}
