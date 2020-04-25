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
        /// <summary>
        /// Tests that a Product can be inserted into the database.
        /// </summary>
        [Fact]
        public async void CanAddProductToDatabase()
        {
            // Instantiates our InMemory database with our StoreDBContext.
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseInMemoryDatabase("CanAddProductToDatabase")
                .Options;

            // Uses our InMemory database.
            using (StoreDBContext context = new StoreDBContext(options))
            {
                // "Grabs" our InventoryService.
                InventoryService service = new InventoryService(context);

                // Define a new Product to be inserted into the database.
                Product product = new Product()
                {
                    Sku = "123-456",
                    Name = "Super Doggo",
                    Description = "Super Doggo is a loyal, brave, and ferocious crime fighter! He'll also fetch you the newspaper...",
                    Price = 129.95M,
                    Image = "/Assets/Images/Products/super-doggo.png"
                };

                // Inserts the Product into the database.
                var result = await service.CreateAProduct(product);

                // Finds the Product in the database by its ID.
                var data = context.Products.Find(product.ID);

                Assert.Equal(result, data);

                Assert.Equal("Super Doggo", product.Name);
            }
        }

        /// <summary>
        /// Tests that we can retrieve all Products in the database.
        /// </summary>
        [Fact]
        public async void CanGetAllProductsInDatabase()
        {
            // Instantiates our InMemory database with our StoreDBContext.
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseInMemoryDatabase("CanGetAllProductsInDatabase")
                .Options;

            // Uses our InMemory database.
            using (StoreDBContext context = new StoreDBContext(options))
            {
                // "Grabs" our InventoryService.
                InventoryService service = new InventoryService(context);

                // Define new Products to be inserted into the database.
                Product product1 = new Product()
                {
                    Sku = "123-456",
                    Name = "Super Doggo",
                    Description = "Super Doggo is a loyal, brave, and ferocious crime fighter! He'll also fetch you the newspaper...",
                    Price = 129.95M,
                    Image = "/Assets/Images/Products/super-doggo.png"
                };

                Product product2 = new Product()
                {
                    Sku = "654-321",
                    Name = "Scruffer Doggo",
                    Description = "Super Doggo's younger cousin, Scruffer Doggo is mangy and lazy. He is often in the way...",
                    Price = 49.95M,
                    Image = "/Assets/Images/Products/scruffer-doggo.png"
                };

                // Inserts the Products into the database.
                var result1 = await service.CreateAProduct(product1);
                var result2 = await service.CreateAProduct(product2);

                // Define expected list.
                List<Product> expected = new List<Product>()
                {
                    product1,
                    product2
                };

                // Retrieve all Products from the database.
                var data = await context.Products.ToListAsync();

                Assert.Equal(expected, data);
            }
        }

        /// <summary>
        /// Tests that we can retrieve a single Product from the database.
        /// </summary>
        [Fact]
        public async void CanGetASingleProductFromDatabase()
        {
            // Instantiates our InMemory database with our StoreDBContext.
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseInMemoryDatabase("CanGetASingleProductFromDatabase")
                .Options;

            // Uses our InMemory database.
            using (StoreDBContext context = new StoreDBContext(options))
            {
                // "Grabs" our InventoryService.
                InventoryService service = new InventoryService(context);

                // Define new Products to be inserted into the database.
                Product product = new Product()
                {
                    Sku = "123-456",
                    Name = "Super Doggo",
                    Description = "Super Doggo is a loyal, brave, and ferocious crime fighter! He'll also fetch you the newspaper...",
                    Price = 129.95M,
                    Image = "/Assets/Images/Products/super-doggo.png"
                };

                // Inserts the Product into the database.
                // Product should have an ID of 1, as it is the only Product in the database.
                var result = await service.CreateAProduct(product);

                Product expected = product;

                // Retrieve all Products from the database.
                var data = await service.GetAProduct(result.ID);

                Assert.Equal(expected, data);
            }
        }

        /// <summary>
        /// Tests that we can update an existing Product in the database.
        /// </summary>
        [Fact]
        public async void CanUpdateAProductInTheDatabase()
        {
            // Instantiates our InMemory database with our StoreDBContext.
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseInMemoryDatabase("CanGetASingleProductFromDatabase")
                .Options;

            // Uses our InMemory database.
            using (StoreDBContext context = new StoreDBContext(options))
            {
                // "Grabs" our InventoryService.
                InventoryService service = new InventoryService(context);

                // Define new Products to be inserted into the database.
                Product product = new Product()
                {
                    Sku = "123-456",
                    Name = "Super Doggo",
                    Description = "Super Doggo is a loyal, brave, and ferocious crime fighter! He'll also fetch you the newspaper...",
                    Price = 129.95M,
                    Image = "/Assets/Images/Products/super-doggo.png"
                };

                // Inserts the Product into the database.
                var result = await service.CreateAProduct(product);

                // Update the product Price.
                result.Price = 49.99M;

                // Determine that our expected value will be the updated Price.
                decimal expected = 49.99M;

                // Update our Product.
                await service.UpdateAProduct(result);

                // Retrieve our updated Product from the database.
                var data = service.GetAProduct(result.ID);
                var updatedProduct = data.Result;

                Assert.Equal(expected, updatedProduct.Price);
            }
        }
    }
}
