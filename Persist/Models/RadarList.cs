using Newtonsoft.Json;

namespace Models
{
    public class RadarList
    {

        [JsonProperty("radar")]
        public List<Radar> Lst { get; set; }
    }
}
