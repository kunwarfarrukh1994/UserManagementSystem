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

        //[HttpGet("GetAllLedgers/{AccountCode}/{FromDate}/{ToDate}/{Lg_Type}/{BranchID}")]
        //public async Task<IActionResult> GetAllLedgers(int accCode, DateTime fDate, DateTime tDate, string lg_type, int branchId)
        //{
        //    var result = await this._ledgerRepo.GetLedgerDetail(accCode, fDate, tDate, lg_type, branchId);
        //    return Ok(result);
        //}

        [HttpPost("GetAllLedgers")]
        public async Task<IActionResult> GetAllLedgers([FromBody] LedgerAllInputs LedInputs)
        {
            var result = await this._ledgerRepo.GetLedgerDetail(LedInputs);
            return Ok(result);
        }

        [HttpGet("GetLedgerlookUps/{CompanyID}/{BranchID}")]
        public async Task<IActionResult> GetLookUpsforLedger(int CompanyID, int BranchID)
        {
            var result = await this._ledgerRepo.GetLookUpsforLedger(CompanyID, BranchID);
            return Ok(result);
        }

    }
}
