using System;

namespace JT.Jeo {
    public static partial class Jeo2DOperate {
        public static double Distance(double x1, double y1, double x2, double y2) {
            var x = x1 - x2;
            var y = y1 - y2;
            return Math.Sqrt(x * x + y * y);
        }

        public static bool WithinLimitDistance(double limit, double x1, double y1, double x2, double y2) {
            var x = Math.Abs(x1 - x2);
            var y = Math.Abs(y1 - y2);
            if (x > limit || y > limit) { return false; }
            return Math.Sqrt(x * x + y * y) < limit;
        }

        public static bool WithinLimitDistance(double limit, double x1, double y1, double x2, double y2, out double dis) {
            var x = Math.Abs(x1 - x2);
            var y = Math.Abs(y1 - y2);
            if (x > limit || y > limit) {
                dis = -1;
                return false;
            }
            dis = Math.Sqrt(x * x + y * y);
            return dis < limit;
        }
    }
    public static partial class Jeo2DOperate {
        public static double PointAtLineSide(double x, double y, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y) {
            return ((linePoint1Y - linePoint2Y) * x) + ((linePoint2X - linePoint1X) * y) + (linePoint1X * linePoint2Y) - (linePoint2X * linePoint1Y);
        }

        public static bool PointAtLineLeft(double x, double y, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y) {
            return PointAtLineSide(x, y, linePoint1X, linePoint1Y, linePoint2X, linePoint2Y) > 0;
        }

        public static bool PointOnLine(double x, double y, double linePoint1X, double linePoint1Y, double linePoint2X, double linePoint2Y) {
            return PointAtLineSide(x, y, linePoint1X, linePoint1Y, linePoint2X, linePoint2Y) == 0;
        }

    }

    public static partial class Jeo2DOperate {
        public static double Slope(double x1, double y1, double x2, double y2) {
            var xc = x2 - x1;
            if (xc == 0) { return 0; }
            return (y2 - y1) / xc;
        }
    }

    public static partial class Jeo2DOperate {
        public static double Radian(double x1, double y1, double x2, double y2) {
            return Math.Atan2(y2 - y1, x2 - x1);
        }

        public static double Radian(double angle) {
            return angle * RadianPerAngle;
        }
    }

    public static partial class Jeo2DOperate {
        public static double Angle(double x1, double y1, double x2, double y2) {
            return Radian(x1, y1, x2, y2) * AnglePerRadian;
        }

        public static double Angle(double radian) {
            return radian * AnglePerRadian;
        }
    }

    public static partial class Jeo2DOperate {
        public static void In() {

        }
    }

    public static partial class Jeo2DOperate {
        public const double PI = Math.PI;
        public static readonly double RadianPerAngle = PI / 180;
        public static readonly double AnglePerRadian = 180 / PI;
    }
}
