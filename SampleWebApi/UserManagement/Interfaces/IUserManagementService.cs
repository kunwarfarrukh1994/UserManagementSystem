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
        Task<string> Forgot_Password(string email);

        Task<string> Reset_Password(ResetPasswordViewModel model);

        Task<string> Change_Password(ChangePasswordViewModel model);

        Task<string> Verify_Email(string userid, string token);
        IList<ApplicationUser> Get_All_Users();
        Task<string> Delete_User(Guid id);
        Task<string> Delete_Users(List<string> UserIDs);
        #endregion
        #region CRUD User-Roles And CRUD User-Claims
        Task<string> Create_Role(string role);
        void Add_Claims_To_Role(AddClaimsToRoleDto RoleWithClaims);
        void Assign_Roles_To_User(AssignRolesToUserDto userWithRoles);
        void Assign_Claims_To_User(AssignClaimsToUserDto userWithClaims);
        Task<IList<UserWithRolesAndClaimsDto>> Get_Users_With_Roles_And_Claims();
        Task<UserWithRolesAndClaimsDto> Get_User_With_Roles_And_Claims(string UserID);
        object[] Get_All_Claims();
        void Update_User_Roles(AssignRolesToUserDto userWithRoles);
        void Update_User_Claims(AssignClaimsToUserDto userWithClaims);
        IList<IdentityRole> Get_All_Roles();
        #endregion
    }
}
