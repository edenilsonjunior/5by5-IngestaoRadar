using Repositories;
using Models;

namespace Services
{
    public class FileGeneratorService
    {

        public FileGeneratorService() { }

        public string GenerateCsv(List<Radar> list)
        {
            string csv = "";

            foreach (Radar radar in list)
            {
                csv += radar.ToCsv() + "\n";
            }

            new PersistDataFileRepository(csv, "csv").SaveToFile();
            return csv;
        }

        public string GenerateJson(List<Radar> list)
        {
            string json = "[";

            foreach (var radar in list)
            {
                json += radar.ToJson() + ",";
            }

            json = json.Remove(json.Length - 1);
            json += "]";

            new PersistDataFileRepository(json, "json").SaveToFile();

            return json;
        }

        public string GenerateXml(List<Radar> list)
        {
            string xml = "<Radars>";

            foreach (var radar in list)
            {
                xml += radar.ToXml();
            }

            xml += "</Radars>";

            new PersistDataFileRepository(xml, "xml").SaveToFile();

            return xml;
        }
    }
}
