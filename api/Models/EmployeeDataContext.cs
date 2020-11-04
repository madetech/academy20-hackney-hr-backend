using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class EmployeeDataContext : DbContext
    {
        public TodoContext(DbContextOptions<EmployeeDataContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeData> EmployeeData { get; set; }
    }
}