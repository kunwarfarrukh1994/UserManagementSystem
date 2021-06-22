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
    [Route("api/Godown")]
    [ApiController]
    public class GodownsController : ControllerBase
    {
        private readonly IGodownRepository _godownRepo;
        public GodownsController(IGodownRepository godownRepo)
        {
            this._godownRepo = godownRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGodown([FromBody] GoDownVM goDown)
        {
            var result = await this._godownRepo.SaveGodowns(goDown);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGodown(GoDownVM goDown)
        {
            var result = await this._godownRepo.SaveGodowns(goDown);
            return Ok(result);
        }

        [HttpGet("GetAllGodowns/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllGodowns(int CompanyId, int BranchId)
        {
            var result = await this._godownRepo.GetAllGodowns(CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetGodownById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetGodownByID(int id, int CompanyId, int BranchId)
        {
            var result = await this._godownRepo.GetGodownByID(id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> DeleteGodown(int Id, int CompanyId, int BranchId)
        {
            var result = await this._godownRepo.DeleteGodown(Id, CompanyId, BranchId);
            return Ok(result);
        }

    }
}
