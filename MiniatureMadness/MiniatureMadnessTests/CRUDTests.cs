using System;
using System.Collections.Generic;
using System.Text;
using MiniatureMadness.Models;
using MiniatureMadness.Models.Services;
using MiniatureMadness.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MiniatureMadnessTests
{
    public class CRUDTests
    {
        [Fact]
        public async void CanAddProductToDatabase()
        {
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseInMemoryDatabase("CanAddProductToDatabase")
                .Options;

            using (StoreDBContext context = new StoreDBContext(options))
            {
                InventoryService service = new InventoryService(context);

                Product product = new Product()
                {
                    Sku = "123-456",
                    Name = "Super Doggo",
                    Description = "Super Doggo is a loyal, brave, and ferocious crime fighter! He'll also fetch you the newspaper...",
                    Price = 129.95M,
                    Image = "/Assets/Images/Products/super-doggo.png"
                };

                var result = await service.CreateAProduct(product);

                var data = context.Products.Find(product.ID);

                Assert.Equal(result, data);

                Assert.Equal("Super Doggo", product.Name);
            }
        }
    }
}
