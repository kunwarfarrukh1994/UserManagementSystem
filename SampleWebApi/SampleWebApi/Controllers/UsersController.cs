using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly IEmailService _emailservice;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            RoleManager<IdentityRole> roleManager, 
            IConfiguration configuration,
            IEmailService emailservice
            )
        {
            this._userManager = userManager;
            this._signInManger = signinManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
            this._emailservice = emailservice;
        }
        [HttpPost("login")]
        [Route("login")]

        //  [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserSignInModel usermodel)
        {

            var user= await this._userManager.FindByNameAsync(usermodel.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, usermodel.Password))
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
                    User=user,
                    UserRoles= userRoles,
                });
            }

            return BadRequest("try again ");
        }

        [HttpPost("register")]
        [Route("register")]

        // [HttpPost]

        public async Task<IActionResult> Register(ApplicationUser user)
        {
            //var TempPassword = RandomPasswordGenerator.GenerateRandomPassword();
            var TempPassword = "P@ssword123";
                var result = await this._userManager.CreateAsync(user, TempPassword); // no password 
             // var result = await this._userManger.CreateAsync(user,"Password"); // With password 

            if (result.Succeeded)
                {

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink =Url.Action("VerifyEmail", "api/users", new { token=token, email = user.Email }, Request.Scheme);


                // var message = new string[] { user.Email }, "Confirmation email link", confirmationLink, null;

                //var message = confirmationLink + "\n\n" + "Password :" + TempPassword;
                //await this._emailservice.SendAsync(user.Email,"Confirmation-Email", message, true);
                await _userManager.AddToRoleAsync(user,UserRoles.User);
                return Ok("Email Sent Successfully ..Check Your Email to Verify ...");
                }
                else
                {
                var err = new HttpResponseExceptionModel();
                err.ErrorMessages.Add(result.Errors.Select(op => op.Description).First<string>());
                   return BadRequest(JsonConvert.SerializeObject(err));
                }
         }



        public async Task<IActionResult> VerifyEmail()
        {

            return Ok("");
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
