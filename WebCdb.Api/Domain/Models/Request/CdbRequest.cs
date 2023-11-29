using DataAnnotationsExtensions;

namespace WebCdb.Models.Request
{
    public class CdbRequest
    {
        [Min(0.01)]
        public decimal value { get; set; }
        [Min(2)]
        public int period { get; set; }
    }
}