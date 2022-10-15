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
    public class MyProfileController : ControllerBase
    {
        private IUserService userService;
        private IProfileService profileService;
        public MyProfileController(IProfileService profileService, IUserService userService)
        {
            this.profileService = profileService;
            this.userService = userService;
        }

        [Authorize]
        [HttpGet]
        public PersonalProfileInfo Profile()
        {
            return profileService.GetProfileInfo(userService.GetCurrentUser(HttpContext));
        }
    }
}
