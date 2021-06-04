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

        [HttpGet("GetAllLedgers")]
        public async Task<IActionResult> GetAllLedgers(int accCode, DateTime fDate, DateTime tDate,int branchID, string lg_Type )
        {
            var result = await this._ledgerRepo.GetLedgerDetail(accCode, fDate, tDate,branchID,lg_Type);
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
