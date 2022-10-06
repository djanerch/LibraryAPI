using Library.Dtos;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        bool AddNewBook(BookDto book);
    }
}
