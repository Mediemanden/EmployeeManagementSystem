using Employee.Business;
using Employee.Business.Commands;
using Employee.Business.Models;
using Employee.WebApi;

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
app.MapGet("/employees", async (IGetEmployeesQuery getEmployeesQuery) =>
{
    return TypedResults.Ok(await getEmployeesQuery.ExecuteAsync(new GetEmployeesRequest()));
})
.WithName("GetEmployees")
.WithOpenApi();

app.MapGet("/employees/{id}", async (IGetEmployeeQuery getEmployeeQuery, Guid id) =>
{
    EmployeeModel employee = await getEmployeeQuery.ExecuteAsync(id);
    return TypedResults.Ok(employee.MapToDto());
})
.WithName("GetEmployeeById")
.WithOpenApi();

app.MapPost("/employees", async (ICreateEmployeeCommand createEmployeeCommand, CreateEmployeeDto employee) =>
{
    Guid newEmployeeId = Guid.NewGuid();
    await createEmployeeCommand.ExecuteAsync(employee.MapToModel(newEmployeeId));
    return TypedResults.Created($"/employees/{newEmployeeId}", newEmployeeId);
})
.WithName("CreateEmployee")
.WithOpenApi();

app.MapPut("/employees/{id}", async (IUpdateEmployeeCommand updateEmployeeCommand, Guid id, CreateEmployeeDto employee) =>
{
    await updateEmployeeCommand.ExecuteAsync(employee.MapToModel(id));
    return Results.NoContent();
})
.WithName("UpdateEmployee")
.WithOpenApi();

app.MapDelete("/employees/{id}", async (IDeleteEmployeeCommand deleteEmployeeCommand, Guid id) =>
{
    await deleteEmployeeCommand.ExecuteAsync(id);
    return Results.NoContent();
})
.WithName("DeleteEmployee")
.WithOpenApi();

app.Run();

