using MiniatureMadness.Data;
using MiniatureMadness.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MiniatureMadness.Models.Services
{
    public class InventoryService : IInventory
    {
        /// <summary>
        /// The StoreDBContext being injected.
        /// </summary>
        private StoreDBContext _context;

        /// <summary>
        /// Constructor method to inject the StoreDBContext.
        /// </summary>
        /// <param name="context">The StoreDBContext.</param>
        public InventoryService(StoreDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new Product to the DB.
        /// </summary>
        /// <param name="product">The product to add to the DB.</param>
        /// <returns>The product.</returns>
        public async Task<Product> CreateAProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        /// <summary>
        /// Deletes a product from the database.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>Nothing.</returns>
        public async Task DeleteAProduct(int id)
        {
            var product = await GetAProduct(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of all products.</returns>
        public List<Product> GetAllProducts()
        {
            var result = _context.Products.ToList();

            return result;
        }

        /// <summary>
        /// Retrieves a single product from the database.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A single product.</returns>
        public async Task<Product> GetAProduct(int id)
        {
            var result = await _context.Products.FindAsync(id);
            return result;
        }

        /// <summary>
        /// Updates an existing product in the database.
        /// </summary>
        /// <param name="product">The product data to update.</param>
        /// <returns>Nothing.</returns>
        public async Task UpdateAProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
