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
    [Route("api/RBook")]
    [ApiController]
    public class RBookController : ControllerBase
    {
        private readonly IRBookRepository _rbookRepo;
        public RBookController(IRBookRepository rbookRepo)
        {
            this._rbookRepo = rbookRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRBook([FromBody] RBookMainVM rbook)
        {

            var result = await this._rbookRepo.SaveRBook(rbook);
            return Ok(result);
        }

        [HttpGet("GetAllRBooks/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllCodeCodings(int CompanyId, int BranchId)
        {
            var result = await this._rbookRepo.GetAllRBooks(CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetRBookById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetRBookByID(int id, int CompanyId, int BranchId)
        {

            var result = await this._rbookRepo.GetRBookByID(id, CompanyId, BranchId);

            return Ok(result);
        }

        [HttpDelete("DeleteRBook/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> DeleteRBook(int Id, int CompanyId, int BranchId)
        {
            var result = await this._rbookRepo.DeleteRBook(Id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetRBooklookUps/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetLookUpsforRBook(int CompanyId, int BranchId)
        {
            var result = await this._rbookRepo.GetLookUpsforRBook(CompanyId, BranchId);
            return Ok(result);
        }
    }
}
