﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Admin123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                {
                    context.Database.Migrate();
                }
               


            }  // getback
			UserManager<IdentityUser> userManager = app.ApplicationServices
					  .CreateScope().ServiceProvider
					  .GetRequiredService<UserManager<IdentityUser>>();
			IdentityUser user = await userManager.FindByNameAsync(adminUser);
			if (user == null)
			{
				user = new IdentityUser("Admin");
				user.Email = "admin@example.com";
				user.PhoneNumber = "555-1234";
				var result = await userManager.CreateAsync(user, adminPassword);
				Console.WriteLine("result");
			}
		}
    }
}
