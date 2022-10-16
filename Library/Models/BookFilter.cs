namespace Library.Api.Models
{
    public class BookFilter
    {
        public string Header { get; set; }
        public bool IsFree { get; set; }
        public int FromPages { get; set; }
        public int ToPages { get; set; }
        public int Page { get; set; }
    }
}