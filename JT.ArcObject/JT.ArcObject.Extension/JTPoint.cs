using ESRI.ArcGIS.Geometry;
using System;
namespace JT.ArcObject.Extension {
    public static partial class JTPoint {
        public static double JT2DDistance(this IPoint p1, IPoint p2) {
            var xDis = Math.Abs(p1.X - p2.X);
            var yDis = Math.Abs(p2.Y - p2.Y);
            return Math.Sqrt((xDis * xDis) + (yDis * yDis));
        }
    }
}
