using Library.Data;
using Library.Data.Models;
using Library.Dtos;
using Library.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private LibraryDbContext context;
        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }
        public bool AddNewBook(BookDto book)
        {
            if (context.Books.FirstOrDefault(x=> x.Header == book.Header) != null)
            {
                return false;
            }

            Book newBook = new Book()
            {
                Header = book.Header,
                Description = book.Description,
                Pages = book.Pages,
                Rating = book.Rating,
                IsFree = book.IsFree
            };

            context.Books.Add(newBook);

            context.SaveChanges();

            return true;
        }
    }
}
