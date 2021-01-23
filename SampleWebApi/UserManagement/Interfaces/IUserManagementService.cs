using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.DTOs;
using UserManagement.UserModels;
using UserManagement.ViewModels;

namespace UserManagement.Interfaces
{
    public interface IUserManagementService
    {
        Task<string> Register(ApplicationUser user);
        Task<IList<UserWithRolesAndClaimsDto>> GetUsersWithRolesAndClaims();
        Task<UserWithRolesAndClaimsDto> Login(UserSignInModel usermodel);
        Task<string> ForgotPassword(string email);

        Task<string> ResetPassword(ResetPasswordViewModel model);

        Task<string> ChangePassword(ChangePasswordViewModel model);

        Task<string> VerifyEmail(string userid, string token);

        Task<string> CreateRole(string role);

        Task<string> AddClaimsToRole(AddClaimsToRoleDto RoleWithClaims);
        Task<UserWithRolesAndClaimsDto> GetUserWithRolesANDClaims(string UserID);

        IList<ApplicationUser> GetAllUsers();
        Task<string> AssignClaimsToUser(AssignClaimsToUserDto userWithClaims);
        Task AssignRoles(AssignRolesToUserDto userWithRoles);

        object[] GetAllClaims();

      //  Task<string> DeleteManagers(HttpContext context);

    }
}
