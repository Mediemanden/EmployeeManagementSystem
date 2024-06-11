using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Employee.DataAccess;

namespace Employee.Business;

public class GetCompanyQuery : IGetCompanyQuery
{
    private readonly ICompanyService _companyService;

    public GetCompanyQuery(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<CompanyModel> ExecuteAsync(Guid request)
    {
        var company = await _companyService.GetCompanyAsync(request);

        if (company == null)
        {
            throw new Exception("Company not found");
        }

        return new CompanyModel
        {
            Id = company.Id,
            Name = company.Name,
            Address = company.Address,
            ParentCompanyId = company.ParentCompanyId,
        };
    }
}
