using System.Collections.Generic;

namespace Library.Api.Models
{
    public class AllProfileInfo
    {
        public string Username { get; set; }
        public IList<BookWithHeader> Books { get; set; }
    }
}
