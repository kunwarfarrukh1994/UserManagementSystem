﻿using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [Route("api/ControlAcc")]
    [ApiController]
    public class ControlAccController : ControllerBase
    {
        private readonly IControlAccRepository _controlRepo;
        
        public ControlAccController(IControlAccRepository controlRepo)
        {
            this._controlRepo = controlRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateControlAcc([FromBody] adControlAccountsVM controlAcc)
        {
            
            var result = await this._controlRepo.SaveControlAcc(controlAcc);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateControlAcc(adControlAccountsVM controlAcc)
        {
            
            var result = await this._controlRepo.SaveControlAcc(controlAcc);
            return Ok(result);
        }

        [HttpGet("GetAllControlAcc")]
        public async Task<IActionResult> GetAllControlAcc()
        {
            var result = await this._controlRepo.GetAllControlAcc();
            return Ok(result);
        }
        [HttpGet("GetControlAccById/{id?}")]
        public async Task<IActionResult> GetControlAccByID(int id)
        {
        
            var result = await this._controlRepo.GetControllAccByID(id);
            
            return Ok(result);
        }
        [HttpDelete("DeleteControlAcc/{id?}")]
        public async Task<IActionResult> DeleteControlAcc(int Id)
        {
            var result = await this._controlRepo.DeleteControlAcc(Id);
            return Ok(result);
        }

        [HttpGet("GetControlAcclookUps")]
        public async Task<IActionResult> GetLookUpsforControlAcc()
        {
            var result = await this._controlRepo.GetLookUpsforCtrlAcc();
            return Ok(result);
        }
    }
}