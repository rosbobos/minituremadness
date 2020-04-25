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

        }
    }
}
