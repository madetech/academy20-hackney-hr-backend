using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Net;  
using Api.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        
        IList < Employee > employees = new List < Employee > ()
            {
                new Employee() { id = 1, first_name = "Ben", last_name = "Dalton", job_title = "Academy Software Engineer", contact_email = "ben.dalton@madetech.com" },
                new Employee() { id = 2, first_name = "Bella", last_name = "Cockrell", job_title = "Academy Software Engineer", contact_email = "bella.cockrell@madetech.com" },
                new Employee() { id = 3, first_name = "Derek", last_name = "Baker", job_title = "Academy Software Engineer", contact_email = "derek.baker@madetech.com" },
                new Employee() { id = 4, first_name = "Chloe", last_name = "Wong", job_title = "Academy Software Engineer", contact_email = "chloe.wong@madetech.com" }
            };

        [HttpGet]
        public IList < Employee > GetAllEmployees()
        {
            return employees;
        } 

        [HttpGet("{id:int}")]   
        public Employee GetEmployeeDetails(int id)
        {
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
