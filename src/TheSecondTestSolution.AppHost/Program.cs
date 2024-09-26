var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");
var postgres = builder.AddPostgres("postgres")
    .WithImage("ankane/pgvector")
    .WithImageTag("latest");

var topicsDatabase = postgres.AddDatabase("topics");

var nasaAsteroidProcessor = builder.AddProject<Projects.TheSecondTestSolution_Processor>("task-processor")
    .WithReference(redis)
    .WithReference(topicsDatabase);

builder.AddProject<Projects.TheSecondTestSolution_Api>("task-webapi")
    .WithReference(redis)
    .WithReference(topicsDatabase);

builder.AddNpmApp("UI", "../UI")
    .WithEndpoint(targetPort: 5173, scheme: "http", env: "PORT");

builder.Build().Run();
