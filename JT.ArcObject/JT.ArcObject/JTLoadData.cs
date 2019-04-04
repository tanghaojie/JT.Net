using ESRI.ArcGIS.EditorExt;
using ESRI.ArcGIS.Geodatabase;
using JT.ADF;
using System;
using System.Collections.Generic;

namespace JT.ArcObject {
    public static partial class JTLoadData {
        public class JTLoadDataError {
            internal JTLoadDataError(int oid, string description) {
                ObjectID = oid;
                ErrorDescription = description;
            }
            public int ObjectID { get; }
            public string ErrorDescription { get; }
        }

        /// <summary>
        /// Test 6s
        /// </summary>
        /// <param name="sourceFeatureClass"></param>
        /// <param name="targetFeatureClass"></param>
        /// <param name="errors"></param>
        /// <param name="queryClause"></param>
        /// <returns></returns>
        public static bool LoadData_Loader(IFeatureClass sourceFeatureClass, IFeatureClass targetFeatureClass, out JTLoadDataError[] errors, string queryClause = null) {
            var sTable = sourceFeatureClass as ITable;
            var tTable = targetFeatureClass as ITable;
            return LoadData_Loader(sTable, tTable, out errors, queryClause);
        }
        /// <summary>
        /// Test 6s
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="targetTable"></param>
        /// <param name="errors"></param>
        /// <param name="queryClause"></param>
        /// <returns></returns>
        public static bool LoadData_Loader(ITable sourceTable, ITable targetTable, out JTLoadDataError[] errors, string queryClause = null) {
            if (sourceTable == null || targetTable == null) { throw new ArgumentNullException(); }
            IFields sFields = sourceTable.Fields;
            IFields tFields = targetTable.Fields;
            string sourceFieldsStr = string.Empty;
            var tFieldCount = tFields.FieldCount;
            if (tFieldCount > 0) {
                sourceFieldsStr = tFields.Field[0].Name;
                for (int i = 1; i < tFieldCount; ++i) { sourceFieldsStr += "," + tFields.Field[i].Name; }
            }
            IObjectLoader objectLoader = new ObjectLoaderClass();
            IQueryFilter qf = new QueryFilterClass { SubFields = sourceFieldsStr, WhereClause = queryClause, };
            objectLoader.LoadObjects(null, sourceTable, qf, targetTable, tFields, false, 0, false, false, 20, out IEnumInvalidObject enumInvalidObject);
            var listErrors = new List<JTLoadDataError>();
            IInvalidObjectInfo invalidObject = null;
            while ((invalidObject = enumInvalidObject.Next()) != null) { listErrors.Add(new JTLoadDataError(invalidObject.InvalidObjectID, invalidObject.ErrorDescription)); }
            ComReleaser.ReleaseComObject(invalidObject);
            ComReleaser.ReleaseComObject(qf);
            ComReleaser.ReleaseComObject(objectLoader);
            ComReleaser.ReleaseComObject(tFields);
            ComReleaser.ReleaseComObject(sFields);
            errors = listErrors.ToArray();
            return errors.Length <= 0;
        }
    }

    public static partial class JTLoadData {
        /// <summary>
        /// Test 13s
        /// </summary>
        /// <param name="sourceFeatureClass"></param>
        /// <param name="targetFeatureClass"></param>
        /// <param name="queryClause"></param>
        public static void LoadData_Insert(IFeatureClass sourceFeatureClass, IFeatureClass targetFeatureClass, string queryClause = null) {
            var featureBuffer = targetFeatureClass.CreateFeatureBuffer();
            var insertCursor = targetFeatureClass.Insert(true);
            IQueryFilter queryFilter = null;
            if (!string.IsNullOrEmpty(queryClause)) { queryFilter = new QueryFilterClass { WhereClause = queryClause }; }
            var cursor = sourceFeatureClass.Search(queryFilter, true);
            var targetFields = featureBuffer.Fields;
            var sourceFields = sourceFeatureClass.Fields;
            var sourceFieldCount = sourceFields.FieldCount;
            IFeature sourceFeature = null;
            while ((sourceFeature = cursor.NextFeature()) != null) {
                var shape = sourceFeature.Shape;
                featureBuffer.Shape = shape;
                for (int i = 0; i < sourceFieldCount; ++i) {
                    var field = sourceFields.get_Field(i);
                    if (field.Editable && field.Type != esriFieldType.esriFieldTypeOID && field.Type != esriFieldType.esriFieldTypeGeometry && field.Type != esriFieldType.esriFieldTypeGlobalID && field.Type != esriFieldType.esriFieldTypeGUID) {
                        var fieldName = field.Name;
                        int index = targetFields.FindField(fieldName);
                        if (index > -1) {
                            var value = sourceFeature.get_Value(i);
                            if (targetFields.Field[index].CheckValue(value)) {
                                featureBuffer.set_Value(index, value);
                            }
                        }
                    }
                }
                insertCursor.InsertFeature(featureBuffer);
                ComReleaser.ReleaseComObject(shape);
            }
            insertCursor.Flush();
            ComReleaser.ReleaseComObject(sourceFields);
            ComReleaser.ReleaseComObject(targetFields);
            ComReleaser.ReleaseComObject(cursor);
            ComReleaser.ReleaseComObject(queryFilter);
            ComReleaser.ReleaseComObject(insertCursor);
            ComReleaser.ReleaseComObject(featureBuffer);
        }
    }

