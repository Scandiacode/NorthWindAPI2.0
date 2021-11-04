using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWindAPI2._0.Models;

namespace NorthWindAPI2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("getAll")]
        public List<Product> GetAllProduct()
        {
            List<Product> result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Products.ToList();
            }
            return result;
        }

        [HttpGet("getByProductName")]
        public Product GetByProductName(string productname)
        {
            Product result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Products.ToList().Find(a => a.ProductName == productname);
            }
            return result;
        }

        [HttpPost("Add")]
        public Product CreateProduct(string productname, decimal unitprice,int supplierid)
        {
            Product newProduct = new Product();
            newProduct.ProductName = productname;
            newProduct.UnitPrice = unitprice;
            newProduct.SupplierId = supplierid;
            using (northwindContext context = new northwindContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }

            return newProduct;
        }

        [HttpDelete("delete/{id}")]
        public Product DeleteProductById(int id)
        {
            Product result = null;
            List<OrderDetail> resultOne = null;
            using (northwindContext context = new northwindContext())
            {
                resultOne = context.OrderDetails.Where(o => o.ProductId == id).ToList();
                foreach(OrderDetail i in resultOne)
                {
                    context.OrderDetails.Remove(i);
                }
                context.SaveChanges();

                result = context.Products.Find(id);
                if(result != null)
                {
                    context.Products.Remove(result);
                }
                context.SaveChanges();
            }
            return result;
        }
    }
}
