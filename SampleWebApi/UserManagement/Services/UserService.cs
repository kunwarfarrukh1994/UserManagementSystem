using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DTOs;
using UserManagement.UserModels;
using UserManagement.ViewModels;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Interfaces;
using System.Net.Mail;
using System.Linq;

namespace UserManagement.Services
{
   public class UserService :IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public UserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config)
        {
            this._userManager = userManager;
            this._signInManger = signinManager;
            this._roleManager = roleManager;
            this._configuration = config;
        }


        public async Task<string> Register(ApplicationUser user)
        {
            var TempPassword = GenerateRandomPassword();
            // var TempPassword = "P@ssword123";
            var result = await this._userManager.CreateAsync(user, TempPassword); // no password 
                                                                                  // var result = await this._userManger.CreateAsync(user,"Password"); // With password 

            if (result.Succeeded)
            {

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var confirmationLink = Url.Action("VerifyEmail", "Users", new { token = token, userid = user.Id }, Request.Scheme);
                var confirmationLink = this._configuration["App:ClientRootAddress"] + "/VerifyEmail?token=" + token + "&userid=" + user.Id;


                var message = confirmationLink + "\n\n" + "Password :" + TempPassword;
                MailMessage mailMessage = new MailMessage(this._configuration["Email:From"], this._configuration["Email:To"]);
                mailMessage.Subject = "Registration Link";
                mailMessage.Body = message;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = this._configuration["Email:UserName"],
                    Password = this._configuration["Email:Password"]
                };
                client.EnableSsl = true;
                await client.SendMailAsync(mailMessage);


                await _userManager.AddToRoleAsync(user,"dfsdfsdfs");
                return "Email Sent Successfully ..Check Your Email to Verify ...";
            }
            else
            {
                //var err = new HttpResponseExceptionModel();
                //err.ErrorMessages.Add(result.Errors.Select(op => op.Description).First<string>());
                //return BadRequest(JsonConvert.SerializeObject(err));

                throw new Exception(result.Errors.Select(op => op.Description).First<string>());
            }
        }

        public async Task<UserWithRolesDto> Login(UserSignInModel usermodel)
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

                    return new UserWithRolesDto
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        User = user,
                        UserRoles = userRoles,
                    };
                }
                else
                {
                    throw new Exception("Incorrect Password");
                }
            }
            else
            {
                throw new Exception("Invalid Email");
            }

        }

        public async Task<string> ForgotPassword(string email)
        {
            var user = await this._userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var TempPassword = GenerateRandomPassword();
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var confirmationLink = Url.Action("ResetPassword", "Users", new { token = token, email = user.Email }, Request.Scheme);
                var confirmationLink =this._configuration["App:ClientRootAddress"]+ "/ResetPassword?token="+token+"&email="+user.Email;

                var message = confirmationLink + "Password :" + TempPassword;
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

                return "Check Your Email For Password";

            }
            else
            {
                throw new Exception("Invalid Email Address");
            }
        }


        private static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        public async Task<string> ResetPassword(ResetPasswordViewModel model)
        {
            if (model.token != null)
            {
                var user = await this._userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await this._userManager.ResetPasswordAsync(user, model.token, model.Password);
                    if (result.Succeeded)
                    {
                        return "Password Reset Successfully";
                    }
                    else
                    {
                        //var err = new HttpResponseExceptionModel();
                        //err.ErrorMessages.Add("");
                        //return BadRequest(JsonConvert.SerializeObject(err));

                        throw new Exception("Something Went Wrong please try again later ");
                    }
                }
                else
                {
                   throw new Exception("Something Went Wrong please try again later ");
                }

            }
            else
            {
                throw new Exception("Something Went Wrong please try again later ");
            }
        }

        public async Task<string> ChangePassword(ChangePasswordViewModel model)
        {
            var user = await this._userManager.FindByIdAsync(model.UserId);

            if (user != null)
            {
                var result = await this._userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    return "Password Changed Successfully";
                }
                else
                {
                    throw new Exception(result.Errors.Select(op => op.Description).First<string>());
                }

            }
            else
            {
                throw new Exception("Something Went Wrong");
            }
        }

        public async Task<string> VerifyEmail(string userid, string token)
        {
            if (userid == null || token == null)
            {
                throw new Exception("Invalid Request");
            }
            var user = await this._userManager.FindByIdAsync(userid);

            if (user != null)
            {
                var result = await this._userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return "Emial Vrified Successfully login now ";
                }
            }
            throw new Exception("User Email is invalid");
        }
    }



}
