using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IProductsService
    {
        Task<bool> CreateProduct(Products product);
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductById(int id);
        Task<bool> UpdateProduct(Products product);
        Task<bool> DeleteProduct(int id);
    }
}
