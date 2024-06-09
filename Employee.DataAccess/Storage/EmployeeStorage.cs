using Employee.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.DataAccess;

// A class for reading and writing employee data to and from an in-memory entitity framework database.
public class EmployeeStorage : IEmployeeStorage
{
    private readonly EmployeeDbContext _dbContext;

    public EmployeeStorage(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
    }

    public async Task CreateEmployeeAsync(EmployeeEntity employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<EmployeeEntity?> GetEmployeeAsync(Guid id)
    {
        return await _dbContext.Employees.FindAsync(id);
    }

    public async Task<List<EmployeeEntity>> GetEmployeesAsync()
    {
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task UpdateEmployeeAsync(EmployeeEntity employee)
    {
        _dbContext.Employees.Update(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
        var employee = await GetEmployeeAsync(id);
        if (employee != null)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
