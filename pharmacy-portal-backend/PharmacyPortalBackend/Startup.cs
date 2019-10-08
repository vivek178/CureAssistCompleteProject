using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pharmacy_portal_backend.BusinessLayer;
using pharmacy_portal_backend.DataAccess;
using pharmacy_portal_backend.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace pharmacy_portal_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlser;
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                sqlser = Environment.GetEnvironmentVariable("sql_server");
            }
            else
            {
                sqlser = Configuration.GetConnectionString("DatabasePharmacy");
            }
            
            services.AddDbContext<PharmacyDbContext>(options => options.UseSqlServer(sqlser));
            services.AddScoped<PharmacyDbContext>();
            services.AddScoped<IPharmacyProfileService, PharmacyProfileService>();
            services.AddScoped<IPharmacyProfileRepo, PharmacyProfileRepo>();
            services.AddScoped<PrescriptionOrderDBContext>();
            services.AddScoped<IPrescriptionOrderRequestService, PrescriptionOrderRequestService>();
            services.AddScoped<IPrescriptionOrderRequestRepository, PrescriptionOrderRequestRepository>();
            services.AddScoped<IPrescriptionOrderRequestNotificationService, PrescriptionOrderRequestNotificationService>();
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed((host) => true)
                .WithOrigins("http://localhost:4200", "http://pharmacy.cureassist.com:4200", "http://pharmacy.cureassist.cgi-wave7.stackroute.io");
            }));
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
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger.json", "pharmacyApi");
            });
            app.UseSignalR(routes =>
            {
                routes.MapHub<PharmacyNotificationHub>("/notifications");

            });
            app.UseAuthentication(); // before app.UseMVC()
            //var hubConfiguration = new HubConfiguration();
            //hubConfiguration.EnableDetailedErrors = true;
            //app.MapSignalR(hubConfiguration);
            app.UseMvc();
            
        }
    }
}
