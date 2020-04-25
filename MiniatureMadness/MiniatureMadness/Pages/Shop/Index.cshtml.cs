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
    public class IndexModel : PageModel
    {
        private IInventory _inventory;

        public List<Product> Products { get; set; }

        public IndexModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        public async void OnGet()
        {
            var result = await _inventory.GetAllProducts();

            Products = result;
        }
    }
}