    public static partial class JTLoadData {
        /// <summary>
        /// Test 16s
        /// </summary>
        /// <param name="sourceFeatureClass"></param>
        /// <param name="targetFeatureClass"></param>
        public static bool LoadData_LoadOnlyMode(IFeatureClass sourceFeatureClass, IFeatureClass targetFeatureClass, string queryClause = null) {
            if (!JTExclusiveSchemaLockEnable(targetFeatureClass)) { return false; }
            using (var fcLock = new JTFeatureClassExclusiveSchemaLock(targetFeatureClass)) {
                var featureClassLoad = (IFeatureClassLoad)targetFeatureClass;
                IFeatureBuffer featureBuffer = null;
                IFeatureCursor insertCursor = null;
                IQueryFilter queryFilter = null;
                IFeatureCursor cursor = null;
                IFields sourceFields = null;
                IFields targetFields = null;
                try {
                    featureClassLoad.LoadOnlyMode = true;
                    featureBuffer = targetFeatureClass.CreateFeatureBuffer();
                    insertCursor = targetFeatureClass.Insert(true);
                    sourceFields = sourceFeatureClass.Fields;
                    var sourceFieldsCount = sourceFields.FieldCount;
                    targetFields = targetFeatureClass.Fields;
                    if (!string.IsNullOrEmpty(queryClause)) { queryFilter = new QueryFilterClass { WhereClause = queryClause }; }
                    cursor = sourceFeatureClass.Search(queryFilter, true);
                    IFeature sourceFeature = null;
                    while ((sourceFeature = cursor.NextFeature()) != null) {
                        featureBuffer.Shape = sourceFeature.Shape;
                        for (int i = 0; i < sourceFieldsCount; i++) {
                            IField field = sourceFeature.Fields.get_Field(i);
                            if (field.Editable && field.Type != esriFieldType.esriFieldTypeOID && field.Type != esriFieldType.esriFieldTypeGeometry && field.Type != esriFieldType.esriFieldTypeGlobalID && field.Type != esriFieldType.esriFieldTypeGUID) {
                                var fieldName = field.Name;
                                int index = featureBuffer.Fields.FindField(fieldName);
                                if (index > -1) {
                                    var value = sourceFeature.get_Value(i);
                                    if (targetFields.Field[index].CheckValue(value)) {
                                        featureBuffer.set_Value(index, value);
                                    }
                                }
                            }
                        }
                        insertCursor.InsertFeature(featureBuffer);
                    }
                    insertCursor.Flush();
                } finally {
                    featureClassLoad.LoadOnlyMode = false;
                    ComReleaser.ReleaseComObject(targetFields);
                    ComReleaser.ReleaseComObject(sourceFields);
                    ComReleaser.ReleaseComObject(cursor);
                    ComReleaser.ReleaseComObject(queryFilter);
                    ComReleaser.ReleaseComObject(insertCursor);
                    ComReleaser.ReleaseComObject(featureBuffer);
                }
            }
            return true;
        }

        private static bool JTExclusiveSchemaLockEnable(IFeatureClass fc) {
            if (fc == null) { throw new NullReferenceException(); }
            if (fc is ISchemaLock sl) {
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
                ComReleaser.ReleaseComObject(sli);
                ComReleaser.ReleaseComObject(enumSLI);
                return !hasExclusiveLock && count <= 1;
            }
            throw new NullReferenceException();
        }

    }
    public static partial class JTLoadData {
        /// <summary>
        /// Test 181s
        /// </summary>
        /// <param name="sourceFeatureClass"></param>
        /// <param name="targetFeatureClass"></param>
        public static bool LoadData_Write(IFeatureClass sourceFeatureClass, IFeatureClass targetFeatureClass, string queryClause = null) {
            var featureClassWrite = targetFeatureClass as IFeatureClassWrite;
            var sourceFields = sourceFeatureClass.Fields;
            var sourceFieldsCount = sourceFields.FieldCount;
            var targetFields = targetFeatureClass.Fields;
            IQueryFilter queryFilter = null;
            if (!string.IsNullOrEmpty(queryClause)) { queryFilter = new QueryFilterClass { WhereClause = queryClause }; }
            var cursor = sourceFeatureClass.Search(queryFilter, true);
            IFeature sourceFeature = null;
            while ((sourceFeature = cursor.NextFeature()) != null) {
                var targetFeature = targetFeatureClass.CreateFeature();
                targetFeature.Shape = sourceFeature.Shape;
                for (int i = 0; i < sourceFieldsCount; ++i) {
                    var field = sourceFields.get_Field(i);
                    if (field.Editable && field.Type != esriFieldType.esriFieldTypeOID && field.Type != esriFieldType.esriFieldTypeGeometry && field.Type != esriFieldType.esriFieldTypeGlobalID && field.Type != esriFieldType.esriFieldTypeGUID) {
                        var fieldName = field.Name;
                        int index = targetFields.FindField(fieldName);
                        if (index > -1) {
                            var value = sourceFeature.get_Value(i);
                            if (targetFields.Field[index].CheckValue(value)) {
                                targetFeature.set_Value(index, value);
                            }
                        }
                    }
                }
                featureClassWrite.WriteFeature(targetFeature);
                ComReleaser.ReleaseComObject(targetFeature);
            }
            ComReleaser.ReleaseComObject(cursor);
            ComReleaser.ReleaseComObject(queryFilter);
            ComReleaser.ReleaseComObject(targetFields);
            ComReleaser.ReleaseComObject(sourceFields);

            return true;
        }
    }
}
