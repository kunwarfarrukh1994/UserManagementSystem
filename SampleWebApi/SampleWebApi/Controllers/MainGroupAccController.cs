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
    [Route("api/MainGroupAcc")]
    [ApiController]
    public class MainGroupAccController : ControllerBase
    {
        private readonly IMainGroupAccRepository _groupAccRepo;
        public MainGroupAccController(IMainGroupAccRepository groupAccRepo)
        {
            this._groupAccRepo = groupAccRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGroupAcc([FromBody] adMainGroupAccountsVM groupAcc)
        {
            var result = await this._groupAccRepo.SaveGroupAcc(groupAcc);
            return Ok(result);
        }

        [HttpGet("GetGroupAcclookUps")]
        public async Task<IActionResult> GetLookUpsforGroupAcc()
        {
            var result = await this._groupAccRepo.GetLookUpsforGroupAcc();
            return Ok(result);
        }

        [HttpGet("GetAllGroupAccounts")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await this._groupAccRepo.GetAllGroupAccounts();
            return Ok(result);
        }
        [HttpGet("GetGroupAccById/{id?}")]
        public async Task<IActionResult> GetGroupAccByID(int id)
        {
            var result = await this._groupAccRepo.GetGroupAccByID(id);
            return Ok(result);
        }


    }
}
