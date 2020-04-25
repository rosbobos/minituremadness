using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniatureMadness.Models.Interfaces
{
    public interface IInventory
    {
        Task<Product> CreateAProduct(Product product);

        Task<List<Product>> GetAllProducts();

        Task<Product> GetAProduct(int id);

        Task UpdateAProduct(Product product);

        Task DeleteAProduct(int id);
    }
}
