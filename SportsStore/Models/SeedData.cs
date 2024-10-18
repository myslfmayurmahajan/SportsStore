using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    // to populate the database and provide some sample data
    public static  class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {

                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(

                new Product
                {

                    ProductName = "Mobile",
                    ProductDescription = "A SmartPhone",
                    Price = 4433,
                    ProductCategory = "Palmtop"

                },
                new Product
                {

                    ProductName = "Laptop",
                    ProductDescription = "A windows Device",
                    Price = 4343,
                    ProductCategory = "laptop"

                },
                 new Product
                 {

                     ProductName = "Keyboard",
                     ProductDescription = "A hardware Device",
                     Price = 43445,
                     ProductCategory = "Hardware Electronic"

                 },
                 new Product
                 {

                     ProductName = "mouse",
                     ProductDescription = "A Harware Device",
                     Price = 43464,
                     ProductCategory = "Hardware Electronic"

                 },
                 new Product
                 {

                     ProductName = "Chair",
                     ProductDescription = "A hard Device",
                     Price = 433,
                     ProductCategory = "Furniture"

                 }
                );

                context.SaveChanges();

            }
        }
    }
}
