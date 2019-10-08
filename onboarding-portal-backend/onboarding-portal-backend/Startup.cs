using BusinessLayer;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;

namespace onboarding_portal_backend
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
            string constr;
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                constr = Environment.GetEnvironmentVariable("sql_server");
                Console.WriteLine(constr);
            }
            else
            {
                constr = Configuration.GetConnectionString("userdb");
                Console.WriteLine(constr);
            }
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(constr));
            services.AddScoped<UserDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailVerificationService, EmailVerificationService>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //app.UseSwagger();
            app.UseCors(builder => 
                builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials()
            );

        app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger.json", "onboardingApi");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
