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
    [Route("api/CodeCodingOptions")]
    [ApiController]
    public class CodeCodingOptionsController : ControllerBase
    {
        private readonly ICodeCodingOptionsRepository _optRepo;

        public CodeCodingOptionsController(ICodeCodingOptionsRepository optRepo)
        {
            this._optRepo = optRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOption([FromBody] CodeCodingOptionsVM opt)
        {
            var result = await this._optRepo.SaveOption(opt);
            return Ok(result);
        }
        [HttpGet("GetAllOptions/{CompanyId}")]
        public async Task<IActionResult> GetAllOptions(int CompanyId)
        {
            var result = await this._optRepo.GetAllOptions(CompanyId);
            return Ok(result);
        }
        [HttpGet("GetOptionById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetOptionByID(int id, int CompanyId)
        {
            var result = await this._optRepo.GetOptionByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteOption(int Id, int CompanyId)
        {
            var result = await this._optRepo.DeleteOption(Id, CompanyId);
            return Ok(result);
        }
    }
}
