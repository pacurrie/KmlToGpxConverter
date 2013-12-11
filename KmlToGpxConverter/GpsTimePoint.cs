namespace KmlToGpxConverter
{
    internal class GpsTimePoint
    {
        public string longitude { get; private set; }
        public string latitude { get; private set; }
        public string elevation { get; private set; }
        public string utcTimepoint { get; private set; }

        public GpsTimePoint(string _longitude, string _latitude, string _elevation, string _utcTimepoint)
        {
            longitude = _longitude;
            latitude = _latitude;
            elevation = _elevation;
            utcTimepoint = _utcTimepoint;
        }

        public GpsTimePoint(GpsTimePoint baseObj, string longitude = null, string latitude = null, string elevation = null, string utcTimepoint = null)
            : this( longitude == null ? baseObj.longitude : longitude,
                    latitude == null ? baseObj.latitude : latitude,
                    elevation == null ? baseObj.elevation : elevation,
                    utcTimepoint == null ? baseObj.utcTimepoint : utcTimepoint)
        {
        }
    }
}
