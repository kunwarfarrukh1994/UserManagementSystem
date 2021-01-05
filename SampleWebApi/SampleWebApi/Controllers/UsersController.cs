using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.UserModels;

namespace SampleWebApi.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UsersController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManger;

        public UsersController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signinManager )
        {
            this._userManger = userManager;
            this._signInManger = signinManager;
        }
        [HttpPost("login")]
        [Route("login")]

        //  [HttpPost]
        public IActionResult Login([FromBody]dynamic obj)
        {
            return Ok("");
        }

        [HttpPost("register")]
        [Route("register")]

        // [HttpPost]

        public IActionResult Register(ApplicationUser user)
        {

            this._userManger.CreateAsync(user);
            return Ok(""); 
        }

    }
}
