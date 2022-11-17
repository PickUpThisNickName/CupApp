using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Repository;
using Microsoft.Extensions.Configuration;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using CupApplication.Data;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Serilog;
using Serilog.Events;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CupApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Default", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File($@"{Directory.GetCurrentDirectory()}\Logs\{DateTime.Now:yyyy-MM-dd}.log"
                                , outputTemplate: "[{Timestamp:HH:mm:ss.fff}] |{Level:u3}| {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            services.AddControllers();

            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(Configuration.GetConnectionString("CupDatabase")));
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Users")));

            services.AddHealthChecks();
            services.AddMvc();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddTransient<IBeneficiaries, RepositoryBeneficiaries>();
            services.AddTransient<IBenefitType, RepositoryBenefitType>();
            services.AddTransient<IDrinks, RepositoryDrinks>();
            services.AddTransient<IDrinks_leftovers, RepositoryDrinks_leftovers>();
            services.AddTransient<IProducts, RepositoryProducts>();
            services.AddTransient<IUsers, RepositoryUsers>();
            services.AddTransient<IWorkingSession, RepositoryWorkingSession>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UsersContext>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();    // подключение аутентификации

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope())
            {

                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                UsersContext user = scope.ServiceProvider.GetRequiredService<UsersContext>();
                DBObjects.Initial(content);
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
