using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models;
using SportsStore.Models.ViewMdels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        public int Pagesize = 4;
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult List(string category,int productPage = 1) => View(new ProductsListViewModel
        {
            Products = repo.Products
                .Where(p=> category==null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * Pagesize)
                .Take(Pagesize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = Pagesize,
                TotalItems = category == null ?
                repo.Products.Count() :
                repo.Products.Where(e => e.Category == category).Count()
            },
            CurrentCategory = category
        });

    }
}
