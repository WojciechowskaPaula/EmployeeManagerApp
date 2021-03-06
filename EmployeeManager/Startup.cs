using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewHelpers;
using EmployeeManager.Models.ViewModels;
using EmployeeManager.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager
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
            services.AddDbContext<EmployeeManager.Data.ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator<EmployeeBaseVM>, EmployeeBaseValidator>();
            services.AddTransient<IValidator<EmployeeAddVM>, EmployeeValidator>();
            services.AddTransient<IValidator<EmployeeEditVM>, EmployeeEditVMValidator>();
            services.AddTransient<IValidator<ManagerEditVM>, ManagerValidator>();
            services.AddTransient<IValidator<PositionAddVM>, PositionAddVMValidator>();
            services.AddTransient<IValidator<Position>, PositionValidator>();
            services.AddTransient<IValidator<PositionDetailsVM>, PositionDetailsVMValidator>();
            services.AddTransient<IValidator<Project>, ProjectValidator>();
            services.AddTransient<IValidator<ProjectEditVM>, ProjectEditVMValidator>();


            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IManagerService, ManagerService>();
            services.AddTransient<IPositionService, PositionService>();
            

            services.AddTransient<EmployeeHelper, EmployeeHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
