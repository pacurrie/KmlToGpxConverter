using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KmlToGpxConverter
{
    internal static class KmlReader
    {
        public static IList<GpsTimePoint> ReadFile(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            var nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
            nsManager.AddNamespace("gx", @"http://www.google.com/kml/ext/2.2");

            var list = xmlDoc.SelectNodes("//gx:MultiTrack/gx:Track", nsManager);
            var nodes = new List<GpsTimePoint>();
            foreach (XmlNode element in list)
            {
                nodes.AddRange(GetGpsPoints(element.ChildNodes));
            }

            return nodes;
        }

        private static IList<GpsTimePoint> GetGpsPoints(XmlNodeList nodes)
        {
            var retVal = new List<GpsTimePoint>();

            var e = nodes.GetEnumerator();
            while (e.MoveNext())
            {
                var utcTimepoint = ((XmlNode)e.Current).InnerText;

                if (!e.MoveNext()) break;

                var t = ((XmlNode)e.Current).InnerText.Split(new[] { ' ' });
                if (t.Length < 2) continue;

                retVal.Add(new GpsTimePoint(t[0], t[1], t.ElementAtOrDefault(2), utcTimepoint));
            }

            return retVal;
        }
    }
}
