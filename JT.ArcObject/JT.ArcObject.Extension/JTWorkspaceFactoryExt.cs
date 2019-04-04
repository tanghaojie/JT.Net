using ESRI.ArcGIS.Geodatabase;
namespace JT.ArcObject.Extension {
    public static partial class JTWorkspaceFactoryExt {
        public static void JTUnlock(this IWorkspaceFactory wsf) {
            if (!(wsf is IWorkspaceFactoryLockControl wsfLock)) { return; }
            if (wsfLock.SchemaLockingEnabled) {
                wsfLock.DisableSchemaLocking();
            }
        }
    }
    public static partial class JTWorkspaceFactoryExt {

    }
    public static partial class JTWorkspaceFactoryExt {

    }
    public static partial class JTWorkspaceFactoryExt {

    }
    public static partial class JTWorkspaceFactoryExt {

    }
    public static partial class JTWorkspaceFactoryExt {

    }
    public static partial class JTWorkspaceFactoryExt {

    }

}
