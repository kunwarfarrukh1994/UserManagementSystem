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
    [Route("api/SubAccounts")]
    [ApiController]
    public class SubAccountController : ControllerBase
    {
        private readonly ISubAccountsRepository _subAccRepo;
        public SubAccountController(ISubAccountsRepository subAccRepo)
        {
            this._subAccRepo = subAccRepo;

        }
        [HttpGet("GetSubAccountlookUps")]
        public async Task<IActionResult> GetLookUpsforSale()
        {
            var result = await this._subAccRepo.GetLookUpsforSubAccount();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSales([FromBody] adAccountsVM subAcc)
        {
            var result = await this._subAccRepo.SaveSubAcc(subAcc);
            return Ok(result);
        }
    }
}
