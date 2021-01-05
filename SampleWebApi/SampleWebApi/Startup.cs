using BussinessModels;
using DataAccessLayer;
using DataAccessLayer.ReposiotryInterfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagement.DBContext;
using UserManagement.UserModels;
using NSwag;
using Swashbuckle.Swagger;

namespace SampleWebApi
{
    public class Startup
    {

        IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseOpenApi();
                app.UseSwaggerUI(c =>
                {
                    c.DocumentTitle = "User Management System-API";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseFileServer();
            app.UseMvc();

         


        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<UsersDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersDBContext>()  //   bridge to connect identity with our database
                .AddDefaultTokenProviders();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IGenericRepository<Employee>, GenericRepository<Employee>>();
            services.AddSwaggerDocument();





        }


    }
}
