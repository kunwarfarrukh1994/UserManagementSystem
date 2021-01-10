using System.Threading.Tasks;
using UserManagement.DTOs;
using UserManagement.UserModels;
using UserManagement.ViewModels;

namespace UserManagement.Interfaces
{
    public interface IUserService
    {
        Task<string> Register(ApplicationUser user);
        Task<UserWithRolesDto> Login(UserSignInModel usermodel);
        Task<string> ForgotPassword(string email);

        Task<string> ResetPassword(ResetPasswordViewModel model);

        Task<string> ChangePassword(ChangePasswordViewModel model);

        Task<string> VerifyEmail(string userid, string token);

    }
}
