using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using EASV.PetRestAPI.Models;
using EASV.PetShop.Core.ApplicationService;
using EASV.PetShop.Core.ApplicationService.Services;
using EASV.PetShop.Core.DomainService;
using PetShop.Infrastructure.Data.Repositories;
using PetShop.Infrastructure.Data;
using EASV.PetRestAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EASV.PetRestAPI.Data;
using EASV.PetShop.Entities;

namespace EASV.PetRestAPI
{
    public class Startup
    {

        private IConfiguration _conf { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();

            JwtSecurityKey.SetSecret("a secret that needs to be at least 16 characters long");
        }




        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            // Add CORS
            services.AddCors();


            if (_env.IsDevelopment())
            {
                services.AddDbContext<PetAppContext>(
                    opt => opt.UseSqlite("Data Source=customerApp.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<PetAppContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            //services.AddScoped<IPrinter, Printer>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IUserRepository<User>, UserRepository>();


            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling
                       = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetAppContext>();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetAppContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable CORS (must precede app.UseMvc()):
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
