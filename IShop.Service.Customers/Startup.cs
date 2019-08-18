using IShop.Common.Messaging.Bus;
using IShop.Common.Messaging.Bus.NoQueue;
using IShop.Common.Messaging.Command;
using IShop.Common.Messaging.Query;
using IShop.Common.Mongo.Extensions;
using IShop.Service.Customers.Domain.Model;
using IShop.Service.Customers.Handler.Query;
using IShop.Service.Customers.Messages.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IShop.Service.Customers
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

            services
                .AddMongoDb("customer-service")
                .AddMongoDbRepository<Customer>();

            // configure query dispatchers
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

            // configure query handlers
            services.AddSingleton<IQueryHandler<GetCustomerQuery, GetCustomerResult>, GetCustomerHandler>();

            // configure command dispatchers
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

            // configure command handlers

            // configure messaging bus
            services.AddSingleton<IMessageBusClient, NoQueueBusClient>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
