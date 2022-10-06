using Library.Models;
using Library.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Controllers
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
        public IEnumerable<BookApiModel> Get()
        {
            return service.AllBooks();
        }
    }
}