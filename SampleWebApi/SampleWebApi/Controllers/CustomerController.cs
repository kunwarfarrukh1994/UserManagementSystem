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
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepo;
        public CustomerController(ICustomersRepository customersRepo)
        {
            this._customersRepo = customersRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomers([FromBody] CustomerVM customers)
        {
            var result = await this._customersRepo.SaveCustomers(customers);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomer(CustomerVM customers)
        {
            var result = await this._customersRepo.SaveCustomers(customers);
            return Ok(result);
        }

        [HttpGet("GetAllCustomers/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllSales(int CompanyId, int BranchId)
        {
            var result = await this._customersRepo.GetAllCustomers(CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetCustomerById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetCustomerByID(int id, int CompanyId, int BranchId)
        {
            var result = await this._customersRepo.GetCustomerByID(id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> DeleteCustomer(int Id, int CompanyId, int BranchId)
        {
            var result = await this._customersRepo.DeleteCustomer(Id, CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetCustomerlookUps/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetLookUpsforCustomer(int CompanyId, int BranchId)
        {
            var result = await this._customersRepo.GetLookUpsforCustomer(CompanyId, BranchId);
            return Ok(result);
        }

    }
}
