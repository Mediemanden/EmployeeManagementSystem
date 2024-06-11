using Employee.Business.Models;

namespace Employee.WebApi;

public static class EmployeeMapper
{
    public static EmployeeModel MapToModel(this CreateEmployeeDto dto, Guid id)
    {
        return new EmployeeModel
        {
            Id = id,
            FullName = dto.Name,
            DateOfBirth = dto.DateOfBirth,
            Department = dto.Department,
            Email = dto.Email,
            Salary = dto.Salary,
            CompanyId = dto.CompanyId,
        };
    }

    public static GetEmployeeDto MapToDto(this EmployeeModel model)
    {
        return new GetEmployeeDto
        {
            Id = model.Id,
            Name = model.FullName,
            Department = model.Department,
            Email = model.Email,
            Age = model.Age,
            Salary = model.Salary,
            Company = model.Company?.MapToDto(),
        };
    }
}
