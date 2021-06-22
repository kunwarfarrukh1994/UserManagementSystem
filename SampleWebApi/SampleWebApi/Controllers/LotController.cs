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
    [Route("api/Lot")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private readonly ILotRepository _lotRepo;

        public LotController(ILotRepository lotRepo)
        {
            this._lotRepo = lotRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLot([FromBody] LotVM lot)
        {
            var result = await this._lotRepo.SaveLot(lot);
            return Ok(result);
        }
        [HttpGet("GetAllLots/{CompanyId}")]
        public async Task<IActionResult> GetAllLots(int CompanyId)
        {
            var result = await this._lotRepo.GetAllLots(CompanyId);
            return Ok(result);
        }
        [HttpGet("GetLotById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetLotById(int id, int CompanyId)
        {
            var result = await this._lotRepo.GetLotByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteLot(int Id, int CompanyId)
        {
            var result = await this._lotRepo.DeleteLot(Id, CompanyId);
            return Ok(result);
        }
    }
}
