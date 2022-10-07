using Library.Api.Dtos;
using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddBookController : ControllerBase
    {
        private IBookService service;
        public AddBookController(IBookService _service)
        {
            service = _service;
        }

        [HttpPost]
        public bool Post(BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            
            return service.AddNewBook(book);
        }
    }
}