using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class User
    {
        public User()
        {
            Books = new List<Book>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 90)]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(maximumLength: 90)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Points { get; set; } = 10;
        public IList<Book> Books { get; set; }
    }
}
