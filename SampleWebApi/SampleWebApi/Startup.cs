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
using NSwag;
using Swashbuckle.Swagger;
using SampleWebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SampleWebApi.AuthorizationHandlers;


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


                // swagger
                app.UseOpenApi();
                app.UseSwaggerUI(c =>
                {
                    c.DocumentTitle = "User Management System-API";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    c.RoutePrefix = string.Empty;
                });
            }


            // custum exception handler for globalizing error handling and expections 
           // app.UseCustomExceptionMiddleware();

            // file server and mvc 
            app.UseFileServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMvc();

         


        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            string issuer = Configuration.GetValue<string>("Jwt:ValidAudience");

            string signingKey = Configuration.GetValue<string>("Jwt:Secret");
            byte[] signingKeyBytes = Encoding.UTF8.GetBytes(signingKey);

            // database context
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           // services.AddDbContext<UsersDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
           //identity
           // services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<UsersDBContext>().AddDefaultTokenProviders();  //   bridge to connect identity with our database.AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {

                options.User.RequireUniqueEmail = true;
                // passsword
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // email varification 

                options.SignIn.RequireConfirmedEmail = true;


                options.ClaimsIdentity.EmailClaimType.EndsWith("gmail.com");




            });

            //  services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });



            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetValue<string>("Jwt:ValidIssuer"),
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetValue<string>("Jwt:ValidAudience"),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });


            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddAuthorization(
                options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                   // .RequireRole(UserRoles.User)
                    .Build();
            }

            );

            

            
            // mvc 

            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                option.Filters.Add(new ValidationModelFilter());
            });

            // dependency injection
            services.AddScoped<IAuthorizationHandler, UserAuthorizationHandler>();
           // services.AddTransient<IGenericRepository<Employee>, GenericRepository<Employee>>();
           // services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
           // services.AddTransient<IUserManagementService, UserManagementService>();
            services.AddTransient<ISalesRepository, SalesRepository >();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<ICompaniesRepository, CompaniesRepository>();
            services.AddTransient<ICategoryAccRepository, CategoryAccRepository>();
            services.AddTransient<IControlAccRepository, ControlAccRepository>();
            services.AddTransient<ISubAccountsRepository, SubAccountsRepository>();
            services.AddTransient<ISchoolsRepository, SchoolsRepository>();
            services.AddTransient<IMainGroupAccRepository, MainGroupAccRepository>();
            services.AddTransient<IAddaRepository, AddaRepository>();
            services.AddTransient<IGodownRepository, GodownRpository>();
            services.AddTransient<IPandiRepository, PandiRepository>();
            services.AddTransient<IGenRepository, GenRepository>();





            // services.AddTransient<IDbLogger, DbLogger>();
            //swagger 
            services.AddSwaggerDocument();





        }


    }
}
