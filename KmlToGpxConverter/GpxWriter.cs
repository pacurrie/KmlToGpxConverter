using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KmlToGpxConverter
{
    internal static class GpxWriter
    {
        public const string FileExtension = "gpx";

        public static void WriteFile(string filename, IEnumerable<GpsTimePoint> nodes)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineHandling = NewLineHandling.Replace;

            using (var outputFile = XmlWriter.Create(filename, settings))
            {
                outputFile.WriteStartDocument();
                outputFile.WriteStartElement("trk");
                outputFile.WriteElementString("name", "No name");
                outputFile.WriteStartElement("trkseg");

                foreach (var trackNode in nodes)
                {
                    outputFile.WriteStartElement("trkpt");
                    outputFile.WriteAttributeString("lat", trackNode.latitude);
                    outputFile.WriteAttributeString("lon", trackNode.longitude);

                    if (!string.IsNullOrWhiteSpace(trackNode.elevation))
                    {
                        outputFile.WriteElementString("ele", trackNode.elevation);
                    }
                    outputFile.WriteElementString("time", trackNode.utcTimepoint);

                    outputFile.WriteEndElement(); // </trkpt>
                }

                outputFile.WriteEndElement(); // </trkseg>
                outputFile.WriteEndElement(); // </trk>
                outputFile.WriteEndDocument();
            }
        }
    }
}
