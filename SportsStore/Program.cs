using Microsoft.EntityFrameworkCore;
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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                "catpage", "{category}/Page{ProductPage:int}",
                 new { Controller = "Home", action = "Index" });

            app.MapControllerRoute(
                "page", "Page{ProductPage:int}",
                 new { Controller = "Home", action = "Index" });

            app.MapControllerRoute(
                "category", "{cateory}",
                 new { Controller = "Home", action = "Index" });
            app.MapControllerRoute(  
                "pagination", "Products/Page{ProductPage}",
                 new { Controller = "Home", action = "Index" });
            // register the MVCFramework as a source of endpoints using a default convention for mapping request to classes and methods
            //name: "default",
            //pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapDefaultControllerRoute();

            SeedData.EnsurePopulated(app);

            app.Run();
        }
    }
}
