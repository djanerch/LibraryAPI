using Library.Api.Dtos;
using Library.Api.Models;
using System.Collections.Generic;

namespace Library.Api.Services.Contracts
{
    public interface IBookService
    {
        void AddNewBook(BookDto book);
        IEnumerable<BookApiModel> AllBooks(BookFilter filter);
    }
}
