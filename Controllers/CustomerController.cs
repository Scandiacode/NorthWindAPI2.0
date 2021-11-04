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
    public class CustomerController : ControllerBase
    {
        [HttpGet("getAll")]
        public List<Customer> GetAllCustomer()
        {
            List<Customer> result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Customers.ToList();
            }
            return result;
        }

        [HttpGet("getByCompanyName")]
        public Customer GetByCompanyName(string companyname)
        {
            Customer result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Customers.ToList().Find(a => a.CompanyName == companyname);
            }
            return result;
        }
    }
}

