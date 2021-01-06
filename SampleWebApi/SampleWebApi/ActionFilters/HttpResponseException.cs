using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;
using IActionFilter = Microsoft.AspNetCore.Mvc.Filters.IActionFilter;

namespace SampleWebApi.ActionFilters
{
    public class HttpResponseException : Exception
    {



        public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;

        public List<String> ErrorMessages = new List<string>();
        public HttpResponseException()
        { }

    }
    



    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
           
            var result = new HttpResponseException();


            result.Status = HttpStatusCode.InternalServerError;
            result.ErrorMessages.Add(exception.Message);


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }


    // action filte 

    public class validationFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context,ActionExecutionDelegate next)
        {

            var result = new HttpResponseException();


            var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(m => m.ErrorMessage).ToList();
            if(errors.Count!=0)
            {
                
                result.Status = HttpStatusCode.BadRequest;
                result.ErrorMessages.Add(errors[0]);

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));
              
            }
            // FirstOrDefault<string>());//.Select(m => m.ErrorMessage[0]);

            return  next();
            base.OnActionExecuting(context);
          //  context.ActionArguments;
        }
        public bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
