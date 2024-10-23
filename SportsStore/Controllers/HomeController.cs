using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System.Diagnostics;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        private IStoreRepository repository;
        public int pagesize = 1;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        //public IActionResult Index()
        //{
        //    return View(repository.products);
        //}
        public ViewResult Index(string? category,int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = repository.products
                .Where(p=>category==null || p.ProductCategory== category)   
                 .OrderBy(p => p.ProductId)
            .Skip((productPage - 1) * pagesize)
            .Take(pagesize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = pagesize,
                    //TotalItems = repository.products.Count()
                    TotalItems = category == null
                       ? repository.products.Count() :repository.products.Where(e=>e.ProductCategory== category).Count()
                },
                CurrentCategory = category


            });
            
        }

        
        
        
        public IActionResult Index2()
        {
            Product product = new Product();
            product.ProductName = "Pen";
            product.Price = 300;
            return View("Index2",product);
        }
    }
}
