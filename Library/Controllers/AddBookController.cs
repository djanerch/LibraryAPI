using Library.Api.Models;
using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddBookController : ControllerBase
    {
        private IBookService bookService;
        private IUserService userService;
        public AddBookController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBook(BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return Content("Invalid model state");
            }
            else if (userService.GetCurrentUser(HttpContext).Role == "Admin")
            {
                bookService.AddNewBook(book);
                bookService.CheckBooks();
                return Ok("New book succesfully added!");
            }
            return Content("You cannot add book.");
        }
    }
}