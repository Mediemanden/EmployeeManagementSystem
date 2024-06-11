using Employee.Business.Models;
using Employee.DataAccess;
using Employee.DataAccess.Clients;

namespace Employee.Business;

public static class CompanyMapper
{
    // Static mapper method to map CompanyViewModel to CompanyModel
    public static CompanyModel MapToModel(this CompanyViewModel companyViewModel)
    {
        return new CompanyModel
        {
            Id = companyViewModel.Id,
            Name = companyViewModel.Name,
            Address = companyViewModel.Address,
            ParentCompanyId = companyViewModel.ParentCompanyId
        };
    }
}
