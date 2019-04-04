using ESRI.ArcGIS.Geometry;
namespace JT.ArcObject.Extension {
    public static partial class JTSpatialReferenceExt {

        public static bool JTSameAs(this ISpheroid self, ISpheroid other) {
            return ((self == null && other == null) || (self != null && other != null && self.Name == other.Name && self.SemiMajorAxis == other.SemiMajorAxis && self.SemiMinorAxis == other.SemiMinorAxis && self.Flattening == other.Flattening));
        }

    }

    public static partial class JTSpatialReferenceExt {

        public static bool JTSameAs(this IDatum self, IDatum other) {
            return ((self == null && other == null) || (self != null && other != null && self.Name == other.Name && JTSameAs(self.Spheroid, other.Spheroid)));
        }

    }

    public static partial class JTSpatialReferenceExt {

        public static bool JTSameAs(this IAngularUnit self, IAngularUnit other) {
            return ((self == null && other == null) || (self != null && other != null && self.Name == other.Name && self.ConversionFactor == other.ConversionFactor && self.RadiansPerUnit == other.RadiansPerUnit));
        }

    }

    public static partial class JTSpatialReferenceExt {

        public static bool JTSameAs(this IPrimeMeridian self, IPrimeMeridian other) {
            return ((self == null && other == null) || (self != null && other != null && self.Name == other.Name && self.Longitude == other.Longitude));
        }

    }

    public static partial class JTSpatialReferenceExt {

        public static bool JTSameAs(this IGeographicCoordinateSystem self, IGeographicCoordinateSystem other) {
            return ((self == null && other == null) || (self != null && other != null && self.Name == other.Name && self.FactoryCode == other.FactoryCode && JTSameAs(self.Datum, other.Datum) && JTSameAs(self.CoordinateUnit, other.CoordinateUnit) && JTSameAs(self.PrimeMeridian, other.PrimeMeridian)));
        }
    }

    public static partial class JTSpatialReferenceExt {

        public static bool JTSameAs(this IProjectedCoordinateSystem self, IProjectedCoordinateSystem other) {
            if (self == null && other == null) {
                return true;
            } else if (self != null && other != null) {
                #region
                double azimuth1 = double.NaN;
                double azimuth2 = double.NaN;
                try { azimuth1 = self.Azimuth; } catch { }
                try { azimuth2 = other.Azimuth; } catch { }

                double centralParallel1 = double.NaN;
                double centralParallel2 = double.NaN;
                try { centralParallel1 = self.CentralParallel; } catch { }
                try { centralParallel2 = other.CentralParallel; } catch { }

                double latitudeOf1st1 = double.NaN;
                double latitudeOf1st2 = double.NaN;
                try { latitudeOf1st1 = self.LatitudeOf1st; } catch { }
                try { latitudeOf1st2 = other.LatitudeOf1st; } catch { }

                double latitudeOf2nd1 = double.NaN;
                double latitudeOf2nd2 = double.NaN;
                try { latitudeOf2nd1 = self.LatitudeOf2nd; } catch { }
                try { latitudeOf2nd2 = other.LatitudeOf2nd; } catch { }

                double longitudeOf1st1 = double.NaN;
                double longitudeOf1st2 = double.NaN;
                try { longitudeOf1st1 = self.LongitudeOf1st; } catch { }
                try { longitudeOf1st2 = other.LongitudeOf1st; } catch { }

                double longitudeOf2nd1 = double.NaN;
                double longitudeOf2nd2 = double.NaN;
                try { longitudeOf2nd1 = self.LongitudeOf2nd; } catch { }
                try { longitudeOf2nd2 = other.LongitudeOf2nd; } catch { }

                double longitudeOfOrigin1 = double.NaN;
                double longitudeOfOrigin2 = double.NaN;
                try { longitudeOfOrigin1 = self.LongitudeOfOrigin; } catch { }
                try { longitudeOfOrigin2 = other.LongitudeOfOrigin; } catch { }

                double standardParallel1_1 = double.NaN;
                double standardParallel1_2 = double.NaN;
                try { standardParallel1_1 = self.StandardParallel1; } catch { }
                try { standardParallel1_2 = other.StandardParallel1; } catch { }

                double standardParallel2_1 = double.NaN;
                double standardParallel2_2 = double.NaN;
                try { standardParallel2_1 = self.StandardParallel2; } catch { }
                try { standardParallel2_2 = other.StandardParallel2; } catch { }

                double scaleFactor1 = double.NaN;
                double scaleFactor2 = double.NaN;
                try { scaleFactor1 = self.ScaleFactor; } catch { }
                try { scaleFactor2 = other.ScaleFactor; } catch { }

                #endregion
                return (self.Name == other.Name && self.FactoryCode == other.FactoryCode && ((azimuth1 == azimuth2) || (double.IsNaN(azimuth1) && double.IsNaN(azimuth2))) && self.get_CentralMeridian(true) == other.get_CentralMeridian(true) && ((centralParallel1 == centralParallel2) || (double.IsNaN(centralParallel1) && double.IsNaN(centralParallel2))) && self.FalseEasting == other.FalseEasting && self.FalseNorthing == other.FalseNorthing && ((latitudeOf1st1 == latitudeOf1st2) || (double.IsNaN(latitudeOf1st1) && double.IsNaN(latitudeOf1st2))) && ((latitudeOf2nd1 == latitudeOf2nd2) || (double.IsNaN(latitudeOf2nd1) && double.IsNaN(latitudeOf2nd2))) && ((longitudeOf1st1 == longitudeOf1st2) || (double.IsNaN(longitudeOf1st1) && double.IsNaN(longitudeOf1st2))) && ((longitudeOf2nd1 == longitudeOf2nd2) || (double.IsNaN(longitudeOf2nd1) && double.IsNaN(longitudeOf2nd2))) && ((longitudeOfOrigin1 == longitudeOfOrigin2) || (double.IsNaN(longitudeOfOrigin1) && double.IsNaN(longitudeOfOrigin2))) && ((standardParallel1_1 == standardParallel1_2) || (double.IsNaN(standardParallel1_1) && double.IsNaN(standardParallel1_2))) && ((standardParallel2_1 == standardParallel2_2) || (double.IsNaN(standardParallel2_1) && double.IsNaN(standardParallel2_2))) && ((scaleFactor1 == scaleFactor2) || (double.IsNaN(scaleFactor1) && double.IsNaN(scaleFactor2))) && JTSameAs(self.CoordinateUnit, other.CoordinateUnit) && JTSameAs(self.GeographicCoordinateSystem, other.GeographicCoordinateSystem));
            } else {
                return false;
            }
        }

    }

    public static partial class JTSpatialReferenceExt {

        public static bool JTSameAs(this ILinearUnit self, ILinearUnit other) {
            return ((self == null && other == null) || (self != null && other != null && self.Name == other.Name && self.ConversionFactor == other.ConversionFactor && self.MetersPerUnit == other.MetersPerUnit));
        }

    }

    public static partial class JTSpatialReferenceExt {

        public static bool JTSameAs(this ISpatialReference self, ISpatialReference other) {
            return ((self == null && other == null) || (self != null && other != null && self.Name == other.Name && self.FactoryCode == other.FactoryCode && JTSameAs(self as IProjectedCoordinateSystem, other as IProjectedCoordinateSystem) && JTSameAs(self as IGeographicCoordinateSystem, other as IGeographicCoordinateSystem)));
        }

    }

    public static partial class JTSpatialReferenceExt {

    }

    public static partial class JTSpatialReferenceExt {

    }

}
