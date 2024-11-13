using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            this.repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int productId)
        {
            Product prod = new Product();
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.ProductName} has been saved";
                return RedirectToAction("Index", "Admin");

            }

            else
            {
                return View(product);
            }
        }
        public ViewResult Create() => View("Edit", new Product());
        [HttpPost]
        public IActionResult Delete(long productID)
        {
            Product deletedProduct = repository.DeleteProduct(productID);
            if (deletedProduct != null)
            {

                TempData["message"]=$"{deletedProduct.ProductName} was deleted";
            }

			return RedirectToAction("Index", "Admin");
		}
	}
}
