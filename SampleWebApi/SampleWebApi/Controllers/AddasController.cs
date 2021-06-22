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
    [Route("api/Adda")]
    [ApiController]
    public class AddasController : ControllerBase
    {
        private readonly IAddaRepository _addaRepo;
        public AddasController(IAddaRepository addaRepo)
        {
            this._addaRepo = addaRepo;

        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAdda([FromBody] AddaVM adda)
        {
            var result = await this._addaRepo.SaveAdda(adda);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAdda(AddaVM adda)
        {
            var result = await this._addaRepo.SaveAdda(adda);
            return Ok(result);
        }

        [HttpGet("GetAllAddas/{CompanyId}")]
        public async Task<IActionResult> GetAllAddas(int CompanyId)
        {
            var result = await this._addaRepo.GetAllAdda(CompanyId);
            return Ok(result);
        }

        [HttpGet("GetAddaById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetAddaByID(int id, int CompanyId)
        {
            var result = await this._addaRepo.GetAddaByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteAdda(int Id, int CompanyId)
        {
            var result = await this._addaRepo.DeleteAdda(Id, CompanyId);
            return Ok(result);
        }
    }
}
