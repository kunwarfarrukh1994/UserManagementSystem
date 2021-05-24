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
    [Route("api/Schools")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolsRepository _schoolsRepo;
        public SchoolsController(ISchoolsRepository schoolsRepo)
        {
            this._schoolsRepo = schoolsRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateSchools([FromBody] SchoolsVM schools)
        {
            var result = await this._schoolsRepo.SaveSchools(schools);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSchool(SchoolsVM schools)
        {
            var result = await this._schoolsRepo.SaveSchools(schools);
            return Ok(result);
        }

        [HttpGet("GetAllSchools")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await this._schoolsRepo.GetAllSchools();
            return Ok(result);
        }


        [HttpGet("GetSchoolById/{id?}")]
        public async Task<IActionResult> GetSchoolByID(int id)
        {
            var result = await this._schoolsRepo.GetSchoolByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteSchool(int Id)
        {
            var result = await this._schoolsRepo.DeleteSchool(Id);
            return Ok(result);
        }

        [HttpGet("GetSchoollookUps")]
        public async Task<IActionResult> GetLookUpsforSchool()
        {
            var result = await this._schoolsRepo.GetLookUpsforSchool();
            return Ok(result);
        }
    }
}
