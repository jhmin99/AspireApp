var builder = DistributedApplication.CreateBuilder(args);
var config = builder.Configuration;

var apiAppPath = "backend/AspireYouTubeSummariser.ApiApp";
var webAppPath = "frontend/AspireYouTubeSummariser.WebApp";

var apiapp = builder.AddProject<Projects.AspireYouTubeSummariser_ApiApp>(apiAppPath)
                    .WithEnvironment("OpenAI__Endpoint", config["OpenAI:Endpoint"])
                    .WithEnvironment("OpenAI__ApiKey", config["OpenAI:ApiKey"])
                    .WithEnvironment("OpenAI__DeploymentName", config["OpenAI:DeploymentName"]);

builder.AddProject<Projects.AspireYouTubeSummariser_WebApp>(webAppPath)
    .WithExternalHttpEndpoints()
    .WithReference(apiapp);

builder.Build().Run();
