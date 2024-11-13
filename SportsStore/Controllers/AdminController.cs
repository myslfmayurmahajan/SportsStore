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

        public ViewResult Index() => View(repository.Products);
        public ViewResult Edit (int productId)=>
            View(repository.Products.FirstOrDefault(p=>p.ProductId==productId));
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.ProductName}has been saved";
                return RedirectToAction("Index");

            }
            else
            {
                return View(product);
            }
        }
    }
}
