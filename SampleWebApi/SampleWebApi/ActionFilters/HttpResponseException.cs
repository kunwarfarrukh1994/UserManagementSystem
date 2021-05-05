using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;
namespace SampleWebApi.ActionFilters
{
    
    




    // action filte 

    public class ValidationModelFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context,ActionExecutionDelegate next)
        {

            
            base.OnActionExecuting(context);
            var result = new HttpResponseExceptionModel();


            var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(m => m.ErrorMessage).ToList();
            if (errors.Count != 0)
            {

                result.Status = HttpStatusCode.BadRequest;
                result.ErrorMessages.Add(errors[0]);

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));

            }

            return next();
        }
    }
}
