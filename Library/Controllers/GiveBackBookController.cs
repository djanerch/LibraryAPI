using Library.Api.Models;
using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiveBackBookController : ControllerBase
    {
        private IBookService bookService;
        private IUserService userService;
        public GiveBackBookController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult GiveBackBook(BookWithHeader book)
        {
            var user = userService.GetCurrentUser(HttpContext);
            if (userService.GetCurrentUser(HttpContext).Role == "Reader")
            {
                string result = bookService.GiveBackBookByName(book.Header, user);
                return Content(result);
            }
            return Content("You cannot give back this book.");
        }
    }
}
