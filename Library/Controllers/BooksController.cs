using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<BookApiModel> Get()
        {
            return new List<BookApiModel>()
            {
                new BookApiModel()
                {
                    Header = "first",
                    Description = "first book",
                    Pages = 200
                },
                new BookApiModel()
                {
                    Header = "second",
                    Description = "second book",
                    Pages = 201
                },
                new BookApiModel()
                {
                    Header = "third",
                    Description = "third book",
                    Pages = 202
                },
                new BookApiModel()
                {
                    Header = "fourth",
                    Description = "fourth book",
                    Pages = 203
                }
            };
        }
    }
}
