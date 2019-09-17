using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Salon.API.MappingProfiles;
using Salon.Data;
using Salon.Data.Repositories;
using Salon.Data.Repositories.Interfaces;
using Salon.Service;
using Salon.Service.Interfaces;

namespace Salon.API
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
            services.AddDbContext<SalonContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SalonContext"), sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure())
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGiftCardRepository, GiftCardRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IGiftCardTransactionRepository, GiftCardTransactionRepository>();

            // services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IGiftCardService, GiftCardService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IGiftCardTransactionService, GiftCardTransactionService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(options =>
            {
                var config = Configuration.GetSection("Cors").GetChildren();
                var urls = config.FirstOrDefault(item => item.Key == "SalonUX").GetChildren().Select(child => child.Value).ToArray();
                options.AddPolicy("SalonPolicy", builder =>
                {
                    builder.WithOrigins(urls)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("SalonPolicy"));
            });
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.AddAutoMapper();
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
            app.UseCors("GiftCardPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
