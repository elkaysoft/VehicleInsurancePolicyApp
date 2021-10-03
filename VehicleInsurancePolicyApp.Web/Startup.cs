using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using VehicleInsurancePolicyApp.Core;
using VehicleInsurancePolicyApp.Core.Logics;
using VehicleInsurancePolicyApp.Core.Models;

namespace VehicleInsurancePolicyApp.Web
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
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(p => p.UseInMemoryDatabase(databaseName: "InsurancePolicyApp"));
            //SetVehicleInformation()
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
            }

            var context = app.ApplicationServices.GetService<AppDbContext>();
            SetVehicleInformation(context);
            SetPolicyPrice(context);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private static void SetVehicleInformation(AppDbContext context)
        {
            var vehicleDetails = new List<VehiclesInfo>();

            vehicleDetails.Add(new VehiclesInfo
            {
                Id = 1,
                IsDeleted = false,
                SubmittedBy = "admin",
                SubmittedOn = DateTime.Now,
                VehicleMake = "Toyota",
                VehicleModel = "Corolla"
            });

            vehicleDetails.Add(new VehiclesInfo
            {
                Id = 2,
                IsDeleted = false,
                SubmittedBy = "admin",
                SubmittedOn = DateTime.Now,
                VehicleMake = "Toyota",
                VehicleModel = "Camry"
            });

            vehicleDetails.Add(new VehiclesInfo
            {
                Id = 3,
                IsDeleted = false,
                SubmittedBy = "admin",
                SubmittedOn = DateTime.Now,
                VehicleMake = "Honda",
                VehicleModel = "Accord"
            });

            vehicleDetails.Add(new VehiclesInfo
            {
                Id = 1,
                IsDeleted = false,
                SubmittedBy = "admin",
                SubmittedOn = DateTime.Now,
                VehicleMake = "Honda",
                VehicleModel = "Civic"
            });

            context.VehiclesInfos.AddRange(vehicleDetails);
            context.SaveChanges();
        }

        private static void SetPolicyPrice(AppDbContext context)
        {
            var policyPrices = new List<PolicyPrices>();

            policyPrices.Add(new PolicyPrices
            {
                Id = 1,
                IsDeleted = false,
                SubmittedBy = "admin",
                SubmittedOn = DateTime.Now,
                BodyType = "Car",
                Amount = 5000
            });

            policyPrices.Add(new PolicyPrices
            {
                Id = 2,
                IsDeleted = false,
                SubmittedBy = "admin",
                SubmittedOn = DateTime.Now,
                BodyType = "SUV",
                Amount = 5000
            });

            policyPrices.Add(new PolicyPrices
            {
                Id = 1,
                IsDeleted = false,
                SubmittedBy = "admin",
                SubmittedOn = DateTime.Now,
                BodyType = "Truck",
                Amount = 7500
            });

            policyPrices.Add(new PolicyPrices
            {
                Id = 1,
                IsDeleted = false,
                SubmittedBy = "admin",
                SubmittedOn = DateTime.Now,
                BodyType = "Van",
                Amount = 5000
            });

            context.PolicyPrices.AddRange(policyPrices);
            context.SaveChanges();
        }

    }
}
