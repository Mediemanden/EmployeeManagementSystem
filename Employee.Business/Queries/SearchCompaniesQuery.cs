using Employee.Business.Models;
using Employee.DataAccess;
using Employee.DataAccess.Clients;

namespace Employee.Business;

public class SearchCompaniesQuery : ISearchCompaniesQuery
{
    private readonly ICompanyService _companyService;

    public SearchCompaniesQuery(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<IEnumerable<CompanyModel>> ExecuteAsync(string request)
    {
        ICollection<CompanyViewModel> companies = await _companyService.GetCompaniesAsync(request);

        return companies.Select(company => new CompanyModel
        {
            Id = company.Id,
            Name = company.Name,
            Address = company.Address,
            ParentCompanyId = company.ParentCompanyId,
        });
    }

}
