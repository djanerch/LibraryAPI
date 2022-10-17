using Library.Api.Models;
using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeBookController : ControllerBase
    {
        private IBookService bookService;
        private IUserService userService;
        public TakeBookController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult TakeBook(BookWithHeader book)
        {
            var user = userService.GetCurrentUser(HttpContext);
            if (userService.GetCurrentUser(HttpContext).Role == "Reader")
            {
                string result = bookService.TakeBookByName(book.Header, user);
                return Content(result);
            }
            return Content("You cannot get this book.");
        }
    }
}
