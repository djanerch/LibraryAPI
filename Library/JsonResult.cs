using System.Collections;

namespace Library.Api
{
    public class JsonResult
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable Results { get; set; }
    }
}