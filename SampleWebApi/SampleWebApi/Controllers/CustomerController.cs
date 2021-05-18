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

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllSales()
        {
            var result = await this._customersRepo.GetAllCustomers();
            return Ok(result);
        }

        [HttpGet("GetCustomerById/{id?}")]
        public async Task<IActionResult> GetCustomerByID(int id)
        {
            var result = await this._customersRepo.GetCustomerByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            var result = await this._customersRepo.DeleteCustomer(Id);
            return Ok(result);
        }

        [HttpGet("GetCustomerlookUps")]
        public async Task<IActionResult> GetLookUpsforCustomer()
        {
            var result = await this._customersRepo.GetLookUpsforCustomer();
            return Ok(result);
        }

    }
}
