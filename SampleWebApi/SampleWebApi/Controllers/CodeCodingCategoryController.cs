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
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await this._cateRepo.GetAllCategories();
            return Ok(result);
        }
        [HttpGet("GetCateById/{id?}")]
        public async Task<IActionResult> GetCateByID(int id)
        {
            var result = await this._cateRepo.GetCategoryByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteCate(int Id)
        {
            var result = await this._cateRepo.DeleteCategory(Id);
            return Ok(result);
        }
    }
}
