namespace JT.GDal {
    public class JTGdalInstaller {
        public JTGdalInstaller() {
            GdalConfiguration.ConfigureGdal();
            GdalConfiguration.ConfigureOgr();
        }

        //Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
        //Gdal.SetConfigOption("SHAPE_ENCODING", "");
    }
}
