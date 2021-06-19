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
    [Route("api/Agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentRepository _agentsRepo;
        public AgentsController(IAgentRepository agentsRepo)
        {
            this._agentsRepo = agentsRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAgent([FromBody] AgentsVM agent)
        {
            var result = await this._agentsRepo.SaveAgent(agent);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAgent(AgentsVM agent)
        {
            var result = await this._agentsRepo.SaveAgent(agent);
            return Ok(result);
        }

        [HttpGet("GetAllMAgents/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllMAgents(int CompanyId, int BranchId)
        {
            var result = await this._agentsRepo.GetAllMAgents(CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetAllRAgents/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAllRAgents(int CompanyId, int BranchId)
        {
            var result = await this._agentsRepo.GetAllRAgents(CompanyId, BranchId);
            return Ok(result);
        }

        [HttpGet("GetAgentById/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> GetAgentByID(int id, int CompanyId, int BranchId)
        {
            var result = await this._agentsRepo.GetAgentByID(id, CompanyId, BranchId);
            return Ok(result);
        }

        //[HttpGet("GetRAgentById/{id?}")]
        //public async Task<IActionResult> GetRAgentByID(int id)
        //{
        //    var result = await this._agentsRepo.GetRAgentByID(id);
        //    return Ok(result);
        //}

        [HttpDelete("Delete/{id}/{CompanyId}/{BranchId}")]
        public async Task<IActionResult> DeleteAgent(int Id, int CompanyId, int BranchId)
        {
            var result = await this._agentsRepo.DeleteAgent(Id, CompanyId, BranchId);
            return Ok(result);
        }


    }
}
