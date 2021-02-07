﻿using Microsoft.AspNetCore.Identity;
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
using System.Web;
using UserManagement.DBContext;

namespace UserManagement.Services
{
   public class UserManagementService :IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly UsersDBContext _dbcontext;

        public UserManagementService(
            UsersDBContext dbcontext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config)
        {
            this._userManager = userManager;
            this._signInManger = signinManager;
            this._roleManager = roleManager;
            this._configuration = config;
            this._dbcontext = dbcontext;
        }

        #region Core Application user Implementation

        public async Task<string> Register(ApplicationUser user)
        {

            using (var transaction = this._dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var TempPassword = GenerateRandomPassword();
                    // var TempPassword = "P@ssword123";
                    var result = await this._userManager.CreateAsync(user, TempPassword); // no password 
                                                                                          // var result = await this._userManger.CreateAsync(user,"Password"); // With password 

                    if (result.Succeeded)
                    {

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);


                        var token = HttpUtility.UrlEncode(code);
                        //var confirmationLink = Url.Action("VerifyEmail", "Users", new { token = token, userid = user.Id }, Request.Scheme);
                        var confirmationLink = this._configuration["App:ClientRootAddress"] + "/VerifyEmail?token=" + token + "&userid=" + user.Id;


                        var message = confirmationLink + "\n\n" + "Password :" + TempPassword;
                        MailMessage mailMessage = new MailMessage(this._configuration["Email:From"], user.Email);
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


                        await _userManager.AddToRoleAsync(user, UserRoles.SuperAdmin);

                        Claim c = new Claim(UserClaimTypes.SuperAdmin, UserClaimTypes.SuperAdmin);
                        await _userManager.AddClaimAsync(user, c);

                        await transaction.CommitAsync();

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
                catch (Exception ex)
                {
                    await this._dbcontext.Database.RollbackTransactionAsync();
                    throw ex;
                }

            }


        }
        public async Task<UserWithRolesAndClaimsDto> Login(UserSignInModel usermodel)
        {
            var user = await this._userManager.FindByNameAsync(usermodel.UserName);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, usermodel.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var userClaims = await _userManager.GetClaimsAsync(user);

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var claim in userClaims)
                    {
                        authClaims.Add(new Claim(claim.Type, claim.Value));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    return new UserWithRolesAndClaimsDto
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        User = user,
                        UserRoles = userRoles,
                        UserClaims = userClaims
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
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);


                var token = HttpUtility.UrlEncode(code);

                //var confirmationLink = Url.Action("ResetPassword", "Users", new { token = token, email = user.Email }, Request.Scheme);
                var confirmationLink = this._configuration["App:ClientRootAddress"] + "/ResetPassword?token=" + token + "&email=" + user.Email;

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
        public IList<ApplicationUser> GetAllUsers()
        {
            return this._userManager.Users.ToList();
        }

