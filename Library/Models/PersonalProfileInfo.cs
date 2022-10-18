using System.Collections.Generic;

namespace Library.Api.Models
{
    public class PersonalProfileInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Points { get; set; }
        public IList<BookWithHeader> Books { get; set; }
    }
}
