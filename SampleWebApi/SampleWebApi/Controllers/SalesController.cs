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
            var result = await this._salesRepo.SaveSales(sales);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateSales(SalesMainVM sales)
        {
            var result = await this._salesRepo.SaveSales(sales);
            return Ok(result);
        }

        [HttpGet("GetAllSales")]
        public async Task<IActionResult> GetAllSales() 
        {
            var result = await this._salesRepo.GetAllSales();
            return Ok(result) ;
        }

        [HttpGet("GetSaleById/{id?}")]
        public async Task<IActionResult> GetSaleByID(int id)
        {
            var result = await this._salesRepo.GetSaleByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteSale(int Id)
        {
            var result = await this._salesRepo.DeleteSale(Id);
            return Ok(result);
        }

    }
}
