using ESRI.ArcGIS.Geodatabase;
using JT.ADF;
using System;
namespace JT.ArcObject {
    public partial class JTFeatureClassExclusiveSchemaLock : IDisposable {
        public JTFeatureClassExclusiveSchemaLock(IFeatureClass fc) {
            if (fc == null) { throw new ArgumentNullException(); }
            if (!JTExclusiveSchemaLockEnable(fc)) { throw new JTFeatureClassExclusiveSchemaLockUnableException(); }
            if (!(fc is ISchemaLock sl)) { throw new NullReferenceException(); }
            schemaLock = sl;
            schemaLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
        }
        ~JTFeatureClassExclusiveSchemaLock() { Dispose(); }
    }
    public partial class JTFeatureClassExclusiveSchemaLock {
        public class JTFeatureClassExclusiveSchemaLockUnableException : Exception { };
    }
    public partial class JTFeatureClassExclusiveSchemaLock {
        private bool JTExclusiveSchemaLockEnable(IFeatureClass fc) {
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
    public partial class JTFeatureClassExclusiveSchemaLock {
        public void Dispose() {
            if (schemaLock != null) { schemaLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock); }
        }
    }
    public partial class JTFeatureClassExclusiveSchemaLock {
        public ISchemaLock schemaLock = null;
    }
}
