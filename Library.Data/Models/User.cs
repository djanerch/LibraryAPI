using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 90)]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(maximumLength: 90)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Book> MyBooks { get; set; } = new HashSet<Book>();
    }
}
