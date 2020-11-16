using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [Route("demo")]
        public JsonResult DemoAction()
        {
            var obj=new Employee() {
               Name="dd",
               Age=19
            
            };
           return  new JsonResult(obj);

        }
    }
}
