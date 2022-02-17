using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.API.Helpers;
using ECommerceApp.API.Models;

namespace ECommerceApp.API.Data
{
    public interface IProductRepository
    {
        void Add<T> (T entity) where T:class;
        void Delete<T> (T entity) where T:class;
        Task<bool> SaveAll();
        Task<PagedList<Product>> GetAllProducts(ProductParams productParams);
        Task<Product> GetProduct(int id);
        Task<PagedList<Category>> GetAllCategories(ProductParams productParams);
    }
}