using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepo;
        public LoginController(ILoginRepository loginRepo)
        {
            this._loginRepo = loginRepo;
        }

        [HttpPost("GetLogin")]
        public async Task<IActionResult> GetLogin([FromBody] LoginVM login)
        {
            var result = await this._loginRepo.GetLogin(login);
            return Ok(result);
        }
    }
}
