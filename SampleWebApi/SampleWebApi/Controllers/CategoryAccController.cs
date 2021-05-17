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
    }
}
