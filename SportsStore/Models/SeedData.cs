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
                    Price = 43433,
                    ProductCategory = "ElectronicGedgete",
                    ProductId = 224

                },
                new Product
                {

                    ProductName = "Laptop",
                    ProductDescription = "A windows Device",
                    Price = 434333,
                    ProductCategory = "ElectronicGedgete",
                     ProductId = 225

                },
                 new Product
                 {

                     ProductName = "Keyboard",
                     ProductDescription = "A hardware Device",
                     Price = 4343545,
                     ProductCategory = "ElectronicGedgete",
                      ProductId = 226

                 },
                 new Product
                 {

                     ProductName = "mouse",
                     ProductDescription = "A Harware Device",
                     Price = 4346454,
                     ProductCategory = "ElectronicGedgete",
                     ProductId = 225

                 },
                 new Product
                 {

                     ProductName = "Bottal",
                     ProductDescription = "A hard Device",
                     Price = 433,
                     ProductCategory = "ElectronicGedgete",
                     ProductId = 225

                 }
                );

                context.SaveChanges();

            }
        }
    }
}
