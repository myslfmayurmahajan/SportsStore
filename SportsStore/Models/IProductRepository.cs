using System.Collections.Generic;

namespace SportsStore.Models
{
	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }
		void SaveProduct(Product product);
		Product DeleteProduct(long productID);
		//Product DeleteProduct(Product product);
	}
}
