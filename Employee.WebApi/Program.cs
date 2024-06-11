using Employee.Business;
using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Employee.WebApi;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Internal extension method
builder.Services.ConfigureServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(exceptionHandlerApp
    => exceptionHandlerApp.Run(async context =>
    {
        var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is EmsException emsException)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                error = emsException.Message,
                errorCode = emsException.Code
            });
        }
        else
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                error = exceptionHandlerPathFeature?.Error?.Message ?? "An unknown error occurred",
                errorCode = ExceptionCodes.GeneralError__1000
            });

        }
    }));

// CompanyApi
app.MapGroup("/companies").RegisterCompanyApiEndpoints().WithTags("Company");

// Employees API
app.MapGroup("/employees").RegisterEmployeeApiEndpoints().WithTags("Employee");

app.Run();

