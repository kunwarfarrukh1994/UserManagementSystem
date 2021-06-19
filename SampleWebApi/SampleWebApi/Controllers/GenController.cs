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
    [Route("api/Gen")]
    [ApiController]
    public class GenController : ControllerBase
    {
        private readonly IGenRepository _genRepo;
        public GenController(IGenRepository genRepo)
        {
            this._genRepo = genRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateGen([FromBody] GenMainVM gen)
        {
            var result = await this._genRepo.SaveGen(gen);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGen(GenMainVM gen)
        {
            var result = await this._genRepo.SaveGen(gen);
            return Ok(result);
        }

        [HttpGet("GetAllGens/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllGen(int CompanyId, int BranchId)
        {
            var result = await this._genRepo.GetAllGen(CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetGenById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetGenByID(int id, int CompanyId, int BranchId)
        {
            var result = await this._genRepo.GetGenByID(id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> DeleteGen(int Id, int CompanyId, int BranchId)
        {
            var result = await this._genRepo.DeleteGen(Id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetGenlookUps/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetLookUpsforGen(int CompanyId, int BranchId)
        {
            var result = await this._genRepo.GetLookUpsforGen(CompanyId, BranchId);
            return Ok(result);
        }
    }
}
