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
    [Route("api/CodeCoding")]
    [ApiController]
    public class CodeCodingController : ControllerBase
    {
        private readonly ICodeCodingRepository _codeRepo;
        public CodeCodingController(ICodeCodingRepository codeRepo)
        {
            this._codeRepo = codeRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateControlAcc([FromBody] CodeCodingMainVM codeCoding)
        {

            var result = await this._codeRepo.SaveProduct(codeCoding);
            return Ok(result);
        }

        [HttpGet("GetAllCodeCodings/{CompanyId}")]
        public async Task<IActionResult> GetAllCodeCodings(int CompanyId)
        {
            var result = await this._codeRepo.GetAllProducts(CompanyId);
            return Ok(result);
        }

        [HttpGet("GetCodeCodingById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetCodeCodingById(int id, int CompanyId)
        {

            var result = await this._codeRepo.GetProductByID(id, CompanyId);

            return Ok(result);
        }

        [HttpDelete("DeleteCodeCoding/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteCodeCoding(int Id, int CompanyId)
        {
            var result = await this._codeRepo.DeleteProduct(Id, CompanyId);
            return Ok(result);
        }

        [HttpGet("GetCodeCodinglookUps/{CompanyId}")]
        public async Task<IActionResult> GetLookUpsforCodeCoding(int CompanyId)
        {
            var result = await this._codeRepo.GetLookUpsforProduct(CompanyId);
            return Ok(result);
        }

    }
}
