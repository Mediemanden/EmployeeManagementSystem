using Employee.Business.Models;
using Employee.DataAccess;

namespace Employee.Business;

public static class EmployeeMapper
{
    // Static mapping method to map EmployeeEnity to EmployeeModel
    public static EmployeeModel MapToModel(this EmployeeEntity employeeEntity, CompanyModel? company = null)
    {
        return new EmployeeModel
        {
            Id = employeeEntity.Id,
            FullName = employeeEntity.FullName,
            DateOfBirth = employeeEntity.DateOfBirth,
            Department = employeeEntity.Department,
            Email = employeeEntity.Email,
            Salary = employeeEntity.Salary,
            CompanyId = employeeEntity.CompanyId,
            Company = company
        };
    }
}
