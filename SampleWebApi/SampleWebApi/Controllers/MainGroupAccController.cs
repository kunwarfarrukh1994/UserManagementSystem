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
    [Route("api/MainGroupAcc")]
    [ApiController]
    public class MainGroupAccController : ControllerBase
    {
        private readonly IMainGroupAccRepository _groupAccRepo;
        public MainGroupAccController(IMainGroupAccRepository groupAccRepo)
        {
            this._groupAccRepo = groupAccRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGroupAcc([FromBody] adMainGroupAccountsVM groupAcc)
        {
            var result = await this._groupAccRepo.SaveGroupAcc(groupAcc);
            return Ok(result);
        }

        [HttpGet("GetGroupAcclookUps/{CompanyId}")]
        public async Task<IActionResult> GetLookUpsforGroupAcc(int CompanyId)
        {
            var result = await this._groupAccRepo.GetLookUpsforGroupAcc(CompanyId);
            return Ok(result);
        }

        [HttpGet("GetAllGroupAccounts/{CompanyId}")]
        public async Task<IActionResult> GetAllCustomers(int CompanyId)
        {
            var result = await this._groupAccRepo.GetAllGroupAccounts(CompanyId);
            return Ok(result);
        }
        [HttpGet("GetGroupAccById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetGroupAccByID(int id, int CompanyId)
        {
            var result = await this._groupAccRepo.GetGroupAccByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("DeleteGroupAcc/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteGroupAcc(int Id, int CompanyId)
        {
            var result = await this._groupAccRepo.DeleteGroupAcc(Id, CompanyId);
            return Ok(result);
        }


    }
}
