using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Infrastructure.Database;
using TheSecondTestSolution.Processor.Services;

namespace TheSecondTestSolution.Processor.Backgrounds
{
    public class TopiHttpLoadBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public TopiHttpLoadBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //ожидаем миграции на бд
            await Task.Delay(TimeSpan.FromSeconds(10));

            using IServiceScope scope = _serviceProvider.CreateScope();

            await scope
                .ServiceProvider
                .GetRequiredService<ITopicUploadingService>()
                .RunAsync();

        }
    }
}
