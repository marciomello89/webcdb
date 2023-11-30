using Newtonsoft.Json;

namespace WebCdb.Models.Response
{
    public class CdbResponse
    {
        [JsonProperty("rawValue")]
        public decimal rawValue { get; set; }
        [JsonProperty("liquidValue")]
        public decimal liquidValue { get; set; }
    }
}