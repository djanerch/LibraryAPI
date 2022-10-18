using Library.Api.Models;
using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin login)
        {
            if (!ModelState.IsValid)
            {
                return Content("Invalid model state");
            }

            IActionResult response = Unauthorized();
            var user = loginService.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = loginService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}