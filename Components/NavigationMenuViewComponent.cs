using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository repo;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            this.repo = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repo.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
