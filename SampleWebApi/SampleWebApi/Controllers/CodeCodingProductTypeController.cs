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
    [Route("api/CodeCodingProductType")]
    [ApiController]
    public class CodeCodingProductTypeController : ControllerBase
    {
        private readonly ICodeCodingProductTypeRepository _pTypeRepo;
        public CodeCodingProductTypeController(ICodeCodingProductTypeRepository pTypeRepo)
        {
            this._pTypeRepo = pTypeRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePType([FromBody] CodeCodingProductTypeVM pType)
        {
            var result = await this._pTypeRepo.SaveProductType(pType);
            return Ok(result);
        }
        [HttpGet("GetAllPTypes/{CompanyId}")]
        public async Task<IActionResult> GetAllPTypes(int CompanyId)
        {
            var result = await this._pTypeRepo.GetAllProductTypes(CompanyId);
            return Ok(result);
        }
        [HttpGet("GetPTypeById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetPTypeByID(int id, int CompanyId)
        {
            var result = await this._pTypeRepo.GetProductTypeByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}")]
        public async Task<IActionResult> DeletePType(int Id, int CompanyId)
        {
            var result = await this._pTypeRepo.DeleteProductType(Id, CompanyId);
            return Ok(result);
        }
    }
}
