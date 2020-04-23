using MiniatureMadness.Data;
using MiniatureMadness.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniatureMadness.Models.Services
{
    public class InventoryService : IInventory
    {
        private StoreDBContext _context;

        public InventoryService(StoreDBContext context)
        {
            _context = context;
        }

        public Task<Product> CreateAProduct(Product product)
        {
            return null;
        }

        public Task DeleteAProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            var result = _context.Products.ToList();

            return result;
        }

        public Task<Product> GetAProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
