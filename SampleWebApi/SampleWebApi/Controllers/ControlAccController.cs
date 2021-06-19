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
    [Route("api/ControlAcc")]
    [ApiController]
    public class ControlAccController : ControllerBase
    {
        private readonly IControlAccRepository _controlRepo;
        
        public ControlAccController(IControlAccRepository controlRepo)
        {
            this._controlRepo = controlRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateControlAcc([FromBody] adControlAccountsVM controlAcc)
        {
            
            var result = await this._controlRepo.SaveControlAcc(controlAcc);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateControlAcc(adControlAccountsVM controlAcc)
        {
            
            var result = await this._controlRepo.SaveControlAcc(controlAcc);
            return Ok(result);
        }

        [HttpGet("GetAllControlAcc/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllControlAcc(int CompanyId, int BranchId)
        {
            var result = await this._controlRepo.GetAllControlAcc(CompanyId, BranchId);
            return Ok(result);
        }
        [HttpGet("GetControlAccById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetControlAccByID(int id, int CompanyId, int BranchId)
        {
        
            var result = await this._controlRepo.GetControllAccByID(id, CompanyId, BranchId);
            
            return Ok(result);
        }
        [HttpDelete("DeleteControlAcc/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> DeleteControlAcc(int Id, int CompanyId, int BranchId)
        {
            var result = await this._controlRepo.DeleteControlAcc(Id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetControlAcclookUps/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetLookUpsforControlAcc(int CompanyId, int BranchId)
        {
            var result = await this._controlRepo.GetLookUpsforCtrlAcc(CompanyId, BranchId);
            return Ok(result);
        }
    }
}
