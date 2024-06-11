using Microsoft.EntityFrameworkCore;

namespace Employee.DataAccess;

public class EmployeeDbContext : DbContext
{

    public DbSet<EmployeeEntity> Employees { get; set; }

    public string DbPath { get; private set; }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(path, "employee.db");
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
