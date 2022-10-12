using Library.Api.Models;
using Library.Data;
using Library.Data.Models;
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
    public class RegisterController : ControllerBase
    {
        private LibraryDbContext context;

        public RegisterController(LibraryDbContext context)
        {
            this.context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            if (context.Users.FirstOrDefault(x => x.Name == registerModel.Username) != null)
            {
                return Content("Invalid data!Try again...");
            }
            else if (context.Users.FirstOrDefault(x => x.Email == registerModel.Email) != null)
            {
                return Content("Invalid data!Try again...");
            }
            else if (registerModel.Password.Length <= 4)
            {
                return Content("Invalid data!Try again...");
            }

            var user = new User()
            {
                Name = registerModel.Username,
                Email = registerModel.Email,
                Password = Hash.sha256(registerModel.Password)
            };

            context.Users.Add(user);

            context.SaveChanges();

            return Ok($"Hi {registerModel.Username}! You succesfully created account.");
        }
    }
}
