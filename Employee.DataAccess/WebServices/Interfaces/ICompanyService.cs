using Employee.DataAccess.Clients;

namespace Employee.DataAccess;

public interface ICompanyService
{
    Task<CompanyViewModel> GetCompanyAsync(Guid companyId);
    Task<ICollection<CompanyViewModel>> GetCompaniesAsync(string searchQuery);
    Task<ICollection<CompanyViewModel>> GetCompaniesByParentCompany(Guid parentCompanyId);
}
