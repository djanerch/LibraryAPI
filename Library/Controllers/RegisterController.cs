﻿using Library.Api.Models;
using Library.Api.Services.Contracts;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IRegisterService service;

        public RegisterController(IRegisterService service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            return Content(service.Register(registerModel));
        }
    }
}
