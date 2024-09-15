using SPAR.Api.Extensions;
using SPAR.Api.Middlewares;
using SPAR.Application;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddApplication();
builder.Services.AddApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseRouting();
app.UseCors(builder.Configuration.GetValue<string>("AllowedOrigin")!);
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHealthChecks("/health");

app.MapControllers();
app.MapGet("/", () => "SPAR Api is alive and kicking!");

app.Run();