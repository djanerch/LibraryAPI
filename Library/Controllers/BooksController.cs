using Library.Api.Models;
using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService service;
        public BooksController(IBookService _service)
        {
            service = _service;
        }
        [HttpGet]
        public IEnumerable<BookApiModel> Get(string header = "", bool isFree = true, int fromPages = 0, int toPages = 400)
        {
            BookFilter filter = new BookFilter()
            {
                Header = header,
                IsFree = isFree,
                FromPages = fromPages,
                ToPages = toPages
            };

            return service.AllBooks(filter);
        }
    }
}