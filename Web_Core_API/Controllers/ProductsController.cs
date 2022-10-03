using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Web_Core_API.Models;
using Web_Core_API.Database;

namespace Web_Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.product.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get_Product_Detail(int id)
        {
            var products = _context.product.SingleOrDefault(idp => idp.ID == id);
            if (products != null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create_Product(Products products)
        {
            try
            {
                var prod = new Products
                {
                    Title = products.Title,
                    Status = products.Status,
                    Created_at = products.Created_at,
                    Updated_at = products.Updated_at,
                    Price = products.Price,
                    Direction = products.Direction
                };
                _context.Add(prod);
                _context.SaveChanges();
                return Ok(new
                {
                    Sucess = true,
                    Data = prod
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update_Product(int id, Products prd)
        {
            var products = _context.product.SingleOrDefault(idp => idp.ID == id);
            if (products != null)
            {
                products.Title = prd.Title;
                products.Status = prd.Status;
                products.Created_at = prd.Created_at;
                products.Updated_at = prd.Updated_at;
                products.Price = prd.Price;
                products.Direction = prd.Direction;
                _context.SaveChanges();
                return Ok(new
                {
                    Sucess = true,
                    Data = products
                });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete_Product(int id)
        {
            var products = _context.product.SingleOrDefault(idp => idp.ID == id);
            _context.Remove(products);
            _context.SaveChanges();
            return Ok(new
            {
                Sucess = true
            });
        }
    }
}
