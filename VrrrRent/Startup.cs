using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VrrrRent.Abstractions;
using VrrrRent.Repositories;
using VrrrRent.Services;
using VrrrRent.Models;
using Microsoft.AspNetCore.Identity;

namespace VrrrRent
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
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<VrrrRentContext>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ClientService>();
            services.AddScoped<DealershipService>();
            services.AddScoped<InventoryService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<RentalService>();
            services.AddScoped<VehicleService>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            var connection = @"Server=(localdb)\mssqllocaldb;Database=VrrrRentContext-1;Trusted_connection=True;ConnectRetryCount=0";
            services.AddDbContext<VrrrRentContext>
                (options => options.UseSqlServer(connection));
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
