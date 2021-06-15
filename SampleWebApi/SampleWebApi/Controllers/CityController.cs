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
    [Route("api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepo;
        public CityController(ICityRepository cityRepo)
        {
            this._cityRepo = cityRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCity([FromBody] CityVM city)
        {
            var result = await this._cityRepo.SaveCity(city);
            return Ok(result);
        }
        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await this._cityRepo.GetAllCities();
            return Ok(result);
        }
        [HttpGet("GetCityById/{id?}")]
        public async Task<IActionResult> GetCityByID(int id)
        {
            var result = await this._cityRepo.GetCityByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteCity(int Id)
        {
            var result = await this._cityRepo.DeleteCity(Id);
            return Ok(result);
        }
    }
}
