using System;
using Xunit;
using MiniatureMadness.Models;

namespace MiniatureMadnessTests
{
    public class ProductTests
    {
        [Fact]
        public void CanAddSkuToProducts()
        {
            Product product = new Product();
            product.Sku = "155-837";

            string expected = "155-837";

            Assert.Equal(expected, product.Sku);
        }

        [Fact]
        public void CanAddNameToProducts()
        {
            Product product = new Product();
            product.Name = "Super Doggo";

            string expected = "Super Doggo";

            Assert.Equal(expected, product.Name);
        }

        [Fact]
        public void CanSetAndGetPriceToProducts()
        {
            Product product = new Product();
            product.Price = 129.95M;

            decimal expected = 129.95M;

            Assert.Equal(expected, product.Price);
        }
    }
}
