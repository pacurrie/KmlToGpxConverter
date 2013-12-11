using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmlToGpxConverter
{
    internal static class GpsTimePointMutator
    {
        private static CultureInfo culture = new CultureInfo("en-US");

        public static GpsTimePoint AdjustElevation(GpsTimePoint gpsPoint, decimal elevationAdjustment)
        {
            var elevation = Decimal.Parse(gpsPoint.elevation, culture);
            elevation += elevationAdjustment;
            return new GpsTimePoint(gpsPoint, elevation: elevation.ToString());
        }

        public static GpsTimePoint StripElevation(GpsTimePoint gpsPoint)
        {
            if (string.IsNullOrWhiteSpace(gpsPoint.elevation))
            {
                return gpsPoint;
            }
            else
            {
                return new GpsTimePoint(gpsPoint, elevation: string.Empty);
            }
        }
    }
}
