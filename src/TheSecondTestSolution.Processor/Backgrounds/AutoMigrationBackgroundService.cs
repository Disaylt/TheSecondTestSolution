using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Infrastructure.Database;

namespace TheSecondTestSolution.Processor.Backgrounds
{
    public class AutoMigrationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoMigrationBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //ожидаем деплой бд
            await Task.Delay(TimeSpan.FromSeconds(5));

            using IServiceScope scope = _serviceProvider.CreateScope();

            await scope
                .ServiceProvider
                .GetRequiredService<TopicDbContext>()
                .Database
                .MigrateAsync(stoppingToken);
        }
    }
}
