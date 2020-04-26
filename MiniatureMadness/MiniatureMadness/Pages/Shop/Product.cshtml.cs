using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniatureMadness.Data;
using MiniatureMadness.Models;
using MiniatureMadness.Models.Interfaces;

namespace MiniatureMadness.Pages.Shop
{
    public class ProductModel : PageModel
    {
        private IInventory _inventory;
        public Product Product { get; set; }
        public ProductModel(IInventory inventory)
        {
            _inventory = inventory;
        }
        public async Task OnGetAsync(int id)
        {
            var result = await _inventory.GetAProduct(id);
            Product product = new Product()
            {
                Name = result.Name,
                Image = result.Image,
                Price = result.Price,
                Description = result.Description
            };
            Product = product;
        }
    }
}