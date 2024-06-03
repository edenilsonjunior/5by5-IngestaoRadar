using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.Json;
using System.Xml.Linq;

namespace Models
{
    public class Radar
    {
        [JsonProperty("concessionaria")]
        public string ConcessionaryCompany { get; set; }


        [JsonProperty("ano_do_pnv_snv")]
        public int YearPvnSvn { get; set; }


        [JsonProperty("tipo_de_radar")]
        public string RadarType { get; set; }


        [JsonProperty("rodovia")]
        public string Highway { get; set; }


        [JsonProperty("uf")]
        public string State { get; set; }


        [JsonProperty("km_m")]
        public string KmM { get; set; }


        [JsonProperty("municipio")]
        public string City { get; set; }


        [JsonProperty("tipo_pista")]
        public string LaneType { get; set; }


        [JsonProperty("sentido")]
        public string Direction { get; set; }


        [JsonProperty("situacao")]
        public string Situation { get; set; }


        [JsonProperty("data_da_inativacao")]
        public DateOnly[] InactivationDate { get; set; }


        [JsonProperty("latitude")]
        public double Latitude { get; set; }


        [JsonProperty("longitude")]
        public double Longitude { get; set; }


        [JsonProperty("velocidade_leve")]
        public int LightSpeed { get; set; }

        public override string ToString()
        {

            return $"Concessionária....: {ConcessionaryCompany}\n" +
                   $"Ano do PNV/SNV....: {YearPvnSvn}\n" +
                   $"Tipo de radar.....: {RadarType}\n" +
                   $"Rodovia...........: {Highway}\n" +
                   $"UF................: {State}\n" +
                   $"Km/m..............: {KmM}\n" +
                   $"Município.........: {City}\n" +
                   $"Tipo de pista.....: {LaneType}\n" +
                   $"Sentido...........: {Direction}\n" +
                   $"Situação..........: {Situation}\n" +
                   $"Data da inativação: {string.Join(", ", InactivationDate)}\n" +
                   $"Latitude..........: {Latitude}\n" +
                   $"Longitude.........: {Longitude}\n" +
                   $"Velocidade limite.: {LightSpeed}";
        }

        public string ToCsv()
        {
            return $"{ConcessionaryCompany};{YearPvnSvn};{RadarType};{Highway};{State};{KmM};{City};{LaneType};{Direction};{Situation};{string.Join(", ", InactivationDate)};{Latitude};{Longitude};{LightSpeed}";
        }

        public string ToXml()
        {
            var xml = new XElement("radar",
                    new XElement("concessionaria", ConcessionaryCompany),
                    new XElement("ano_do_pnv_snv", YearPvnSvn),
                    new XElement("tipo_de_radar", RadarType),
                    new XElement("rodovia", Highway),
                    new XElement("uf", State),
                    new XElement("km_m", KmM),
                    new XElement("municipio", City),
                    new XElement("tipo_pista", LaneType),
                    new XElement("sentido", Direction),
                    new XElement("situacao", Situation),
                    new XElement("data_da_inativacao", string.Empty),
                    new XElement("latitude", Latitude),
                    new XElement("longitude", Longitude),
                    new XElement("velocidade_leve", LightSpeed)
            );

            return xml.ToString();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
 