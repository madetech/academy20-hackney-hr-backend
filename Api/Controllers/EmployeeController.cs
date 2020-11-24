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
            Console.WriteLine(employees);
            var result = employees.FirstOrDefault(e => e.id == id);
            try
            {
                if (id != employee.id)
                    return BadRequest("Employee ID mismatch");

                var employeeToUpdate = await GetEmployeeDetails(id);
                if (employeeToUpdate == null)
                    return NotFound($"employee with ID = {id} not found");

                return await UpdateEmployee(id, employee);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            } 
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
