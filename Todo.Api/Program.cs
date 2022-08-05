using FastEndpoints;
using FastEndpoints.Swagger;
using Todo.Api.Database;
using Todo.Api.Middlewares;
using Todo.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory(config.GetConnectionString("ConnectionString")));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

app.MapGet("/", () => "Minimal Todo Api");

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(y => y.ErrorMessage).ToList()
        };
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();
