using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsStore.Models;
// previous server name -DESKTOP-KBO1VHT;
namespace SportsStore
{
	public class Program
	{
		//private static object IdentitySeedData;

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<StoreDbContext>(option =>
			{
				option.UseSqlServer(
			 builder.Configuration["connectionStrings:SportsStoreConnection"]);
			});

			builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
			builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
			builder.Services.AddTransient<IProductRepository, EFProductRepository>();
			builder.Services.AddRazorPages();
			builder.Services.AddDistributedMemoryCache();// setup the in-memory data storre
			builder.Services.AddSession();
			builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			//Blazor
			//builder.Services.AddServerSideBlazor();
			builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
				builder.Configuration["connectionStrings:IdentityConnection"]
				));
			builder.Services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<AppIdentityDbContext>();

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
			app.UseStaticFiles();//enables support for serving con  ent from wwwroot folder
			app.UseSession();//registers the services used to access session data this UseSession method allows the session to automatically assciate requests with session 
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

			app.MapControllerRoute(
				"catpage", "{category}/Page{ProductPage:int}",
				 new { Controller = "Home", action = "Index" });

			app.MapControllerRoute(
				"page", "Page{ProductPage:int}",
				 new { Controller = "Home", action = "Index", ProductPage = 1 });

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
			//app.MapBlazorHub();  -> this method registers the Blazor Middleware component
			//app.MapBlazorHub();
			//app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");




			SeedData.EnsurePopulated(app);
			IdentitySeedData.EnsurePopulated(app);
			app.Run();
		}
	}
}
