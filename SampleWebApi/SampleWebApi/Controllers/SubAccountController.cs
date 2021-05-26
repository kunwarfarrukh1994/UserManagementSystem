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
        [HttpPost("create")]
        public async Task<IActionResult> CreateSubAccount([FromBody] adAccountsVM subAcc)
        {
            var result = await this._subAccRepo.SaveSubAcc(subAcc);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateSubAccount(adAccountsVM subAcc)
        {
            var result = await this._subAccRepo.UpdateSubAcc(subAcc);
            return Ok(result);
        }

        [HttpGet("GetAllSubAccounts")]
        public async Task<IActionResult> GetAllSubAccounts()
        {
            var result = await this._subAccRepo.GetAllSubAccounts();
            return Ok(result);
        }

        [HttpGet("GetSubAccountById/{id?}")]
        public async Task<IActionResult> GetSchoolByID(int id)
        {
            var result = await this._subAccRepo.GetSubAccountByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteSubAccount(int Id)
        {
            var result = await this._subAccRepo.DeleteSubAccount(Id);
            return Ok(result);
        }


        [HttpGet("GetSubAccountlookUps")]
        public async Task<IActionResult> GetLookUpsforSubAccount()
        {
            var result = await this._subAccRepo.GetLookUpsforSubAccount();
            return Ok(result);
        }

    }
}
