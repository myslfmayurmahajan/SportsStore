using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.ComponentFolder
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["Productcategory"];
            return View(repository.Products.Select(x => x.ProductCategory)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
