using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tier2.Data;
using Tier2.Data.Customer;
using Tier2.Data.Network;
using Tier2.Data.Purchase;
using Tier2.Data.Sale;
using Tier2.Data.User;
using Tier2.Models;

namespace Tier2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<INetwork, NetworkSocket>();
            services.AddSingleton<ISaleService, SaleService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IPurchaseService, PurchaseService>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("v1/swagger.json", "API v1");
            });

        }
    }
}