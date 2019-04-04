using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace JT.ADF {
    public partial class ComReleaser {
        public ComReleaser() { }
        ~ComReleaser() { Dispose(); }
    }
    public partial class ComReleaser : IDisposable {
        public void Dispose() {
            try {
                var count = comObjects.Count;
                for (int i = 0; i < count; i++) {
                    var obj = comObjects[i];
                    ReleaseComObject(obj);
                }
            } finally {
                comObjects.Clear();
            }
        }
    }
    public partial class ComReleaser {
        public void ManageLifetime(object obj) {
            if (obj == null) { return; }
            try { comObjects.Add(obj); } catch { }
        }
    }
    public partial class ComReleaser {
        private readonly IList<object> comObjects = new List<object>();
    }
    public partial class ComReleaser {
        public static void ReleaseComObject(object obj) {
            if (obj == null) { return; }
            try {
                var refCount = 0;
                do { refCount = Marshal.ReleaseComObject(obj); } while (refCount > 0);
            } finally { obj = null; }
        }
    }
}
