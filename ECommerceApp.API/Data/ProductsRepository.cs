using System;
using System.Threading.Tasks;
using ECommerceApp.API.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.API.Helpers;
using System.Linq;
using ECommerceApp.API.Dtos;
using System.Collections.Generic;

namespace ECommerceApp.API.Data
{
    public class ProductsRepository : IProductRepository
    {
        private readonly DataContext dataContext;
        public ProductsRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

        }

        public void Add<T>(T entity) where T : class
        {
            dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            dataContext.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await dataContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PagedList<Product>> GetAllProducts(ProductParams productParams)
        {
            var products = dataContext.Products.AsQueryable();

            return await PagedList<Product>.CreateAsync(products, productParams.PageNumber, productParams.PageSize);
        }

        public async Task<PagedList<Category>> GetAllCategories(ProductParams productParams)
        {
            var categories = dataContext.Categories.AsQueryable();

            return await PagedList<Category>.CreateAsync(categories, productParams.PageNumber, productParams.PageSize);
        }
        
    }
}