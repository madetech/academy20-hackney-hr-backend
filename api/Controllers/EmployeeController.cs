using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Net;  
// using System.Net.Http;  
// using System.Web.Http;  
// using System.Web.Mvc
using Api.Models; 
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    // [Route("api/[controller]")]
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

        [HttpGet("{id}")]   
        public Employee GetEmployeeDetails(int id)
        {
            var employee = employees.FirstOrDefault(e => e.id == id);
            if (employee == null)  
            {  
                Response.StatusCode = 404;
            }  
            return employee;
        } 
    }
}
