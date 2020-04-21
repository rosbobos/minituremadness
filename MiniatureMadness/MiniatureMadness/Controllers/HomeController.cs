using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MiniatureMadness.Models;
using MiniatureMadness.Data;
using MiniatureMadness.Models.Interfaces;


namespace MiniatureMadness.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetPoroducts() => await _context.GetAllProducts();

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _context.GetProducts(id);


            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        [HttpPut("{id}")]
        public async Task PutProducts(int id, Products products)
        {
            await _context.UpdateProducts(products);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            var product = await _context.CreateProduct(product);

            return CreatedAtAction("GetProduct", new { id = product.ID }, product);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await _context.DeleteProduct(id);
        }
    }
}