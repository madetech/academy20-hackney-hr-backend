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
        public ActionResult GetAllEmployees() //IEnumerable<Employee> ActionResult
        {   

            {   
            try 
            {
                
                Console.WriteLine("INFO: List employees request received.");
                var employees = _context.Employees.ToList();
        
                Console.WriteLine("INFO: Listed employees successfully.");
                return Ok(employees);
        
            }
            catch (Exception e)
            {
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

        }
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
        public Employee GetEmployeeDetails(int id)
        {
            var employees = _context.Employees.ToList();
            var result = employees.FirstOrDefault(e => e.id == id);
            if (result == null)  
            {  
                Response.StatusCode = 404;
            }  
            return result;
        } 

        [HttpPut("{id:int}")]
        public Employee UpdateEmployee(int id, Employee employee)
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
            return result;
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
