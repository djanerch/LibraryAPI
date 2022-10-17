using Library.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return Ok(service.GetLinks());
        }
    }
}
