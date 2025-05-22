using HotChocolate.Execution;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddGraphQLServer()
    .AddExampleTypes()
    .ModifyOptions(config =>
    {
        config.DefaultResolverStrategy = ExecutionStrategy.Serial;
    })
    .ModifyRequestOptions(config =>
    {
        config.IncludeExceptionDetails = true;
    })
    .AddMutationConventions();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();

await app.RunWithGraphQLCommandsAsync(args);
