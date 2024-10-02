using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParadisePromotions.Core.Services
{
    public class ProductsService : IProductsService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public ProductsService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateProduct(Products product)
        {
            if (product != null)
            {
               
                await _unitOfWork.Products.Insert(product);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            if (id > 0)
            {
                var product = await _unitOfWork.Products.GetById(id);
                if (product != null)
                {
                    _unitOfWork.Products.Delete(product);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAll();
            return products; ;
        }

        public async Task<Products> GetProductById(int id)
        {
            if (id > 0)
            {
                var product = await _unitOfWork.Products.GetById(id);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(Products product)
        {
            if (product == null)
            {
                return false;
            }

            var existingProduct = await _unitOfWork.Products.GetById(product.ID);
            if (existingProduct == null)
            {
                return false;
            }

            // Update the properties of the existing product
            existingProduct.ProductID = product.ProductID;
            existingProduct.ProductName = product.ProductName;
            existingProduct.PerValue = product.PerValue;
            existingProduct.PerCost = product.PerCost;
            existingProduct.Active = product.Active;

            // Perform the update in the database
            _unitOfWork.Products.Update(existingProduct);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }


    }
}
