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

        [HttpGet("GetGroupAcclookUps/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetLookUpsforGroupAcc(int CompanyId, int BranchId)
        {
            var result = await this._groupAccRepo.GetLookUpsforGroupAcc(CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetAllGroupAccounts/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllCustomers(int CompanyId, int BranchId)
        {
            var result = await this._groupAccRepo.GetAllGroupAccounts(CompanyId, BranchId);
            return Ok(result);
        }
        [HttpGet("GetGroupAccById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetGroupAccByID(int id, int CompanyId, int BranchId)
        {
            var result = await this._groupAccRepo.GetGroupAccByID(id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpDelete("DeleteGroupAcc/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> DeleteGroupAcc(int Id, int CompanyId, int BranchId)
        {
            var result = await this._groupAccRepo.DeleteGroupAcc(Id, CompanyId, BranchId);
            return Ok(result);
        }


    }
}
