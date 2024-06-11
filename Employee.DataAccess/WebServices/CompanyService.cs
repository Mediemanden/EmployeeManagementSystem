using Employee.DataAccess.Clients;

namespace Employee.DataAccess.WebServices;

public class CompanyService : ICompanyService
{
    // Service class using IdaClient to access company data
    private readonly IdaClient _idaClient;

    public CompanyService(IdaClient idaClient)
    {
        _idaClient = idaClient;
    }

    public async Task<CompanyViewModel> GetCompanyAsync(Guid companyId)
    {
        CompanyViewModel result = await _idaClient.GetCompanyAsync(companyId);

        return result;
    }

    public async Task<ICollection<CompanyViewModel>> GetCompaniesAsync(string searchQuery)
    {
        ICollection<CompanyViewModel> result = await _idaClient.GetCompaniesAsync(searchQuery);

        return result;
    }

    public async Task<ICollection<CompanyViewModel>> GetCompaniesByParentCompany(Guid parentCompanyId)
    {
        ICollection<CompanyViewModel> childCompanies = await _idaClient.GetCompanyByParentCompanyIdAsync(parentCompanyId);

        return childCompanies;
    }
}
