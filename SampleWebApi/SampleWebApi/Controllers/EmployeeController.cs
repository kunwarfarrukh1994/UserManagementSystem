using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessModels;
using DataAccessLayer;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : EntityController<Employee>
    {
        public EmployeeController(IGenericRepository<Employee> employeeRepo) : base(employeeRepo)
        {

        }
        [HttpPost("Create")]
        [Route("Create")]
        //[HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee emp)
        {

            return await base.PostEntity(emp);
        }



        [HttpGet("GetAll")]
        [Route("GetAll")]

        // [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {

            var list = await base.GetAll();

            return new JsonResult(list);

        }
        [HttpGet("GetByID/{id?}")]
        [Route("GetByID/{id?}")]

        // [HttpGet]

        public async Task<IActionResult> GetEmployeeByID([FromQuery] Guid id)
        {
            var entity = await base.GetEntityByID(id);

            return new JsonResult(entity);
        }

        [HttpPost("Update")]
        [Route("Update")]

        // [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
           return await base.PutEntity(emp);
        }


        [HttpDelete("Delete/{id?}")]
        [Route("Delete/{id?}")]

        //[HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromQuery] Guid id)
        {
            return await base.DeleteEntity(id);
        }






    }
}
