using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.HttpClients;
using TheSecondTestSolution.Domain.Repositories;
using TheSecondTestSolution.Domain.Seed;
using TheSecondTestSolution.Infrastructure.Cache;
using TheSecondTestSolution.Infrastructure.Database;
using TheSecondTestSolution.Infrastructure.HttpClients;
using TheSecondTestSolution.Infrastructure.Repositories;

namespace TheSecondTestSolution.Infrastructure
{
    public static class InfrastructureLayerExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection collection, IConfiguration configuration)
        {
            IConfigurationSection connectionSection = configuration.GetSection("ConnectionStrings");

            string dbConnection = connectionSection.GetValue<string>("topics") ?? string.Empty;
            string redisConnection = connectionSection.GetValue<string>("redis") ?? string.Empty;

            collection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnection;
            });
            collection.AddSingleton(typeof(ICacheRepository<>), typeof(CacheRepository<>));

            collection.AddNpgsql<TopicDbContext>(dbConnection);
            collection.AddScoped<IUnitOfWork, TopicDbContext>();

            collection.AddHttpClient<ITopicHttpClient, TopicHttpClient>()
                .AddTransientHttpErrorPolicy(policy =>
                    policy.WaitAndRetryAsync(new[]
                    {
                        TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(5)
                    }));

            collection.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            collection.AddScoped<ITopicRepository, TopicRepository>();
        }
    }
}
