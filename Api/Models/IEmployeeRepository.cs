using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Models;


namespace Api.Models 
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> AddEmployee(Employee employee);//TODO
        Task<Employee> UpdateEmployeeById(Employee employee);//TODO
        void DeleteEmployee(int employeeId);//TODO
    }
}
