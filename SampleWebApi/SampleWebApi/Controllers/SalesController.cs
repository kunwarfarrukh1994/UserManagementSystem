using DataAccessLayer.ReposiotryInterfaces;
using BussinessModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _salesRepo;
        public SalesController(ISalesRepository salesRepo)
        {
            this._salesRepo = salesRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSales([FromBody] SalesMainVM sales)
        {
            var result = await this._salesRepo.InsertSales(sales);
            return Ok(result);
        }

    }
}
