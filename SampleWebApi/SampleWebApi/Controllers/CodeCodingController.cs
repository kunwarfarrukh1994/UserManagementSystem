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

        [HttpGet("GetAllCodeCodings")]
        public async Task<IActionResult> GetAllCodeCodings()
        {
            var result = await this._codeRepo.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("GetCodeCodingById/{id?}")]
        public async Task<IActionResult> GetCodeCodingById(int id)
        {

            var result = await this._codeRepo.GetProductByID(id);

            return Ok(result);
        }

        [HttpDelete("DeleteCodeCoding/{id?}")]
        public async Task<IActionResult> DeleteCodeCoding(int Id)
        {
            var result = await this._codeRepo.DeleteProduct(Id);
            return Ok(result);
        }

        [HttpGet("GetCodeCodinglookUps")]
        public async Task<IActionResult> GetLookUpsforCodeCoding()
        {
            var result = await this._codeRepo.GetLookUpsforProduct();
            return Ok(result);
        }

    }
}
