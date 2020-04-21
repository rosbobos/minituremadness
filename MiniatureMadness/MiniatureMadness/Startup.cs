using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniatureMadness.Data;

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
            // Add MVC functionality to our app.
            services.AddMvc();

            // Registers the ApplicationDbContext for Identity with our app.
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                // Determines which connection string to use for the Identity DB.
                options.UseSqlServer(Configuration.GetConnectionString("IdentityDefault"));
            });
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

            // Defines the enpoints for our routes within the app.
            app.UseEndpoints(endpoints =>
            {
                // Tells our app to use the Default Controller routing endpoints.
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
