using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagement.Interfaces;
using UserManagement.UserModels;
using UserManagement.ViewModels;

namespace SampleWebApi.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IUserService _userSevice;
        public UsersController(
            RoleManager<IdentityRole> roleManager,
            IUserService userservice
            )
        {
            this._roleManager = roleManager;
            this._userSevice = userservice;

        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(ApplicationUser user)
        {
            var result = await this._userSevice.Register(user);
            return Ok(result);
        }   
        [HttpPost("login")]

        //  [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserSignInModel usermodel)
        {
            var result=await this._userSevice.Login(usermodel);

            return Ok(result);
        }

        [HttpPost("forgotpassword")]

        public async Task<IActionResult> ForgotPassword([FromQuery] string email)
        {

            var result = await this._userSevice.ForgotPassword(email);

            return Ok(result);


        }

        [HttpPost("resetpassword")]
        public async  Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            var result = await this._userSevice.ResetPassword(model);
            return Ok(result);
        }


        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {

            var result =await this._userSevice.ChangePassword(model);
            return Ok(result);
        }




        [HttpGet("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string userid, [FromQuery] string token)
        {
            var result = await this._userSevice.VerifyEmail(userid,token);
            return Ok(result);
        }


        [HttpPost("createrole")]
        public  async Task<IActionResult> CreateRole([FromQuery]string role)
        {
            IdentityRole Role=new IdentityRole{Name=role};

            var result =await this._roleManager.CreateAsync(Role);

            if (result.Succeeded)
            {
                return Ok("Role Created Successfully");
            }
            return BadRequest("Something Went Wrong.. Try Again Later");
        }

        //[HttpGet("logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    await this._signInManger.SignOutAsync();
        //    return Ok("Logout Successfully");
        //}

    }
}
