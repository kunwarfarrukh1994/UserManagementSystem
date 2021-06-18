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

        [HttpGet("GetAllSales/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllSales(int CompanyId, int BranchId) 
        {
            var result = await this._salesRepo.GetAllSales(CompanyId, BranchId);
            return Ok(result) ;
        }

        [HttpGet("GetSaleById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetSaleByID(int id, int CompanyId, int BranchId)
        {
            var result = await this._salesRepo.GetSaleByID(id,CompanyId,BranchId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteSale(int Id)
        {
            var result = await this._salesRepo.DeleteSale(Id);
            return Ok(result);
        }

        [HttpGet("GetSalelookUps")]
        public async Task<IActionResult> GetLookUpsforSale()
        {
            var result = await this._salesRepo.GetLookUpsforSale();
            return Ok(result);
        }

        [HttpGet("GetSaleInvoicelookUps")]
        public async Task<IActionResult> GetLookUpsforSaleInvoice()
        {
            var result = await this._salesRepo.GetLookUpsforSalesInvoice();
            return Ok(result);
        }

    }
}
