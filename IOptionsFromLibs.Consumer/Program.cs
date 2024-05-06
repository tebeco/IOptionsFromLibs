using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using IOptionsFromLibs.Library;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddModuleA(options =>
{
    options.Y = "Y value from consumer startup";
    options.Z = -1;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapGet("/", ([FromServices] IOptions<ModuleAOptions> options) =>
{
    return TypedResults.Ok(options.Value);
})
.WithOpenApi();

app.Run();