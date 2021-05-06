using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleWebApi.ResourcesOperations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.DTOs;
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

        #region  core functionality 
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(ApplicationUser user)
        {
            var result = await this._userManagerSevice.Register(user);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserSignInModel usermodel)
        {
            var result = await this._userManagerSevice.Login(usermodel);
            return Ok(result);
        }
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromQuery] string email)
        {
            var result = await this._userManagerSevice.Forgot_Password(email);
            return Ok(result);
        }
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            var result = await this._userManagerSevice.Reset_Password(model);
            return Ok(result);
        }
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            var result = await this._userManagerSevice.Change_Password(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string userid, [FromQuery] string token)
        {
            var result = await this._userManagerSevice.Verify_Email(userid, token);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var IsUserAuthorize = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (IsUserAuthorize.Succeeded)
            {
                var users = this._userManagerSevice.Get_All_Users();
                return Ok(users);
            }
            return Forbid();
        }

        [HttpDelete("DeleteUsers")]
        public async Task<IActionResult> DeleteUsers([FromBody] List<string> UserIds)
        {
            var IsUserAuthorize = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (IsUserAuthorize.Succeeded)
            {
                  var result=await this._userManagerSevice.Delete_Users(UserIds);
                  return Ok(result);
            }
            else
            {
                return Forbid("Dont have Access");
            }
        }
        [HttpDelete("DeleteUser/{id?}")]
        public async Task<IActionResult> DeleteUser([FromBody] Guid userID)
        {
            var IsUserAuthorize = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (IsUserAuthorize.Succeeded)
            {
                var result=await this._userManagerSevice.Delete_User(userID);
                return Ok(result);
            }
            else
            {
                return Forbid("Dont have Access");
            }
        }

        #endregion

        #region crud calims and roles 


        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromQuery] string role)
        {
            var result = await this._userManagerSevice.Create_Role(role);

            return Ok(result);
        }

        [HttpPost("AddClaimsToRole")]
        public async Task<IActionResult> AddClaimsToRole([FromBody] AddClaimsToRoleDto RoleWithClaims)
        {
            var IsUserAuthorize = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (IsUserAuthorize.Succeeded)
            {
               this._userManagerSevice.Add_Claims_To_Role(RoleWithClaims);
                return Ok("Deleted Successfully");
            }
            else
            {
                return Forbid("Dont have Access");
            }
        }

        [HttpPost("AssignRolesToUser")]
        public async Task<IActionResult> AssignRolesToUser([FromBody] AssignRolesToUserDto userWithRoles)
        {
            var result = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (result.Succeeded)
            {
                this._userManagerSevice.Assign_Roles_To_User(userWithRoles);
                return Ok("Assigned Successfully");
            }
            else
            {
                return Forbid("Dont have Access");
            }
        }


        public async Task<IActionResult> AssignClaimsToUser([FromBody] AssignClaimsToUserDto userWithClaims)
        {
            var result = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (result.Succeeded)
            {
                this._userManagerSevice.Assign_Claims_To_User(userWithClaims);
                return Ok("Assigned Successfully..");
            }
            else
            {
                return Forbid("Dont have Access");
            }
        }


        [HttpGet("GetUsersWithRolesANDClaims")]
        public async Task<IActionResult> GetUsersWithRolesANDClaims()
        {
            var result = await this._userManagerSevice.Get_Users_With_Roles_And_Claims();
            return Ok(result);
        }

        [HttpGet("GetUserWithRolesANDClaims/{id?}")]
        public async Task<IActionResult> GetUserWithRolesANDClaims(Guid id)
        {
            var result = await this._userManagerSevice.Get_User_With_Roles_And_Claims(id.ToString());
            return Ok(result);
        }

        [HttpGet("GetAllClaims")]
        public IActionResult GetAllClaims()
        {
            var result = this._userManagerSevice.Get_All_Claims();
            return Ok(result);
        }

        [HttpPut("UpdateUserRoles")]
        public async Task<IActionResult> UpdateUserRoles([FromBody]AssignRolesToUserDto userWithRoles)
        {
            var result = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (result.Succeeded)
            {
                 this._userManagerSevice.Update_User_Roles(userWithRoles);
                return Ok("Updated Successfully");
            }
            else
            {
                return Forbid("Dont have Access");
            }
        }

        [HttpPut("UpdateUserClaims")]
        public async Task<IActionResult> UpdateUserClaims([FromBody]AssignClaimsToUserDto userWithClaims)
        {
            var result = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (result.Succeeded)
            {
                this._userManagerSevice.Update_User_Claims(userWithClaims);
                return Ok("Updated Successfully...");
            }
            else
            {
                return Forbid("Dont have Access");
            }
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await this._authSevice.AuthorizeAsync(User, null, UserOperations.SuperAdmin);
            if (result.Succeeded)
            {
                var list = this._userManagerSevice.Get_All_Roles();
                return Ok(list);
            }
            else
            {
                return Forbid("Dont have Access");
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok("Logout Successfully");
        }

    
        #endregion




    }
}
