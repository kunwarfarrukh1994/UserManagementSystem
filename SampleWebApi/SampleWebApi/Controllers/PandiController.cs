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

        [HttpGet("GetAllPandi/{CompanyId}")]
        public async Task<IActionResult> GetAllPandi(int CompanyId)
        {
            var result = await this._pandiRepo.GetAllPandi(CompanyId);
            return Ok(result);
        }

        [HttpGet("GetPandiById/{id}/{CompanyId}")]
        public async Task<IActionResult> GetPandiByID(int id, int CompanyId)
        {
            var result = await this._pandiRepo.GetPandiByID(id, CompanyId);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}/{CompanyId}")]
        public async Task<IActionResult> DeletePandi(int Id, int CompanyId)
        {
            var result = await this._pandiRepo.DeletePandi(Id, CompanyId);
            return Ok(result);
        }
    }
}
