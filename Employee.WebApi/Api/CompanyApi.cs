using Employee.Business;
using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.WebApi;

// Class called CompanyApi used for registrering MinimalApi endpoints for CompanyQuery

public static class CompanyApi
{
    public static RouteGroupBuilder RegisterCompanyApiEndpoints(this RouteGroupBuilder app)
    {
        app.MapGet("/{companyId}", async ([FromServices] IGetCompanyQuery getCompanyQuery, Guid companyId) =>
        {
            CompanyModel company = await getCompanyQuery.ExecuteAsync(companyId);

            return TypedResults.Ok(company.MapToDto());
        }).Produces<CompanyDto>().WithName("GetCompanyById");

        app.MapGet("/search/{searchQuery}", async ([FromServices] ISearchCompaniesQuery searchCompaniesQuery, string searchQuery) =>
        {
            IEnumerable<CompanyModel> companies = await searchCompaniesQuery.ExecuteAsync(searchQuery);

            return Results.Ok(companies.Select(company => company.MapToDto()));
        });

        app.MapGet("/parent/{parentCompanyId}", async (Guid parentCompanyId) =>
        {
            return Results.Ok();
        });

        return app;
    }
}
