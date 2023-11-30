using DataAnnotationsExtensions;
using Newtonsoft.Json;

namespace WebCdb.Models.Request
{
    public class CdbRequest
    {
        [JsonProperty("value")]
        [Min(0.01)]
        public decimal value { get; set; }
        [JsonProperty("period")]
        [Min(2)]
        public int period { get; set; }
    }
}