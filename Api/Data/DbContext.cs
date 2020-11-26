using Api.Models;
using Microsoft.EntityFrameworkCore;


namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base (options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLogin> EmployeeLogin { get; set; }

    }
    //we have the option to seed data using code here.
}
