using JT.Enum.Extension;
using OSGeo.OGR;
using System;
namespace JT.GDal.ShapeFile {

    public partial class ShapeFile : JTGdalInstaller, IDisposable {
        public ShapeFile(string path, bool edit = false) : base() {
            try {
                var driver = Ogr.GetDriverByName(Standards.OgrDriverNames.ESRIShapefile.JTAttributeValue<string>());
                if (driver == null) { throw new EsriShapeFileDriverNullException(); }
                Data = driver.Open(path, edit ? 1 : 0);
                driver.Dispose();
                if (Data == null) { throw new DataSourceNullException(); }
            } catch { throw; }
        }
    }
    public partial class ShapeFile {
        public void Dispose() { Data.Dispose(); }
    }
    public partial class ShapeFile {
        public DataSource Data { get; }
        public int LayerCount => Data.GetLayerCount();
    }
    public partial class ShapeFile {
        public Layer this[int index] {
            get {
                if (index < 0 || index >= LayerCount) { throw new IndexOutOfRangeException(); }
                return Data.GetLayerByIndex(index);
            }
        }
        public Layer this[string name] => Data.GetLayerByName(name);
    }
    public class EsriShapeFileDriverNullException : Exception {
        public EsriShapeFileDriverNullException() : base() { }
    }
    public class DataSourceNullException : Exception {
        public DataSourceNullException() : base() { }
    }
}
