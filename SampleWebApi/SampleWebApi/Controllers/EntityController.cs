using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApi.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class EntityController<T>: ControllerBase where T :class
    {
        protected readonly IGenericRepository<T> repository;


        protected EntityController(IGenericRepository<T> repository)
        {
            this.repository = repository;
        }


        protected  virtual async Task<IActionResult> PostEntity(T entity)
        {
            if (entity == null)
            {
                ModelState.AddModelError("Save", "No data passed");
                return  BadRequest(ModelState);
            }

            

            try
            {
                var savedentity =await this.repository.CreateEntityAsync(entity);
                  return new JsonResult(savedentity);
            }
            catch (Exception)
            {

                  return new JsonResult(new HttpResponseException(HttpStatusCode.InternalServerError));
            }
        }

        protected virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            try
            {
                return await this.repository.GetAllAsync();

            }
            catch (Exception ex)
            {
                throw ex;


            }
        }

        protected virtual async Task<IActionResult> GetEntityByID(Guid id)
        {
            try
            {
                var entity= await this.repository.GetEntityByID(id);
                if (entity == null)
                {
                    return NotFound("No Record Found");
                }
                


                return new JsonResult(entity);
            }
            catch (Exception ex)
            {
                throw ex;


            }
        }


        protected virtual async Task<IActionResult> PutEntity(T entity)
        {
            if (entity == null)
            {
                ModelState.AddModelError("Update", "ID is null");
                return BadRequest(ModelState);
            }

            
                var result= await this.repository.UpdateEntity(entity);
                if (result == true)
                {
                    return Ok("Updated Successfully");
                }
                else
                {
                return BadRequest();
                }
      
        }

        protected virtual async Task<IActionResult> DeleteEntity(Guid id)
        {
            if (id == null || Guid.Empty.Equals(id))
            {
                ModelState.AddModelError("Delete", "ID is null");
                return BadRequest(ModelState);
            }

            try
            {


                //this.repository.SoftDelete(entityId, strDeletedBy);
              var result =await this.repository.DeleteEntity(id);
                if (result == "NotFound")
                {
                    return NotFound("Incorrect ID");
                }
                else
                {
                    return Ok("Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




    }
}
