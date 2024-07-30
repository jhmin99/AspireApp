var builder = DistributedApplication.CreateBuilder(args);
var config = builder.Configuration;
var apiapp = builder.AddProject<Projects.AspireYouTubeSummariser_ApiApp>("backend/AspireYouTubeSummariser.ApiApp")
                    .WithEnvironment("OpenAI__Endpoint", config["OpenAI:Endpoint"])
                    .WithEnvironment("OpenAI__ApiKey", config["OpenAI:ApiKey"])
                    .WithEnvironment("OpenAI__DeploymentName", config["OpenAI:DeploymentName"]);


builder.AddProject<Projects.AspireYouTubeSummariser_WebApp>("frontend/AspireYouTubeSummariser.WebApp")
    .WithExternalHttpEndpoints()
    .WithReference(apiapp);
builder.Build().Run();
