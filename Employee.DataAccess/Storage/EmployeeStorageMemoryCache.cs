using System.Reflection.Metadata.Ecma335;
using Employee.DataAccess.Interfaces;
using Employee.DataAccess.Storage.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Employee.DataAccess;

public class EmployeeStorageWithMemoryCache : IEmployeeStorageWithMemoryCache
{
    private readonly string _employeesKey = "employees";
    private readonly IMemoryCache _memoryCache;

    private readonly IEmployeeStorage _employeeStorage;


    public EmployeeStorageWithMemoryCache(IMemoryCache memoryCache, IEmployeeStorage employeeStorage)
    {
        _memoryCache = memoryCache;
        _employeeStorage = employeeStorage;
    }

    public async Task CreateEmployeeAsync(EmployeeEntity employee)
    {
        _memoryCache.Remove(_employeesKey);
        _memoryCache.Remove(GetIdKey(employee.Id));
        await _employeeStorage.CreateEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
        _memoryCache.Remove(_employeesKey);
        _memoryCache.Remove(GetIdKey(id));
        await _employeeStorage.DeleteEmployeeAsync(id);
    }

    public async Task<EmployeeEntity?> GetEmployeeAsync(Guid id)
    {
        return await _memoryCache.GetOrCreateAsync(GetIdKey(id), async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            return await _employeeStorage.GetEmployeeAsync(id);
        });
    }

    public async Task<List<EmployeeEntity>> GetEmployeesAsync()
    {
        List<EmployeeEntity>? memory = await _memoryCache.GetOrCreateAsync(_employeesKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            List<EmployeeEntity> employees = await _employeeStorage.GetEmployeesAsync();
            return employees;
        });

        return memory ?? [];
    }

    public async Task<List<EmployeeEntity>> SearchEmployeesAsync(string? name, string? department)
    {
        List<EmployeeEntity>? memory = await _memoryCache.GetOrCreateAsync(GetSearchKey(name, department), async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            List<EmployeeEntity> employees = await _employeeStorage.SearchEmployeesAsync(name, department);
            return employees;
        });

        return memory ?? [];
    }

    public async Task UpdateEmployeeAsync(EmployeeEntity employee)
    {
        _memoryCache.Remove(_employeesKey);
        _memoryCache.Remove(GetIdKey(employee.Id));
        await _employeeStorage.UpdateEmployeeAsync(employee);
    }

    private string GetIdKey(Guid id)
    {
        return _employeesKey + "_id_" + id;
    }

    private string GetSearchKey(string? name, string? department)
    {
        return _employeesKey + "_name_" + name + "_department_" + department;
    }
}
