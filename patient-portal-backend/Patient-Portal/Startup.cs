using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Patient_Portal.DataAccess;
using Patient_Portal.BusinessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Patient_Portal
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
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string sqlServerConnectionString;
            if (environment == "Development")
            {
                sqlServerConnectionString = Configuration.GetConnectionString("patientDatabase");
            }
            else
            {
                sqlServerConnectionString = Environment.GetEnvironmentVariable("SQLSERVER");
            }
            services.AddDbContext<PatientDbContext>(options => options.UseSqlServer(sqlServerConnectionString));
            //created instance for dbcontext
            services.AddScoped<PatientDbContext>();
            //created instance for PatientUpdateProfileService
            services.AddScoped<IPatientProfileService, PatientProfileService>();
            //created for PatientUpdateProfileRepository
            services.AddScoped<IPatientProfileRepository, PatientProfileRepository>();
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

            app.UseStaticFiles();
            app.UseCors(builder =>
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
            );

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger.json", "patientApi");
            });
            //app.UseHttpsRedirection();
            app.UseAuthentication(); // before app.UseMVC()
            app.UseMvc();
        }
    }
}
