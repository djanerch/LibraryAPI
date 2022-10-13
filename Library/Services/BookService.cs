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
        public void AddNewBook(BookDto book)
        {
            if (context.Books.FirstOrDefault(x=> x.Header == book.Header) != null)
            {
                return;
            }

            Book newBook = new Book()
            {
                Header = book.Header,
                Description = book.Description,
                Pages = book.Pages,
                Rating = book.Rating
            };

            context.Books.Add(newBook);

            context.SaveChanges();
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

        public string RemoveBookByName(string header)
        {
            var book = context.Books.FirstOrDefault(x => x.Header == header);
            if (book != null)
            {
                context.Books.Remove(book);

                context.SaveChanges();

                return $"Book with header: {header} is removed from library";
            }
            return "Book does't exist in library.";
        }

        public string TakeBookByName(string header, UserModel user)
        {
            var book = context.Books.FirstOrDefault(x => x.Header == header);
            if (book != null)
            {
                if (book.IsFree == false)
                {
                    return "This book is busy at now.";
                }

                var dbUser = context.Users.FirstOrDefault(x => x.Name == user.Username && x.Email == user.EmailAddress);

                dbUser.MyBooks.Add(book);

                book.IsFree = false;

                context.SaveChanges();

                return $"Book with header: {header} is added to your collection.";
            }
            return "You cannot get this book!";
        }
    }
}
