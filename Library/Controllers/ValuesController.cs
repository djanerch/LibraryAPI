using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private IUserService userService;
        public ValuesController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("Admins")]
        [Authorize]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = userService.GetCurrentUser(HttpContext);

            return Ok($"Hi {currentUser.Username}, you are in private property!");
        }

        [HttpGet("Public")]
        public IActionResult PublicEnpoint()
        {
            return Ok("Hi, you are on public property!");
        }
    }
}