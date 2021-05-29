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
    [Route("api/Gen")]
    [ApiController]
    public class GenController : ControllerBase
    {
        private readonly IGenRepository _genRepo;
        public GenController(IGenRepository genRepo)
        {
            this._genRepo = genRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateGen([FromBody] GenMainVM gen)
        {
            var result = await this._genRepo.SaveGen(gen);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGen(GenMainVM gen)
        {
            var result = await this._genRepo.SaveGen(gen);
            return Ok(result);
        }

        [HttpGet("GetAllGens")]
        public async Task<IActionResult> GetAllGen()
        {
            var result = await this._genRepo.GetAllGen();
            return Ok(result);
        }

        [HttpGet("GetGenById/{id?}")]
        public async Task<IActionResult> GetGenByID(int id)
        {
            var result = await this._genRepo.GetGenByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeleteGen(int Id)
        {
            var result = await this._genRepo.DeleteGen(Id);
            return Ok(result);
        }

        [HttpGet("GetGenlookUps")]
        public async Task<IActionResult> GetLookUpsforGen()
        {
            var result = await this._genRepo.GetLookUpsforGen();
            return Ok(result);
        }
    }
}
