using Employee.Business.Models;

namespace Employee.WebApi;

public static class CompanyMapper
{
    // static Mapper method for mapping CompanyModel to CompanyDto
    public static CompanyDto MapToDto(this CompanyModel companyModel)
    {
        return new CompanyDto
        {
            Id = companyModel.Id,
            Name = companyModel.Name,
            Address = companyModel.Address,
            ParentCompanyId = companyModel.ParentCompanyId
        };
    }
}
