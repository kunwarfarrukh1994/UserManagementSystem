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
        [HttpGet("GetAllOptions")]
        public async Task<IActionResult> GetAllOptions()
        {
            var result = await this._optRepo.GetAllOptions();
            return Ok(result);
        }
        [HttpGet("GetOptionById/{id?}")]
        public async Task<IActionResult> GetOptionByID(int id)
        {
            var result = await this._optRepo.GetOptionByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteOption(int Id)
        {
            var result = await this._optRepo.DeleteOption(Id);
            return Ok(result);
        }
    }
}
