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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IShop.Service.Customers", Version = "v1" });
            });

            services
                .AddMongoDb("ishop-customers")
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IShop.Service.Customers");
            });
        }
    }
}
