var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin();

var postgresdb = postgres.AddDatabase("postgresdb");

var apiService = builder.AddProject<Projects.AspireTemplate_ApiService>("apiservice").WithReference(postgresdb);

builder.AddProject<Projects.AspireTemplate_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    
    .WithReference(apiService);

builder.Build().Run();
