using TheSecondTestSolution.Api.ExceptionHandlers;
using TheSecondTestSolution.Application;
using TheSecondTestSolution.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsProduction())
{
    builder.Services.AddExceptionHandler<ProdExeptionHandler>();
}
else
{
    builder.Services.AddExceptionHandler<DevExeptionHandler>();
}

string corsSettings = "corsSettings";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsSettings,
        builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseExceptionHandler();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsSettings);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
