using Library.Api.Models;
using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookController : ControllerBase
    {
        private IBookService bookService;
        private IUserService userService;
        public GetBookController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult GetBook(BookWithHeader book)
        {
            var user = userService.GetCurrentUser(HttpContext);
            if (userService.GetCurrentUser(HttpContext).Role == "Reader")
            {
                string result = bookService.GetBookByName(book.Header, user);
                return Content(result);
            }
            return Content("You cannot get this book.");
        }
    }
}
