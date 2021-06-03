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
    [Route("api/Classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassRepository _classRepo;
        public ClassesController(IClassRepository classRepo)
        {
            this._classRepo = classRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateClass([FromBody] mClassMainVM classes)
        {
            var result = await this._classRepo.SaveClass(classes);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClass(mClassMainVM classes)
        {
            var result = await this._classRepo.SaveClass(classes);
            return Ok(result);
        }

        [HttpGet("GetAllClasses")]
        public async Task<IActionResult> GetAllClasses()
        {
            var result = await this._classRepo.GetAllClasses();
            return Ok(result);
        }


        [HttpGet("GetClassById/{id?}")]
        public async Task<IActionResult> GetClassByID(int id)
        {
            var result = await this._classRepo.GetClassByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteClass(int Id)
        {
            var result = await this._classRepo.DeleteClass(Id);
            return Ok(result);
        }

        [HttpGet("GetClasslookUps")]
        public async Task<IActionResult> GetLookUpsforClass()
        {
            var result = await this._classRepo.GetLookUpsforClass();
            return Ok(result);
        }
    }
}
