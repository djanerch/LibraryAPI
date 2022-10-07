using Library.Api.Dtos;
using Library.Api.Models;
using Library.Api.Services.Contracts;
using Library.Data;
using Library.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Api.Services
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

        public IEnumerable<BookApiModel> AllBooks(BookFilter filter)
        {
            return context
                .Books
                .Where(x => x.Pages >= filter.FromPages && x.Pages <= filter.ToPages 
                && x.Header.Contains(filter.Header) && x.IsFree == filter.IsFree)
                .Select(x => new BookApiModel
                {
                    Header = x.Header,
                    Description = x.Description,
                    Pages = x.Pages
                })
                .ToList();
        }
    }
}
