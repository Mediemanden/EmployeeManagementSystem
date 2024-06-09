namespace Employee.DataAccess.Interfaces;

public interface IEmployeeStorage
{
    Task CreateEmployeeAsync(EmployeeEntity employee);
    Task<EmployeeEntity?> GetEmployeeAsync(Guid id);
    Task<List<EmployeeEntity>> GetEmployeesAsync();
    Task UpdateEmployeeAsync(EmployeeEntity employee);
    Task DeleteEmployeeAsync(Guid id);
}
