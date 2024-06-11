using Employee.Business.Models;
using Employee.DataAccess;
using Employee.DataAccess.Clients;
using Employee.DataAccess.Interfaces;
using Employee.DataAccess.Storage.Interfaces;

namespace Employee.Business.Commands;

public class CreateEmployeeCommand : ICreateEmployeeCommand
{
    private readonly IEmployeeStorageWithMemoryCache _employeeStorage;
    private readonly ICompanyService _companyService;
    public CreateEmployeeCommand(IEmployeeStorageWithMemoryCache employeeStorage, ICompanyService companyService)
    {
        _employeeStorage = employeeStorage;
        _companyService = companyService;
    }

    public async Task ExecuteAsync(EmployeeModel request)
    {
        // Validate create employee request -- Will throw an exception if invalid
        EmployeeValidator.ValidateEmployee(request);

        if (request.CompanyId.HasValue)
        {
            // Validate company exists
            CompanyViewModel companyResponse = await _companyService.GetCompanyAsync(request.CompanyId.Value);

            CompanyModel? company = companyResponse?.MapToModel();
            CompanyValidator.ValidateCompanyExists(company);
        }

        var employee = new EmployeeEntity
        {
            Id = request.Id,
            FullName = request.FullName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            Department = request.Department,
            Salary = request.Salary,
            CompanyId = request.CompanyId,
        };

        await _employeeStorage.CreateEmployeeAsync(employee);
    }
}
