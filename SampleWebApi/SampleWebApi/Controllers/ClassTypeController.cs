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
    [Route("api/ClassType")]
    [ApiController]
    public class ClassTypeController : ControllerBase
    {
        private readonly IClassTypeRepository _classTypeRepo;
        public ClassTypeController(IClassTypeRepository classTypeRepo)
        {
            this._classTypeRepo = classTypeRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClassType([FromBody] mClassTypeVM classType)
        {
            var result = await this._classTypeRepo.SaveClassType(classType);
            return Ok(result);
        }

        [HttpGet("GetAllClassTypes")]
        public async Task<IActionResult> GetAllClassTypes()
        {
            var result = await this._classTypeRepo.GetAllClassTypes();
            return Ok(result);
        }

        [HttpGet("GetClassTypeById/{id?}")]
        public async Task<IActionResult> GetClassTypeById(int id)
        {
            var result = await this._classTypeRepo.GetClassTypeByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteClassType(int Id)
        {
            var result = await this._classTypeRepo.DeleteClassType(Id);
            return Ok(result);
        }

    }
}
