using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController1 : ControllerBase
    {
        public IActionResult Login(string userName, string password)
        {
            return Ok();
        }

        public IActionResult Register()
        {
            return Ok(); 
        }

    }
}
