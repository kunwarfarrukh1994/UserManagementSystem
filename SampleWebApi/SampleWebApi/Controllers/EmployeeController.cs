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
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee emp)
        {

            return await base.PostEntity(emp);
        }



        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {

            var list = await base.GetAll();

            return new JsonResult(list);

        }
        [Route("GetByID/{id?}")]
        [HttpGet]

        public async Task<IActionResult> GetEmployeeByID([FromQuery] Guid id)
        {
            var entity = await base.GetEntityByID(id);

            return new JsonResult(entity);
        }

        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
           return await base.PutEntity(emp);
        }


        [Route("Delete/{id?}")]
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee([FromQuery] Guid id)
        {
            return await base.DeleteEntity(id);
        }






    }
}
