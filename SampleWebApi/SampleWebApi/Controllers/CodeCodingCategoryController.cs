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
    [Route("api/CodeCodingCategory")]
    [ApiController]
    public class CodeCodingCategoryController : ControllerBase
    {
        private readonly ICodeCodingCategoryRepository _cateRepo;
        public CodeCodingCategoryController(ICodeCodingCategoryRepository cateRepo)
        {
            this._cateRepo = cateRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCate([FromBody] CodeCodingCategoryVM cate)
        {
            var result = await this._cateRepo.SaveCategory(cate);
            return Ok(result);
        }
        [HttpGet("GetAllCategories/{CompanyId}")]
        public async Task<IActionResult> GetAllCategories(int CompanyId)
        {
            var result = await this._cateRepo.GetAllCategories(CompanyId);
            return Ok(result);
        }
        [HttpGet("GetCateById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetCateByID(int id, int CompanyId)
        {
            var result = await this._cateRepo.GetCategoryByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteCate(int Id, int CompanyId)
        {
            var result = await this._cateRepo.DeleteCategory(Id, CompanyId);
            return Ok(result);
        }
    }
}
