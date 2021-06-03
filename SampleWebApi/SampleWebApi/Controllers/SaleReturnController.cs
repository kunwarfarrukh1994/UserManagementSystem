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
    [Route("api/SaleReturn")]
    [ApiController]
    public class SaleReturnController : ControllerBase
    {
        private readonly ISaleReturnRepository _saleReturnRepo;

        public SaleReturnController(ISaleReturnRepository saleReturnRepo)
        {
            this._saleReturnRepo = saleReturnRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateSaleReturn([FromBody] SaleReturnMainVM saleReturn)
        {
            var result = await this._saleReturnRepo.SaveSaleReturn(saleReturn);
            return Ok(result);
        }

        [HttpGet("GetSaleReturnById/{id?}")]
        public async Task<IActionResult> GetSaleReturnByID(int id)
        {
            var result = await this._saleReturnRepo.GetSaleReturnByID(id);
            return Ok(result);
        }
    }
}
