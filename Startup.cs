using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheapCars.Models;
using Microsoft.EntityFrameworkCore;

namespace CheapCars
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration["CheapCarsDatabase:ConnectionStrings"]);
            });

            services.AddTransient<ICarRepository, EFCarRepository>();

            services.AddTransient<ICustomerRepository, EFCustomerRepository>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{controller=Catalog}/{action=List}/Page{page:int:min(1)}/SortBy-{sortParameters}");


                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{controller=Catalog}/{action=List}/Page{page:int:min(1)}");


                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "Page{page:int:min(1)}",
                    defaults: new { controller = "Catalog", action = "List" });


                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{controller=Catalog}/{action=ViewCar}/{idCar:int:min(1)}");

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{controller=Home}/{action=Index}/{id?}"); 
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
