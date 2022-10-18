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
    public class AddPointsToUserController : ControllerBase
    {
        private IBookService bookService;
        private IUserService userService;
        public AddPointsToUserController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddPointsToUser(UserWithNameAndPoints user)
        {
            if (userService.GetCurrentUser(HttpContext).Role == "Admin")
            {
                return Content(userService.AddPointsToUser(user));
            }
            return Content("You don't have permission to add points.");
        }
    }
}
