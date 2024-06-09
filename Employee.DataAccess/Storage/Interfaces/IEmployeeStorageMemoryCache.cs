namespace Employee.DataAccess.Storage.Interfaces;

public interface IEmployeeStorageWithMemoryCache
{
    Task CreateEmployeeAsync(EmployeeEntity employee);
    Task<EmployeeEntity?> GetEmployeeAsync(Guid id);
    Task<List<EmployeeEntity>> GetEmployeesAsync();
    Task UpdateEmployeeAsync(EmployeeEntity employee);
    Task DeleteEmployeeAsync(Guid id);
    Task<List<EmployeeEntity>> SearchEmployeesAsync(string? name, string? department);
}
