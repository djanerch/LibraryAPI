using Library.Api.Services.Contracts;
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
    public class AllProfilesController : ControllerBase
    {
        private IProfileService profileService;
        public AllProfilesController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public JsonResult Get(int page = 1)
        {
            return profileService.GetAllProfilesInfo(page);
        }
    }
}
