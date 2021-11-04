using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWindAPI2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindAPI2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("getAll")]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Employees.ToList();
            }
            return result;
        }

        [HttpGet("getByTitle")]
        public Employee GetByTitle(string title)
        {
            Employee result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Employees.ToList().Find(a => a.Title == title);
            }
            return result;
        }

        [HttpPost("Add")]
        public Employee CreateEmployee(string firstname, string lastname)
        {
            Employee newEmployee = new Employee();
            newEmployee.FirstName = firstname;
            newEmployee.LastName = lastname;
            using (northwindContext context = new northwindContext())
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }

            return newEmployee;
        }
    }
}
