using Library.Api.Models;
using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveBookController : ControllerBase
    {
        private IBookService bookService;
        private IUserService userService;
        public RemoveBookController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult RemoveBook(BookWithHeader book)
        {
            if (userService.GetCurrentUser(HttpContext).Role == "Admin")
            {
                string result = bookService.RemoveBookByName(book.Header);
                bookService.CheckBooks();
                return Content(result);
            }
            return Content("You cannot remove book.");
        }
    }
}
