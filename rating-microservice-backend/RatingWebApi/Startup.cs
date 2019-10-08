using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RatingWebApi.DataAccessLayer;
using RatingWebApi.Service;
using System;

namespace RatingWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //var conString = Configuration.GetConnectionString("connectionString");
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string conString;
            if (environment == "Development")
            {
                conString = Configuration.GetConnectionString("RatingDb");
            }
            else
            {
                conString = Environment.GetEnvironmentVariable("SQLSERVER");
            }
            services.AddDbContext<RatingDBContext>(options => options.UseSqlServer(conString));
            services.AddScoped<RatingDBContext>();

            services.AddScoped<IRatingRepo, RatingRepo>();
            services.AddScoped<IRatingService, RatingService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors( builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
