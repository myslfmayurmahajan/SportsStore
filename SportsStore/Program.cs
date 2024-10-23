using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsStore.Models;

namespace SportsStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StoreDbContext>(option => {
                option.UseSqlServer(
             builder.Configuration["connectionStrings:SportsStoreConnection"]); 
                });

            builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
            builder.Services.AddRazorPages();
            builder.Services.AddDistributedMemoryCache();// setup the in-memory data storre
            builder.Services.AddSession();

            var app = builder.Build();
            // creating The Repository Service

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();//enables support for serving conent from wwwroot folder
            app.UseSession();//registers the services used to access session data this UseSession method allows the session to automatically assciate requests with session 
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                "catpage", "{category}/Page{ProductPage:int}",
                 new { Controller = "Home", action = "Index" });

            app.MapControllerRoute(
                "page", "Page{ProductPage:int}",
                 new { Controller = "Home", action = "Index",ProductPage=1 });

            app.MapControllerRoute(
                "category", "{cateory}",
                 new { Controller = "Home", action = "Index", ProductPage = 1 });
            app.MapControllerRoute(  
                "pagination", "Products/Page{ProductPage}",
                 new { Controller = "Home", action = "Index", ProductPage = 1 });
            // register the MVCFramework as a source of endpoints using a default convention for mapping request to classes and methods
            //name: "default",
            //pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapDefaultControllerRoute();
            app.MapRazorPages();

           // SeedData.EnsurePopulated(app);

            app.Run();
        }
    }
}
