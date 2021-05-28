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
    [Route("api/Pandi")]
    [ApiController]
    public class PandiController : ControllerBase
    {
        private readonly IPandiRepository _pandiRepo;
        public PandiController(IPandiRepository addaRepo)
        {
            this._pandiRepo = addaRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePandi([FromBody] PandiVM pandi)
        {
            var result = await this._pandiRepo.SavePandi(pandi);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePandi(PandiVM pandi)
        {
            var result = await this._pandiRepo.SavePandi(pandi);
            return Ok(result);
        }

        [HttpGet("GetAllPandi")]
        public async Task<IActionResult> GetAllPandi()
        {
            var result = await this._pandiRepo.GetAllPandi();
            return Ok(result);
        }

        [HttpGet("GetPandiById/{id?}")]
        public async Task<IActionResult> GetPandiByID(int id)
        {
            var result = await this._pandiRepo.GetPandiByID(id);
            return Ok(result);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> DeletePandi(int Id)
        {
            var result = await this._pandiRepo.DeletePandi(Id);
            return Ok(result);
        }
    }
}
