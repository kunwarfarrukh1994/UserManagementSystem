using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagement;
using UserManagement.UserModels;
using UserManagement.ViewModels;

namespace SampleWebApi.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UsersController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config
            )
        {
            this._userManager = userManager;
            this._signInManger = signinManager;
            this._roleManager = roleManager;
            this._configuration = config;
        }
        [HttpPost("login")]

        //  [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserSignInModel usermodel)
        {

            var user = await this._userManager.FindByNameAsync(usermodel.UserName);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, usermodel.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        User = user,
                        UserRoles = userRoles,
                    });
                }
                else
                {
                    var err = new HttpResponseExceptionModel();
                    err.ErrorMessages.Add("Incorrect Password");
                    return BadRequest(JsonConvert.SerializeObject(err));

                }
            }
            else
            {
                var err = new HttpResponseExceptionModel();
                err.ErrorMessages.Add("UserName or Email Not exists.. Try Registering Again...");
                return BadRequest(JsonConvert.SerializeObject(err));
            }
        }

        [HttpPost("forgotpassword")]

        public async Task<IActionResult> ForgotPassword([FromQuery] string email)
        {
            var user =  await this._userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var TempPassword = RandomPasswordGenerator.GenerateRandomPassword();
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ResetPassword", "Users", new { token = token, email = user.Email }, Request.Scheme);

                var message = confirmationLink+ "Password :" + TempPassword;
                MailMessage mailMessage = new MailMessage("farrukhraj20@gmail.com", "farrukhraj20@gmail.com");
                mailMessage.Subject = "ResetPassword Link";
                mailMessage.Body = message;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "farrukhraj20@gmail.com",
                    Password = "Farrukh@200"
                };
                client.EnableSsl = true;
                await client.SendMailAsync(mailMessage);

                return Ok("Check Your Emial For Password and then reset it ..");

            }
            else
            {
                var err = new HttpResponseExceptionModel();
                err.ErrorMessages.Add("Invalid Email Address");
                return BadRequest(JsonConvert.SerializeObject(err));
            }


        }

        [HttpPost("resetpassword")]
        public async  Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            if (model.token != null)
            {
                var user = await this._userManager.FindByEmailAsync(model.Email);
               if (user != null)
                {
                    var result = await this._userManager.ResetPasswordAsync(user, model.token, model.Password);
                    if (result.Succeeded)
                    {
                        return Ok("Password Reset Successfully");
                    }
                    else
                    {
                        var err = new HttpResponseExceptionModel();
                        err.ErrorMessages.Add("Something Went Wrong please try again later ");
                        return BadRequest(JsonConvert.SerializeObject(err));
                    }
                }
                else {
                    var err = new HttpResponseExceptionModel();
                    err.ErrorMessages.Add("invalid link ");
                    return BadRequest(JsonConvert.SerializeObject(err));
                }

            }
            else
            {
                var err = new HttpResponseExceptionModel();
                err.ErrorMessages.Add("provide token ");
                return BadRequest(JsonConvert.SerializeObject(err));
            }

        }


        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {

            var user = await this._userManager.FindByIdAsync(model.UserId);

            if(user!=null)
            {
               var result= await this._userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    return Ok("Password Changed Successfully");
                }
                else
                {
                    var err = new HttpResponseExceptionModel();
                    err.ErrorMessages.Add(result.Errors.Select(op => op.Description).First<string>());
                    return BadRequest(JsonConvert.SerializeObject(err));
                }

            }
            var errr = new HttpResponseExceptionModel();
            errr.ErrorMessages.Add("Something Went Wrong Please try again later ...");
            return BadRequest(JsonConvert.SerializeObject(errr));

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(ApplicationUser user)
        {
            var TempPassword = RandomPasswordGenerator.GenerateRandomPassword();
           // var TempPassword = "P@ssword123";
            var result = await this._userManager.CreateAsync(user, TempPassword); // no password 
                                                                                  // var result = await this._userManger.CreateAsync(user,"Password"); // With password 

            if (result.Succeeded)
            {

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("VerifyEmail", "Users", new { token = token, userid = user.Id }, Request.Scheme);


                var message = confirmationLink + "\n\n" + "Password :" + TempPassword;
                MailMessage mailMessage = new MailMessage("farrukhraj20@gmail.com", "farrukhraj20@gmail.com");
                mailMessage.Subject = "Registration Link";
                mailMessage.Body = message;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "farrukhraj20@gmail.com",
                    Password = "Farrukh@200"
                };
                client.EnableSsl = true;
                await client.SendMailAsync(mailMessage);


                await _userManager.AddToRoleAsync(user, UserRoles.User);
                return Ok("Email Sent Successfully ..Check Your Email to Verify ...");
            }
            else
            {
                var err = new HttpResponseExceptionModel();
                err.ErrorMessages.Add(result.Errors.Select(op => op.Description).First<string>());
                return BadRequest(JsonConvert.SerializeObject(err));
            }
        }



        [HttpGet("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string userid, [FromQuery] string token)
        {
            if (userid == null || token == null)
            {
                return BadRequest("Invalid Request");
            }
            var user = await this._userManager.FindByIdAsync(userid);

            if (user != null)
            {
                var result = await this._userManager.ConfirmEmailAsync(user,token);
                if (result.Succeeded)
                {
                    return Ok("Emial Vrified Successfully login now ");
                }
            }
            var err = new HttpResponseExceptionModel();
            err.ErrorMessages.Add("User Email is invalid");
            return BadRequest(JsonConvert.SerializeObject(err));
           // return BadRequest("User Email is invalid");
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

        [HttpGet("logout")]        
        public async Task<IActionResult> Logout()
        {
            await this._signInManger.SignOutAsync();
            return Ok("Logout Successfully");
        }

    }
}
