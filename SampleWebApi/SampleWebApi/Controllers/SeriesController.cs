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
    [Route("api/Series")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesRepository _seriesRepo;
        public SeriesController(ISeriesRepository seriesRepo)
        {
            this._seriesRepo = seriesRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateSeries([FromBody] mSeriesVM series)
        {
            var result = await this._seriesRepo.SaveSeries(series);
            return Ok(result);
        }

        [HttpGet("GetAllSeries/{CompanyId}")]
        public async Task<IActionResult> GetAllSeries(int CompanyId)
        {
            var result = await this._seriesRepo.GetAllSeries(CompanyId);
            return Ok(result);
        }

        [HttpGet("GetSeriesById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetSeriesById(int id, int CompanyId)
        {
            var result = await this._seriesRepo.GetSeriesByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}")]
        public async Task<IActionResult> DeleteSeries(int Id, int CompanyId)
        {
            var result = await this._seriesRepo.DeleteSeries(Id, CompanyId);
            return Ok(result);
        }

    }
}
