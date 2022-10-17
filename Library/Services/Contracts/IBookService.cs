using Library.Api.Models;
using System.Collections.Generic;

namespace Library.Api.Services.Contracts
{
    public interface IBookService
    {
        void AddNewBook(BookDto book);
        JsonResult AllBooks(BookFilter filter);
        string RemoveBookByName(string header);
        string TakeBookByName(string header, UserModel user);
        IEnumerable<BookWithReaderId> CheckBooks();
        string GiveBackBookByName(string header, UserModel user);
    }
}
