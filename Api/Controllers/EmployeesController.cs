using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Net;  
using Api.Models; 
using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Cors;
using Api.Services;
using System.IO;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() 
        {   
            try 
            {
                return (await employeeRepository.GetEmployees()).ToList();

            } catch (Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database: {e.Message}");
            }
        }
        
        [EnableCors]
        [HttpGet("{employeeId:int}")]   
        public async Task<ActionResult<Employee>> GetEmployeeById(int employeeId)
        {
            try
            {
                var result = await employeeRepository.GetEmployeeById(employeeId);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database: {e.Message}");
            }
        }    
        
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
                
                var createdEmployee = await employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployees),
                    new { id = createdEmployee.id }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
    


        [EnableCors]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                Console.WriteLine(id);
                if (id != employee.id)
                return BadRequest("Employee ID mismatch");

                var employeeToUpdate = await employeeRepository.GetEmployeeById(id);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await employeeRepository.UpdateEmployeeById(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try 
            {
                var employeeToDelete = await employeeRepository.GetEmployeeById(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}




            
        
        //     var employees = _context.Employees.ToList();
        //     var result = employees.FirstOrDefault(e => e.id == id);
        //     if (employee.first_name != null)
        //     {
        //         result.first_name = employee.first_name;
        //     }
        //     if (employee.last_name != null)
        //     {
        //         result.last_name = employee.last_name;
        //     }
        //     if (employee.job_title != null)
        //     {
        //         result.job_title = employee.job_title;
        //     }
        //     if (employee.contact_email != null)
        //     {
        //         result.contact_email = employee.contact_email;
        //     }
        //     if (employee.contact_number != null)
        //     {
        //         result.contact_number = employee.contact_number;
        //     }
        //     if (employee.salary_band != null)
        //     {
        //         result.salary_band = employee.salary_band;
        //     }
        //     if (employee.home_address_line_1 != null)
        //     {
        //         result.home_address_line_1 = employee.home_address_line_1;
        //     }
        //     if (employee.home_address_line_2 != null)
        //     {
        //         result.home_address_line_2 = employee.home_address_line_2;
        //     }
        //     if (employee.home_address_city != null)
        //     {
        //         result.home_address_city = employee.home_address_city;
        //     }
        //     if (employee.home_address_postcode != null)
        //     {
        //         result.home_address_postcode = employee.home_address_postcode;
        //     }
        //     if (employee.office_location != null)
        //     {
        //         result.office_location = employee.office_location;
        //     }
        //     if (employee.manager != null)
        //     {
        //         result.manager = employee.manager;
        //     }
        //     if (employee.reportees != null)
        //     {
        //         result.reportees = employee.reportees;
        //     }
        //     if (employee.next_of_kin_first_name != null)
        //     {
        //         result.next_of_kin_first_name = employee.next_of_kin_first_name;
        //     }
        //     if (employee.next_of_kin_last_name != null)
        //     {
        //         result.next_of_kin_last_name = employee.next_of_kin_last_name;
        //     }
        //     if (employee.next_of_kin_contact_number != null)
        //     {
        //         result.next_of_kin_contact_number = employee.next_of_kin_contact_number;
        //     }
        //     return result;

        //     // var employees = _context.Employees.ToList();
        //     // var result = employees.FirstOrDefault(e => e.id == id);
        //     // try
        //     // {
        //     //     if (id != result.id) //stack overflow if false
        //     //         return BadRequest("Employee ID mismatch");

        //     //     Console.WriteLine(GetEmployeeDetails(1) + " Employee details function");
        //     //     var employeeToUpdate = await GetEmployeeDetails(id); //something iffy here
        //     //     if (employeeToUpdate == null)
        //     //         return NotFound($"employee with ID = {id} not found");

        //     //     return await UpdateEmployee(id, employee);
        //     // }
        //     // catch(Exception)
        //     // {
        //     //     return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
        //     // } 
        // }


        //NEW POST ENDPOINT NEEDS TO RECEIVE PASSWORD ALREADY HASHED
        // [HttpPost]
        // public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        // {
        //     try
        //     {
        //         if (employee == null)
        //             return BadRequest();

        //         var createdEmployee = await employeeRepository.AddEmployee(employee);

        //         return CreatedAtAction(nameof(GetEmployees),
        //             new { id = createdEmployee.EmployeeId }, createdEmployee);
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode(StatusCodes.Status500InternalServerError,
        //             "Error creating new employee record");
        //     }
        // }   