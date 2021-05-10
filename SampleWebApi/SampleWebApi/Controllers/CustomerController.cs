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
    }
}
