using Microsoft.EntityFrameworkCore;

namespace employeeApi.Models;

public class employeeContext : DbContext
{
    public employeeContext(DbContextOptions<employeeContext> options)
        : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; } = null!;

    public List<Employee> GetEmployees()
    {
        return Employees.ToList();
    }
}