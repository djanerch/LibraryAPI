using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckBooksController : ControllerBase
    {
        private IBookService bookService;
        private IUserService userService;
        public CheckBooksController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable CheckBooks()
        {
            if (userService.GetCurrentUser(HttpContext).Role == "Admin")
            {
                return bookService.CheckBooks();
            }
            return null;
        }
    }
}
