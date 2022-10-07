using Library.Dtos;
using Library.Models;
using System.Collections.Generic;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        bool AddNewBook(BookDto book);
        IEnumerable<BookApiModel> AllBooks(BookFilter filter);
    }
}
