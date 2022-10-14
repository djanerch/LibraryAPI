using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime LastDateForGiveBack { get; set; }
        public bool Overdue { get; set; } = false;
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}