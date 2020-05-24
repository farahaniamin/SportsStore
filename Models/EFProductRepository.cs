﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }
        public IQueryable<Product> Products => context.Products;

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Price = product.Price;
                    dbEntry.Discription = product.Discription;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }
    }
}
