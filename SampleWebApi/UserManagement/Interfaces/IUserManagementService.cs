using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.DTOs;
using UserManagement.UserModels;
using UserManagement.ViewModels;

namespace UserManagement.Interfaces
{
    public interface IUserManagementService
    {
        #region Core Functionality of ApplicationUser   Register,Login,ForgotPassword,ResetPassword,ChangePassword,VerifyEmail,GetAllUsers,DeleteUser

        Task<string> Register(ApplicationUser user);

        Task<UserWithRolesAndClaimsDto> Login(UserSignInModel usermodel);
        Task<string> ForgotPassword(string email);

        Task<string> ResetPassword(ResetPasswordViewModel model);

        Task<string> ChangePassword(ChangePasswordViewModel model);

        Task<string> VerifyEmail(string userid, string token);
        IList<ApplicationUser> GetAllUsers();
        void DeleteUser(Guid id);
        void DeleteUsers(List<string> UserIDs);
        #endregion
        #region CRUD User-Roles And CRUD User-Claims
        Task<string> CreateRole(string role);
        Task<string> AddClaimsToRole(AddClaimsToRoleDto RoleWithClaims);
        Task AssignRolesToUser(AssignRolesToUserDto userWithRoles);
        Task<string> AssignClaimsToUser(AssignClaimsToUserDto userWithClaims);
        Task<IList<UserWithRolesAndClaimsDto>> GetUsersWithRolesAndClaims();
        Task<UserWithRolesAndClaimsDto> GetUserWithRolesANDClaims(string UserID);
        object[] GetAllClaims();
        Task UpdateUserRoles(AssignRolesToUserDto userWithRoles);
        Task UpdateUserClaims(AssignClaimsToUserDto userWithClaims);
        IList<IdentityRole> GetAllRoles();
        #endregion
    }
}
