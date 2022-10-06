using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Header { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Description { get; set; }
        public int Pages { get; set; }
        public int Rating { get; set; }
        public bool IsFree { get; set; } = true;
    }
}