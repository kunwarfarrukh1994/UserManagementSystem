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

        [HttpGet("GetAllSchools/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllCustomers(int CompanyId, int BranchId)
        {
            var result = await this._schoolsRepo.GetAllSchools(CompanyId, BranchId);
            return Ok(result);
        }


        [HttpGet("GetSchoolById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetSchoolByID(int id, int CompanyId, int BranchId)
        {
            var result = await this._schoolsRepo.GetSchoolByID(id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> DeleteSchool(int Id, int CompanyId, int BranchId)
        {
            var result = await this._schoolsRepo.DeleteSchool(Id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetSchoollookUps/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetLookUpsforSchool(int CompanyId, int BranchId)
        {
            var result = await this._schoolsRepo.GetLookUpsforSchool(CompanyId, BranchId);
            return Ok(result);
        }
    }
}
