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
    [Route("api/Ledgers")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly ILedgerRepository _ledgerRepo;
        public LedgerController(ILedgerRepository ledgerRepo)
        {
            this._ledgerRepo = ledgerRepo;
        }

        [HttpPost("GetAllLedgers")]
        public async Task<IActionResult> GetAllLedgers([FromBody] LedgerAllInputs LedInputs )
        {
            var result = await this._ledgerRepo.GetLedgerDetail(LedInputs);
            return Ok(result);
        }

        [HttpGet("GetLedgerlookUps")]
        public async Task<IActionResult> GetLookUpsforLedger()
        {
            var result = await this._ledgerRepo.GetLookUpsforLedger();
            return Ok(result);
        }

    }
}
