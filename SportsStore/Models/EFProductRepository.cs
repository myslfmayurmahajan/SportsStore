namespace SportsStore.Models
{
	public class EFProductRepository : IProductRepository
	{
		private StoreDbContext context;
		public EFProductRepository(StoreDbContext ctx)
		{
			context = ctx;
		}
		public IEnumerable<Product> Products => context.Products;

		public void SaveProduct(Product product)
		{
			if(product.ProductId ==0)
			{
				context.Products.Add(product);
			}
			else
			{
				Product dbEntry= context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
				if (dbEntry != null)
				{
					dbEntry.ProductName= product.ProductName;
					dbEntry.ProductDescription= product.ProductDescription;	
				   dbEntry.ProductId= product.ProductId;
					dbEntry.ProductCategory = product.ProductCategory;
					dbEntry.Price = product.Price;

				}

			}
			context.SaveChanges();
		}
	}
}
