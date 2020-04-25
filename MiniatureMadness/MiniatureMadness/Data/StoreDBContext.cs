using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniatureMadness.Models;

namespace MiniatureMadness.Data
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ID = 1,
                Sku = "153-785",
                Name = "Oats & Almond",
                Price = 3,
                Description = "This coffee cake inspired cupcake is light and testes of sweet almonds and oats",
                Image = "/Assets/CanvaAlmond.jpg"
            },
            new Product
            {
                ID = 2,
                Sku = "597-416",
                Name = "Chocolate Raspberry",
                Price = 2,
                Description = "Sharp clean raspberry mixes with a deep dark chocolate in this mini cupcake",
                Image = "/Assets/CanvaChocoCupcake.jpg"
            },
            new Product
            {
                ID = 3,
                Sku = "984-354",
                Name = "Baby Shower Special",
                Price = 4,
                Description = "Wheather doing a gender reveal or a simple baby shower these vanilla cupcakes are topped with sweet marzipan decorations",
                Image = "/Assets/CanvaBabyShower.jpg"
            },
            new Product
            {
                ID = 4,
                Sku = "358-469",
                Name = "Classic Chocolate",
                Price = 2,
                Description = "A simple and sweet milk chocolate cupcake topped with chocolate frosting and a sprinkle of sea salt",
                Image = "/Assets/CanvaChocolate.jpg"
            },
            new Product
            {
                ID = 5,
                Sku = "163-541",
                Name = "Current",
                Price = 3,
                Description = "A new take on red velvet, this is a soft chocolate flavored cupcake colored with current and current jam is added in the frosting for a truely blissful experiance",
                Image = "Assets/CanvaCurrent.jpg"
            },
            new Product
            {
                ID = 6,
                Sku = "268-198",
                Name = "Blueberry bliss",
                Price = 3,
                Description = "These soft vanilla cupcakes are flavored with slightly tart blueberries which make them so refreshing",
                Image = "Assets/CanvaFourCupcakes.jpg"
            },
            new Product
            {
                ID = 7,
                Sku = "698-164",
                Name = "Sweet heart",
                Price = 2,
                Description = "These are a mixture of sweet vanilla and strawberry. Topped with candy hearts",
                Image = "/Assets/CanvaHearts.jpg"
            },
            new Product
            {
                ID = 8,
                Sku = "354-925",
                Name = "Mint and chocolate",
                Price = 2,
                Description = "Sweet soft mint paired with deep dark chocolate",
                Image = "/Assets/CanvaMintchoco.jpg"
            },
            new Product
            {
                ID = 9,
                Sku = "567-298",
                Name = "Purple princess",
                Price = 3,
                Description = "This is made with purple sweet potatoe to add a delicate flavor that is soft and slightly sweet",
                Image = "/Assets/CanvaPurpleCupcake.jpg"
            },
            new Product
            {
                ID = 10,
                Sku = "364-975",
                Name = "Unicorn",
                Price = 3,
                Description = "These multi colored cupcakes come in vanilla with a touch of magic",
                Image = "/Assets/CanvaUnicornCupcakes.jpg"
            }
            );
        }
        public DbSet<Product> Products { get; set; }
    }
}
