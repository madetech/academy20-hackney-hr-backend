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
                result.first_name = employee.first_name;
                result.last_name = employee.last_name;
                result.job_title = employee.job_title;
                result.contact_email = employee.contact_email;
                result.contact_number = employee.contact_number;
                result.salary_band  = employee.salary_band;
                result.home_address_line_1 = employee.home_address_line_1;
                result.home_address_line_2 = employee.home_address_line_2;
                result.home_address_city = employee.home_address_city;
                result.home_address_postcode = employee.home_address_postcode;
                result.office_location = employee.office_location;
                result.manager = employee.manager;
                result.reportees = employee.reportees;
                result.next_of_kin_first_name = employee.next_of_kin_first_name;
                result.next_of_kin_last_name = employee.next_of_kin_last_name;
                result.next_of_kin_contact_number = employee.next_of_kin_contact_number;

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