using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleWebApi.ActionFilters;
using System.Linq;
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
                var result = this._userManger.CreateAsync(user);
                if (result.Result.Succeeded)
                {
                    return Ok("");
                }
                else
                {
                var err = new HttpResponseExceptionModel();
                err.ErrorMessages.Add(result.Result.Errors.Select(op => op.Description).First<string>());
                   return BadRequest(JsonConvert.SerializeObject(err));
                }
            
            
            
           
            
        }

    }
}
