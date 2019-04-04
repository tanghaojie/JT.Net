using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
namespace JT.ArcObject {
    public static partial class JTSDE {
        public const string SERVER = "SERVER";
        public const string INSTANCE = "INSTANCE";
        public const string DATABASE = "DATABASE";
        public const string USER = "USER";
        public const string PASSWORD = "PASSWORD";
        public const string VERSION = "VERSION";
    }

    public static partial class JTSDE {
    }

    public static partial class JTSDE {
        //public static IPropertySet SdeProprtySet(string ip, string instance, string database, string user, string password, string version) {
        //    IPropertySet propertySet = new PropertySetClass();
        //    propertySet.SetProperty(SERVER, ip);
        //    propertySet.SetProperty(INSTANCE, );
        //    propertySet.SetProperty();
        //    propertySet.SetProperty();
        //    propertySet.SetProperty();
        //    propertySet.SetProperty();
        //}
    }

    public static partial class JTSDE {

    }

    public static partial class JTSDE {

    }

    public static partial class JTSDE {
        private static object locker = new object();
        private static volatile IWorkspaceFactory workspaceFactory;
        public static IWorkspaceFactory WorkspaceFactory {
            get {
                if (null == workspaceFactory) { lock (locker) { if (null == workspaceFactory) { workspaceFactory = new SdeWorkspaceFactoryClass(); } } }
                return workspaceFactory;
            }
        }
    }

    public static partial class JTSDE {

    }

    public static partial class JTSDE {

    }
}
