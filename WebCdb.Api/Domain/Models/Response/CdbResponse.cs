using Newtonsoft.Json;

namespace WebCdb.Models.Response
{
    public class CdbResponse
    {
        [JsonProperty("rawValue")]
        public decimal RawValue { get; set; }
        [JsonProperty("liquidValue")]
        public decimal LiquidValue { get; set; }
    }
}