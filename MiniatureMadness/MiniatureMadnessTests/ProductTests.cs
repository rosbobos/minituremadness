using System;
using Xunit;
using MiniatureMadness.Models;

namespace MiniatureMadnessTests
{
    public class ProductTests
    {
        /// <summary>
        /// Tests that Product Sku property Get and Set work.
        /// </summary>
        [Fact]
        public void CanSetAndGetSkuOfProducts()
        {
            Product product = new Product();
            product.Sku = "155-837";

            string expected = "155-837";

            Assert.Equal(expected, product.Sku);
        }

        /// <summary>
        /// Tests that Product Name property Get and Set work.
        /// </summary>
        [Fact]
        public void CanSetAndGetNameOfProducts()
        {
            Product product = new Product();
            product.Name = "Super Doggo";

            string expected = "Super Doggo";

            Assert.Equal(expected, product.Name);
        }

        /// <summary>
        /// Tests that Product Price property Get and Set work.
        /// </summary>
        [Fact]
        public void CanSetAndGetPriceOfProducts()
        {
            Product product = new Product();
            product.Price = 129.95M;

            decimal expected = 129.95M;

            Assert.Equal(expected, product.Price);
        }

        /// <summary>
        /// Tests that Product Description property Get and Set work.
        /// </summary>
        [Fact]
        public void CanSetAndGetDescriptionOfProducts()
        {
            Product product = new Product();
            product.Description = "Super Doggo is a loyal, brave, and ferocious crime fighter! He'll also fetch you the newspaper...";

            string expected = "Super Doggo is a loyal, brave, and ferocious crime fighter! He'll also fetch you the newspaper...";

            Assert.Equal(expected, product.Description);
        }

        /// <summary>
        /// Tests that Product Image property Get and Set work.
        /// </summary>
        [Fact]
        public void CanSetAndGetImageOfProducts()
        {
            Product product = new Product();
            product.Image = "/Assets/Images/Products/super-doggo.png";

            string expected = "/Assets/Images/Products/super-doggo.png";

            Assert.Equal(expected, product.Image);
        }
    }
}
