using Api.Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {   
            return await appDbContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.id == employeeId);
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Employee> UpdateEmployeeById(Employee employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.id == employee.id);

            if (result != null)
            {
                result = employee; //update whole object or each property?

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async void DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.id == employeeId);

            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}