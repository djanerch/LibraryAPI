using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
