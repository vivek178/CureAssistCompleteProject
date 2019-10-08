using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using doctor_dc_backend.BusinessLayer;
using doctor_dc_backend.BusinessLayer.Exceptions;
using doctor_dc_backend.DataAccessLayer;
using doctor_dc_backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace doctor_dc_backend
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<DiagnosisCenterDbContext>();
            services.AddScoped<IDiagCenRepository, DiagnosisCenterRepository>();
            services.AddScoped<IDiagCenService, DiagnosisCenterService>();
            services.AddScoped<DoctorDbContext>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddAuthentication(x => {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           })
           .AddJwtBearer(x => {
               x.IncludeErrorDetails = true;
               x.SaveToken = true;
               x.RequireHttpsMetadata = false;
               x.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateAudience = false,
                   ValidateIssuer = false,
                   ValidateLifetime = false,
                   ValidateActor = false,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dsfjffsjfdsdkjhsfeewiojflknfDSBkdfuiowidnfFNfIGlKuiunJHGjhjVyuvkjbJfYvKJbygkbjBUKuk"))
               };
           });
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

           // app.UseHttpsRedirection();

            app.UseCors(builder => builder
            .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseDefaultFiles();
           
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/doctor.json", "doctor-backend");
                c.SwaggerEndpoint("/diagnosiscenter.json", "diagnosis-center-backend");
            });
            
        }
    }
}
