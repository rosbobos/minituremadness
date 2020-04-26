using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniatureMadness.Data;
using MiniatureMadness.Models;
using MiniatureMadness.Models.Interfaces;
using MiniatureMadness.Models.Services;

namespace MiniatureMadness
{
    public class Startup
    {
        // Holds our configuration settings.
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor method for the Startup class. Injects our UserSecrets into the Configuration.
        /// </summary>
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC / Razor Pages functionality to our app.
            services.AddRazorPages();

            // Registers the ApplicationDbContext for Identity with our app.
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                // Determines which connection string to use for the Identity DB.
                options.UseSqlServer(Configuration.GetConnectionString("IdentityProductionConnection"));
            });

            // Registers the StoreDBContext with our app.
            services.AddDbContext<StoreDBContext>(options =>
            {
                // Determines which connection string to use for the store DB.
                options.UseSqlServer(Configuration.GetConnectionString("StoreProductionConnection"));
            });

            // Registers the Identity service within our app.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            // Map our Inventory Service to our IInventory interface with DI.
            services.AddTransient<IInventory, InventoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Tells our app to use the wwwroot static files directory.
            app.UseStaticFiles();

            // Tells our app to use native routing capabilities.
            app.UseRouting();

            // Tells our app to use Identity Authentication.
            app.UseAuthentication();

            // Defines the enpoints for our routes within the app.
            app.UseEndpoints(endpoints =>
            {
                // Tells our app to route to Razor Pages first.
                endpoints.MapRazorPages();

                // Tells our app to use the Default Controller routing endpoints.
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
