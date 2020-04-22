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
                Name = "Deapool",
                Price = 1099,
                Description = "The merc witht he mouth now in mini form",
                Image = null
            },
            new Product
            {
                ID = 2,
                Sku = "597-416",
                Name = "Hulk",
                Price = 1199,
                Description = "The big green guy now can fit in your hand",
                Image = null
            },
            new Product
            {
                ID = 3,
                Sku = "984-354",
                Name = "Hawk-eye",
                Price = 499,
                Description = "He is really good at shoting arrows, thats about it",
                Image = null
            },
            new Product
            {
                ID = 4,
                Sku = "358-469",
                Name = "Bob Ross",
                Price = 10000,
                Description = "Get to the bright side and look at all those happy little trees",
                Image = null
            },
            new Product
            {
                ID = 5,
                Sku = "163-541",
                Name = "Godzilla",
                Price = 999,
                Description = "Destroy mini sized cities",
                Image = null
            },
            new Product
            {
                ID = 6,
                Sku = "268-198",
                Name = "Spiderman",
                Price = 899,
                Description = "Get two and they can point at eachother",
                Image = null
            },
            new Product
            {
                ID = 7,
                Sku = "698-164",
                Name = "Loki",
                Price = 799,
                Description = "He might change into a snake since you like them, but when you pick him up he changes back and stabs you",
                Image = null
            },
            new Product
            {
                ID = 8,
                Sku = "354-925",
                Name = "Starlord",
                Price = 699,
                Description = "maybe you have heard of him",
                Image = null
            },
            new Product
            {
                ID = 9,
                Sku = "567-298",
                Name = "Riddick",
                Price = 799,
                Description = "to get eyes like his you need a to find a shady doctor in a max security prison... or just buy the mini",
                Image = null
            },
            new Product
            {
                ID = 10,
                Sku = "364-975",
                Name = "Work at home mini set",
                Price = 1100,
                Description = "Comes with everything you need! Laptop, mouse, desk, slippers and coffee.",
                Image = null
            }
            );
        }
        public DbSet<Product> Products { get; set; }
    }
}
