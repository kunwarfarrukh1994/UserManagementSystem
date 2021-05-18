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
    [Route("api/Company")]
    [ApiController]
    public class CompanyController : ControllerBase 
    {
        private readonly ICompaniesRepository _companyRepo;
        public CompanyController(ICompaniesRepository companyRepo)
        {
            this._companyRepo = companyRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromBody] cdCompaniesVM company)
        {
            var result = await this._companyRepo.SaveCompany(company);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCompany(cdCompaniesVM company)
        {
            var result = await this._companyRepo.SaveCompany(company);
            return Ok(result);
        }

        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var result = await this._companyRepo.GetAllCompanies();
            return Ok(result);
        }

        [HttpGet("GetCompanyById/{id?}")]
        public async Task<IActionResult> GetCompanyByID(int id)
        {
            var result = await this._companyRepo.GetCompanyByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteCompany(int Id)
        {
            var result = await this._companyRepo.DeleteCompany(Id);
            return Ok(result);
        }

        [HttpGet("GetCompanylookUps")]
        public async Task<IActionResult> GetLookUpsforCompany()
        {
            var result = await this._companyRepo.GetLookUpsforCompany();
            return Ok(result);
        }
    }
}
