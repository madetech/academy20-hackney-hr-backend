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

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private DataContext _context = null;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees() //IEnumerable<Employee> ActionResult
        {   
            try {
                
                Console.WriteLine("INFO: List employees request received.");
                var employees = _context.Employees.ToList();
                Console.WriteLine("INFO: Listed employees successfully.");
                return Ok(employees);
            } catch (Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database: {e.Message}");
            }
        }
            // .toListAsync get this working

            //     Console.WriteLine("INFO: List employees request received.");
            //     var employees = _context.Employees.Select(e => {
            //         Thread.Sleep(2000);
            //         return e;
            //     });
        
            //     Console.WriteLine("INFO: Listed employees successfully.");
            //     return employees; //Ok(employees)
                //return context.employees

            // var a = try{
            // Console.WriteLine("INFO: List employees request recieved.");
            //     var employees = _context.Employees.ToList();
            //     Console.WriteLine("INFO: Listed employees successfully.");


            // } except err{
            // Console.WriteLine("ERROR: Failed to list employees:{err.message}");
            // }
        
            
            // return Ok(_context.Employees.ToList();)
        

        //     return Ok(
        // } 
        
        [EnableCors]
        [HttpGet("{id:int}")]   
        public async Task<ActionResult<Employee>> GetEmployeeDetails(int id)
        {
            var employees = _context.Employees.ToList();
            var result = employees.FirstOrDefault(e => e.id == id);
            if (result == null)  
            {  
                Response.StatusCode = 404;
            }  
            return result;
        } 
        
        [EnableCors]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            var employees = _context.Employees.ToList();
            var result = employees.FirstOrDefault(e => e.id == id);
            if (employee.first_name != null)
            {
                result.first_name = employee.first_name;
            }
            if (employee.last_name != null)
            {
                result.last_name = employee.last_name;
            }
            if (employee.job_title != null)
            {
                result.job_title = employee.job_title;
            }
            if (employee.contact_email != null)
            {
                result.contact_email = employee.contact_email;
            }
            if (employee.contact_number != null)
            {
                result.contact_number = employee.contact_number;
            }
            if (employee.salary_band != null)
            {
                result.salary_band = employee.salary_band;
            }
            if (employee.home_address_line_1 != null)
            {
                result.home_address_line_1 = employee.home_address_line_1;
            }
            if (employee.home_address_line_2 != null)
            {
                result.home_address_line_2 = employee.home_address_line_2;
            }
            if (employee.home_address_city != null)
            {
                result.home_address_city = employee.home_address_city;
            }
            if (employee.home_address_postcode != null)
            {
                result.home_address_postcode = employee.home_address_postcode;
            }
            if (employee.office_location != null)
            {
                result.office_location = employee.office_location;
            }
            if (employee.manager != null)
            {
                result.manager = employee.manager;
            }
            if (employee.reportees != null)
            {
                result.reportees = employee.reportees;
            }
            if (employee.next_of_kin_first_name != null)
            {
                result.next_of_kin_first_name = employee.next_of_kin_first_name;
            }
            if (employee.next_of_kin_last_name != null)
            {
                result.next_of_kin_last_name = employee.next_of_kin_last_name;
            }
            if (employee.next_of_kin_contact_number != null)
            {
                result.next_of_kin_contact_number = employee.next_of_kin_contact_number;
            }
            return result;

            // var employees = _context.Employees.ToList();
            // var result = employees.FirstOrDefault(e => e.id == id);
            // try
            // {
            //     if (id != result.id) //stack overflow if false
            //         return BadRequest("Employee ID mismatch");

            //     Console.WriteLine(GetEmployeeDetails(1) + " Employee details function");
            //     var employeeToUpdate = await GetEmployeeDetails(id); //something iffy here
            //     if (employeeToUpdate == null)
            //         return NotFound($"employee with ID = {id} not found");

            //     return await UpdateEmployee(id, employee);
            // }
            // catch(Exception)
            // {
            //     return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            // } 
        }

        // [HttpPost]
        // public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        // {
        //     try
        //     {
        //         if (employee == null)
        //             return BadRequest();

        //         var createdEmployee = await employeeRepository.AddEmployee(employee);

        //         return CreatedAtAction(nameof(GetEmployee),
        //             new { id = createdEmployee.EmployeeId }, createdEmployee);
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode(StatusCodes.Status500InternalServerError,
        //             "Error creating new employee record");
        //     }
        // }      
    }
}
