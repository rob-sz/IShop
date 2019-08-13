using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Linq;

namespace IShop.Common.Mongo.Extensions
{
    public static class MongoDbInjection
    {
        private static string ConfigurationSectionName = "MongoDb";

        public static IServiceCollection AddMongoDb(
            this IServiceCollection services, string databaseName)
        {
            var conventionPack = new ConventionPack();
            conventionPack.Add(new IgnoreExtraElementsConvention(true));
            conventionPack.Add(new EnumRepresentationConvention(BsonType.String));
            conventionPack.Add(new CamelCaseElementNameConvention());

            ConventionRegistry.Register("GlobalConventions", conventionPack, x => true);

            var mongoDbSettings = GetMongoDbSettings(services);
            var databaseSettings = mongoDbSettings.Databases.SingleOrDefault(
                db => db.Name.Equals(databaseName, StringComparison.InvariantCultureIgnoreCase));
            if (databaseSettings == null)
            {
                throw new DatabaseNotFoundException(
                    $"Database '{databaseName}' settings not found.", databaseName);
            }

            services.AddScoped(
                serviceProvider => new MongoClient(
                    databaseSettings.ConnectionString).GetDatabase(databaseName));

            return services;
        }

        public static IServiceCollection AddMongoDbRepository<TEntity>(
            this IServiceCollection services)
            => AddMongoDbRepository<TEntity>(services, typeof(TEntity).Name);

        public static IServiceCollection AddMongoDbRepository<TEntity>(
            this IServiceCollection services, string collectionName)
        {
            services.AddScoped(
                serviceProvider => new MongoDbRepository<TEntity>(
                    serviceProvider.GetService<IMongoDatabase>(), collectionName));

            return services;
        }

        private static MongoDbSettings GetMongoDbSettings(IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var configurationSection = configuration.GetSection(ConfigurationSectionName);

                services.Configure<MongoDbSettings>(configurationSection);

                var mongoDbSettings = new MongoDbSettings();
                configurationSection.Bind(mongoDbSettings);

                return mongoDbSettings;
            }
        }
    }
}
