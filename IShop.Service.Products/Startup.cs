using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using IShop.Common.Messaging.Query;
using IShop.Service.Products.Handlers.Query;
using IShop.Service.Products.Messages.Query;
using IShop.Common.Mongo.Extensions;
using IShop.Common.Messaging.Command;
using IShop.Common.Messaging.Bus;
using IShop.Common.Messaging.Bus.NoQueue;
using IShop.Service.Products.Messages.Command;
using IShop.Service.Products.Handlers.Command;
using Swashbuckle.AspNetCore.Filters;
using IShop.Service.Products.Swagger;

namespace IShop.Service.Products
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IShop.Service.Products", Version = "v1" });
                c.ExampleFilters();
            });

            services.AddSwaggerExamplesFromAssemblyOf<CreateProductCommandExample>();

            services.AddAutoMapper(typeof(Startup));

            // configure query dispatchers
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            // configure query handlers
            services.AddScoped<IQueryHandler<GetProductQuery, GetProductResult>, GetProductHandler>();
            services.AddScoped<IQueryHandler<GetProductCategoriesQuery, GetProductCategoriesResult>, GetProductCategoriesHandler>();
            services.AddScoped<IQueryHandler<GetProductSearchQuery, GetProductSearchResult>, GetProductSearchHandler>();

            // configure command dispatchers
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            // configure command handlers
            services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductHandler>();

            // configure messaging bus
            services.AddScoped<IMessageBusClient, NoQueueBusClient>();

            // configure persistence
            services
                .AddMongoDb("ishop-products")
                .AddMongoDbRepository<Persistence.Model.Product>()
                .AddMongoDbRepository<Persistence.Model.Category>();

            services.AddScoped<Persistence.IProductRepository, Persistence.ProductRepository>();
            services.AddScoped<Persistence.ICategoryRepository, Persistence.CategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // gateway uses http to call this service
            //app.UseHttpsRedirection();

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
                c.SwaggerEndpoint("/swagger/products/v1/swagger.json", "IShop.Service.Products"); // gateway
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "IShop.Service.Products"); // local
            });
        }
    }
}
