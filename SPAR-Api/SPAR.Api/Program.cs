using MediatR;
using Microsoft.AspNetCore.Mvc;
using SPAR.Api.Extensions;
using SPAR.Api.Middlewares;
using SPAR.Application;
using Serilog;
using SPAR.Application.PersonalData.Command;
using SPAR.Application.PersonalData.Models;
using SPAR.Application.PersonalData.Queries;

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

var personalDataGroup = app.MapGroup("/personal-data");
personalDataGroup.MapGet("/", async (IMediator mediator) => await mediator.Send(new GetPersonalDataQuery()));
personalDataGroup.MapPost("/", async (IMediator mediator, [FromBody]PersonSökRequest personRequest) => await mediator.Send(new CreatePersonCommand(personRequest)));

app.Run();