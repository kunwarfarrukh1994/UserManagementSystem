using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManagement.DBContext;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Services;
using UserManagement.UserModels;

namespace SampleWebApi.CustumExceptionMiddelware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDbLogger _log;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
         //   this._log = log;
            //this._context = dbcontext;

        }
        public async Task Invoke(HttpContext context, IDbLogger _log)    //UserManager<ApplicationUser> _userManager
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex,_log).ConfigureAwait(false);
            }
        }
        private  Task HandleExceptionAsync(HttpContext context, Exception exception, IDbLogger log )
        {
            context.Response.ContentType = "application/json";

            var result = new HttpResponseExceptionModel();
            var LogErrors = new LogApiError();


            result.Status = HttpStatusCode.InternalServerError;
            result.ErrorMessages.Add(exception.Message);

            //log error to db 
            LogErrors.StatusCode = 500;
            LogErrors.Message = result.ErrorMessages[0];
            LogErrors.TimeUtc = DateTime.Now;
            LogErrors.RequestUri = context.Request.Path;
            LogErrors.QueryParams = context.Request.QueryString.ToString();
            if(!context.Request.Path.Value.Contains("/register"))
            {
                LogErrors.UserName = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
               
            }

            // return principal.FindFirst(ClaimTypes.NameIdentifier);

            try
            {
              //  var db = (DbLogger)context.RequestServices.GetService(typeof(IDbLogger));

                log.LogToDB(LogErrors);
                
                

                   
                
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            


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
    public interface IMyLoggingModel : IDisposable
    {
        DbSet<LogApiError> Log { get; set; }
        Task<int> SaveChangesAsync();

        //...other needed members.
    }
}
