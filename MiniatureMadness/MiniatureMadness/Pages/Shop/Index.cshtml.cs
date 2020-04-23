using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniatureMadness.Data;

namespace MiniatureMadness.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private StoreDBContext _context;

        public IndexModel(StoreDBContext storeDBContext)
        {
            _context = storeDBContext;
        }

        public void OnGet()
        {
            
        }
    }
}