using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

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
        public JsonResult AllProfiles(int page = 1)
        {
            return profileService.GetAllProfilesInfo(page);
        }
    }
}