        public async void DeleteUser(Guid UserID)
        {
            var user = await this._userManager.FindByIdAsync(UserID.ToString());
            if (user != null)
            {
                var result = await this._userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    throw new Exception("Something Went Wrong..");
                }
            }
        }

        public void DeleteUsers(List<string> UserIDs)
        {
            foreach (var id in UserIDs)
            {
                this.DeleteUser(new Guid(id));
            }
        }



        #endregion
        #region implementation CRUD User-Roles And CRUD User-Claims
        public async Task<string> CreateRole(string role)
        {
            IdentityRole Role = new IdentityRole { Name = role };
            var result = await this._roleManager.CreateAsync(Role);

            if (result.Succeeded)
            {
                return "Role Created Successfully";
            }
            throw new Exception("Something Went Wrong.. Try Again Later");

        }
        public async Task<string> AddClaimsToRole(AddClaimsToRoleDto RoleWithClaims)
        {
            var role = await this._roleManager.FindByIdAsync(RoleWithClaims.RoleID.ToString());
            if (role != null)
            {
                foreach (var claim in RoleWithClaims.ClaimTypes)
                {

                    // if(claim)
                    // this._roleManager.AddClaimAsync(role,);
                }
            }
            throw new Exception("");

        }
        public async Task AssignRolesToUser(AssignRolesToUserDto userWithRoles)
        {
            var user = await this._userManager.FindByIdAsync(userWithRoles.UserID.ToString());

            if (user != null)
            {
                foreach (var role in userWithRoles.Roles)
                {
                    if (!(await this._userManager.IsInRoleAsync(user, role))) // already added to the role
                    {
                        await this._userManager.AddToRoleAsync(user, role);
                    }
                }

            }
            else
            {
                throw new Exception("Sothing went wrong ...");
            }


        }
        public async Task<string> AssignClaimsToUser(AssignClaimsToUserDto userWithClaims)
        {
            Claim claim = new Claim(UserClaimTypes.SuperAdmin, "true");
            var user = await this._userManager.FindByIdAsync(userWithClaims.UserID.ToString());

            if (user != null)
            {
                var result = await this._userManager.AddClaimsAsync(user, userWithClaims.Claims);

                if (result.Succeeded)
                {
                    return "Claims Assigned Successfully...";
                }

                throw new Exception("Something Went Wrong");
                //foreach (var claim in userWithClaims.ClaimTypes)
                //{


                //    // if(claim)
                //    this._userManager.AddClaimAsync(role);
                //}
            }

            throw new Exception("Something Went Wrong");
        }
        public async Task<IList<UserWithRolesAndClaimsDto>> GetUsersWithRolesAndClaims()
        {


            List<UserWithRolesAndClaimsDto> userdata = new List<UserWithRolesAndClaimsDto>();

            var AllUsers = this._userManager.Users.ToList();

            foreach (var user in AllUsers)
            {
                if (user != null)
                {
                    var claims = await this._userManager.GetClaimsAsync(user);
                    var roles = await this._userManager.GetRolesAsync(user);

                    userdata.Add(
                     new UserWithRolesAndClaimsDto
                     {
                         User = user,
                         UserRoles = roles,
                         UserClaims = claims
                     });

                }
            }
            return userdata;


        }
        public async Task<UserWithRolesAndClaimsDto> GetUserWithRolesANDClaims(string UserID)
        {
            var user = await this._userManager.FindByIdAsync(UserID);

            if (user != null)
            {
                var claims = await this._userManager.GetClaimsAsync(user);
                var roles = await this._userManager.GetRolesAsync(user);
                return new UserWithRolesAndClaimsDto
                {
                    //  Token = new JwtSecurityTokenHandler().WriteToken(token),
                    // expiration = token.ValidTo,
                    User = user,
                    UserRoles = roles,
                    UserClaims = claims
                };
            }
            throw new Exception("Something Went Wrong");
        }
        public object[] GetAllClaims()
        {
            UserClaimTypes c = new UserClaimTypes();

            var fieldValues = c.GetType()
                     .GetFields()
                     .Select(field => field.GetValue(c))
                     .ToArray();

            return fieldValues;
            //var properties = TypeDescriptor.GetProperties(c.GetType());
            //var list = new ArrayList();
            //foreach (PropertyDescriptor property in properties)
            //{
            //    var value = property.GetValue(c);
            //    list.Add(value);
            //}

            //return list;
            //UserClaimTypes
        }
        public async Task UpdateUserRoles(AssignRolesToUserDto userWithRoles)
        {
            using (var transaction = this._dbcontext.Database.BeginTransaction())
            {
                var user = await this._userManager.FindByIdAsync(userWithRoles.UserID.ToString());
                if (user != null)
                {
                    // delete existing 
                    var existingroles = await this._userManager.GetRolesAsync(user);
                    var result = await this._userManager.RemoveFromRolesAsync(user, existingroles);
                    if (result.Succeeded)
                    {
                        //add new roles 
                        await this.AssignRolesToUser(userWithRoles);
                        await transaction.CommitAsync();
                    }
                    else
                    {
                        await this._dbcontext.Database.RollbackTransactionAsync();
                    }
                }
                else
                {
                    throw new Exception("Sothing went wrong ...");
                }
            }



        }
        public async Task UpdateUserClaims(AssignClaimsToUserDto userWithClaims)
        {
            using (var transaction = this._dbcontext.Database.BeginTransaction())
            {
                var user = await this._userManager.FindByIdAsync(userWithClaims.UserID.ToString());
                if (user != null)
                {
                    // delete existing 
                    var existingclaims = await this._userManager.GetClaimsAsync(user);
                    var result = await this._userManager.RemoveClaimsAsync(user, existingclaims);
                    if (result.Succeeded)
                    {
                        //add new claims 
                        await this.AssignClaimsToUser(userWithClaims);
                        await transaction.CommitAsync();
                    }
                    else
                    {

                        await this._dbcontext.Database.RollbackTransactionAsync();
                    }
                }
                else
                {
                    throw new Exception("Sothing went wrong ...");
                }
            }
        }
        public IList<IdentityRole> GetAllRoles()
        {
            return this._roleManager.Roles.ToList();
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
        #endregion
    }
}
