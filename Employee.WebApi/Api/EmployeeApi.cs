using Employee.Business;
using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.WebApi;

public static class EmployeeApi
{
    public static RouteGroupBuilder RegisterEmployeeApiEndpoints(this RouteGroupBuilder app)
    {
        app.MapGet("/", async ([FromServices] IGetEmployeesQuery getEmployeesQuery) =>
        {
            IEnumerable<EmployeeModel> employees = await getEmployeesQuery.ExecuteAsync(new SearchEmployeesRequest());

            return TypedResults.Ok(employees.Select(employee => employee.MapToDto()));
        }).Produces<IEnumerable<EmployeeDto>>().WithName("GetEmployees");

        app.MapGet("/{id}", async ([FromServices] IGetEmployeeQuery getEmployeeQuery, Guid id) =>
        {
            EmployeeModel employee = await getEmployeeQuery.ExecuteAsync(id);
            return TypedResults.Ok(employee.MapToDto());
        }).Produces<EmployeeDto>().WithName("GetEmployeeById");

        app.MapPost("/", async ([FromServices] ICreateEmployeeCommand createEmployeeCommand, CreateEmployeeDto employee) =>
        {
            Guid newEmployeeId = Guid.NewGuid();
            await createEmployeeCommand.ExecuteAsync(employee.MapToModel(newEmployeeId));
            return TypedResults.Created($"/employees/{newEmployeeId}", newEmployeeId);
        }).Produces<Guid>().WithName("CreateEmployee");

        app.MapPut("/{id}", async ([FromServices] IUpdateEmployeeCommand updateEmployeeCommand, Guid id, CreateEmployeeDto employee) =>
        {
            await updateEmployeeCommand.ExecuteAsync(employee.MapToModel(id));
            return Results.NoContent();
        }).WithName("UpdateEmployee");

        app.MapDelete("/{id}", async ([FromServices] IDeleteEmployeeCommand deleteEmployeeCommand, Guid id) =>
        {
            await deleteEmployeeCommand.ExecuteAsync(id);
            return Results.NoContent();
        }).WithName("DeleteEmployee");

        app.MapGet("/search/", async ([FromServices] ISearchEmployeesQuery searchEmployeesQuery, string? name, string? department) =>
        {
            SearchEmployeesRequest request = new()
            {
                Name = name,
                Department = department,
            };

            IEnumerable<EmployeeModel> employees = await searchEmployeesQuery.ExecuteAsync(request);
            return TypedResults.Ok(employees.Select(employee => employee.MapToDto()));
        }).Produces<IEnumerable<EmployeeDto>>().WithName("SearchEmployees");

        return app;
    }

}
