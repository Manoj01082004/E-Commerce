using E_CommerceDTO.models;
using E_CommerceDTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceBTO.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repo;
        public ProductService(ProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            return await _repo.GetAllProductsAsync();

        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }
        public async Task CreateProductAsync(Product product)
        {
            await _repo.CreateProductAsync(product);
        }
        public async Task UpdateProductAsync(Product product)
        {
            await _repo.UpdateProductAsync(product);
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await _repo.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return false; 
            }
            await _repo.DeleteProductAsync(id);
            return true;
        }
    }
}
