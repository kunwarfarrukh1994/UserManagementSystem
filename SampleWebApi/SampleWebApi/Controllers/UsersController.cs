using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleWebApi.ResourcesOperations;
using System;
using System.Threading.Tasks;
using UserManagement.Interfaces;
using UserManagement.UserModels;
using UserManagement.ViewModels;

namespace SampleWebApi.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IAuthorizationService _authSevice;
        private readonly IUserManagementService _userManagerSevice;
        public UsersController(

            IAuthorizationService authservice,
            IUserManagementService userservice
            )
        {
            this._authSevice = authservice;
            this._userManagerSevice = userservice;

        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(ApplicationUser user)
        {
            var result = await this._userManagerSevice.Register(user);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]

        //  [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserSignInModel usermodel)
        {
            var result=await this._userManagerSevice.Login(usermodel);

            return Ok(result);
        }

        //[Authorize(Roles = UserClaimTypes.SuperAdmin)]

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result=await this._authSevice.AuthorizeAsync(User,null,UserOperations.SuperAdmin);
            if (result.Succeeded)
            {
                var users = this._userManagerSevice.GetAllUsers();
                return Ok(users);
            }
            return Forbid();
        }

        [HttpGet("GetUserWithRolesANDClaims/{id?}")]

        public async Task<IActionResult> GetUserWithRolesANDClaims(Guid id)
        {

            var result =await  this._userManagerSevice.GetUserWithRolesANDClaims(id.ToString());
            return Ok(result);
        }

        [HttpGet("GetUsersWithRolesANDClaims")]

        public async Task<IActionResult> GetUsersWithRolesANDClaims()
        {

            var result = await this._userManagerSevice.GetUsersWithRolesAndClaims();
            return Ok(result);
        }


        [HttpGet("GetAllClaims")]
        public IActionResult GetAllClaims()
        {
            var result =this._userManagerSevice.GetAllClaims();
            return Ok(result);
        }
        [HttpPost("forgotpassword")]

        public async Task<IActionResult> ForgotPassword([FromQuery] string email)
        {

            var result = await this._userManagerSevice.ForgotPassword(email);


            return Ok(result);


        }

        [HttpPost("resetpassword")]
        public async  Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            var result = await this._userManagerSevice.ResetPassword(model);
            return Ok(result);
        }


        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {

            var result =await this._userManagerSevice.ChangePassword(model);
            return Ok(result);
        }



        [AllowAnonymous]
        [HttpGet("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string userid, [FromQuery] string token)
        {
            var result = await this._userManagerSevice.VerifyEmail(userid,token);
            return Ok(result);
        }

            [AllowAnonymous]
        [HttpPost("createrole")]
        public  async Task<IActionResult> CreateRole([FromQuery]string role)
        {
            var result = await this._userManagerSevice.CreateRole(role);

            return Ok(result);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {

          //  this._userManagerSevice.DeleteManagers();
            //await this._signInManger.SignOutAsync();


            return Ok("Logout Successfully");
        }

    }
}
