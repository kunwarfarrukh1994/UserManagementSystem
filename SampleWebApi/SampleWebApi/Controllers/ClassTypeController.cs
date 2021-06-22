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

        [HttpGet("GetAllClassTypes/{CompanyId}")]
        public async Task<IActionResult> GetAllClassTypes(int CompanyId)
        {
            var result = await this._classTypeRepo.GetAllClassTypes(CompanyId);
            return Ok(result);
        }

        [HttpGet("GetClassTypeById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetClassTypeById(int id, int CompanyId)
        {
            var result = await this._classTypeRepo.GetClassTypeByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteClassType(int Id, int CompanyId)
        {
            var result = await this._classTypeRepo.DeleteClassType(Id, CompanyId);
            return Ok(result);
        }

    }
}
