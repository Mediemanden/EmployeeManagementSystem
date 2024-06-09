using Employee.Business;
using Employee.Business.Commands;
using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Employee.WebApi;
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

// Employees API
app.MapGet("/employees", async ([FromServices] IGetEmployeesQuery getEmployeesQuery) =>
{
    return TypedResults.Ok(await getEmployeesQuery.ExecuteAsync(new SearchEmployeesRequest()));
})
.WithName("GetEmployees")
.WithOpenApi();

app.MapGet("/employees/{id}", async ([FromServices] IGetEmployeeQuery getEmployeeQuery, Guid id) =>
{
    EmployeeModel employee = await getEmployeeQuery.ExecuteAsync(id);
    return TypedResults.Ok(employee.MapToDto());
})
.WithName("GetEmployeeById")
.WithOpenApi();

app.MapPost("/employees", async ([FromServices] ICreateEmployeeCommand createEmployeeCommand, CreateEmployeeDto employee) =>
{
    Guid newEmployeeId = Guid.NewGuid();
    await createEmployeeCommand.ExecuteAsync(employee.MapToModel(newEmployeeId));
    return TypedResults.Created($"/employees/{newEmployeeId}", newEmployeeId);
})
.WithName("CreateEmployee")
.WithOpenApi();

app.MapPut("/employees/{id}", async ([FromServices] IUpdateEmployeeCommand updateEmployeeCommand, Guid id, CreateEmployeeDto employee) =>
{
    await updateEmployeeCommand.ExecuteAsync(employee.MapToModel(id));
    return Results.NoContent();
})
.WithName("UpdateEmployee")
.WithOpenApi();

app.MapDelete("/employees/{id}", async ([FromServices] IDeleteEmployeeCommand deleteEmployeeCommand, Guid id) =>
{
    await deleteEmployeeCommand.ExecuteAsync(id);
    return Results.NoContent();
})
.WithName("DeleteEmployee")
.WithOpenApi();

app.MapGet("/employees/search/", async ([FromServices] ISearchEmployeesQuery searchEmployeesQuery, string? name, string? department) =>
{
    SearchEmployeesRequest request = new()
    {
        Name = name,
        Department = department,
    };

    return TypedResults.Ok(await searchEmployeesQuery.ExecuteAsync(request));
})
.WithName("SearchEmployeeByName");


app.Run();

