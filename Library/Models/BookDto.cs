using System.ComponentModel.DataAnnotations;

namespace Library.Api.Models
{
    public class BookDto
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Header { get; set; }
        [Required]
        [StringLength(maximumLength: 4000)]
        public string Description { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Rating { get; set; }
    }
}
