using TheSecondTestSolution.Infrastructure;
using TheSecondTestSolution.Application;
using TheSecondTestSolution.Processor;
using TheSecondTestSolution.Processor.Backgrounds;
using TheSecondTestSolution.Processor.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddHostedService<AutoMigrationBackgroundService>();
builder.Services.AddHostedService<TopiHttpLoadBackgroundService>();

builder.Services.AddScoped<ITopicUploadingService, TopicUploadingService>();

var host = builder.Build();
host.Run();
