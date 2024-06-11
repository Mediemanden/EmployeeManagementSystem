using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Employee.DataAccess;
using Employee.DataAccess.Storage.Interfaces;

namespace Employee.Business;

public class GetEmployeeQuery : IGetEmployeeQuery
{
    private readonly IEmployeeStorageWithMemoryCache _employeeStorage;
    private readonly ICompanyService _companyService;

    public GetEmployeeQuery(IEmployeeStorageWithMemoryCache employeeStorage, ICompanyService companyService)
    {
        _employeeStorage = employeeStorage;
        _companyService = companyService;
    }

    public async Task<EmployeeModel> ExecuteAsync(Guid request)
    {
        EmployeeEntity? employeeEntity = await _employeeStorage.GetEmployeeAsync(request);

        CompanyModel? companyInfo = null;
        if (employeeEntity?.CompanyId != null)
        {
            var companyViewModel = await _companyService.GetCompanyAsync(employeeEntity.CompanyId.Value);
            companyInfo = companyViewModel?.MapToModel();
        }

        EmployeeModel? employee = employeeEntity?.MapToModel(companyInfo);

        EmployeeValidator.ValidateEmployeeExists(employee);

        return employee!;
    }
}
