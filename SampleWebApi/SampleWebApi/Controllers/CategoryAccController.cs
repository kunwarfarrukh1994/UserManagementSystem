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
    [Route("api/CategoryAcc")]
    [ApiController]
    public class CategoryAccController : ControllerBase
    {
        private readonly ICategoryAccRepository _categoryRepo;
        public CategoryAccController(ICategoryAccRepository categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCategoryAcc([FromBody] adCategoryAccountsVM category) 
        {
            var result = await this._categoryRepo.SaveCategoryAcc(category);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategoryAcc(adCategoryAccountsVM category)
        {
            var result = await this._categoryRepo.SaveCategoryAcc(category);
            return Ok(result);
        }

        [HttpGet("GetAllCategoriesAcc/{CompanyId}")]
        public async Task<IActionResult> GetAllCategoriesAcc(int CompanyId)
        {
            var result = await this._categoryRepo.GetAllCategoriesAcc(CompanyId);
            return Ok(result);
        }

        [HttpGet("GetCategoryAccById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetCategoryAccByID(int id, int CompanyId)
        {
            var result = await this._categoryRepo.GetCategoryAccByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("DeleteCategoryAcc/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteCategoryAcc(int Id, int CompanyId)
        {
            var result = await this._categoryRepo.DeleteCategoryAcc(Id, CompanyId);
            return Ok(result);
        }

        [HttpGet("GetCategoryAcclookUps/{CompanyId}")]
        public async Task<IActionResult> GetLookUpsforCategoryAcc(int CompanyId)
        {
            var result = await this._categoryRepo.GetLookUpsforCategory(CompanyId);
            return Ok(result);
        }
    }
}
