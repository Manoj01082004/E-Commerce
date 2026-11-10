using ProductServices.Data;
using ProductServices.Models;
using ProductServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProductServices.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _db;
        public ProductRepository(ProductDbContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            return await _db.Products.Include(product => product.Category)
            .Include(product => product.Inventory)
            .ToListAsync();
        }
        public async Task<ICollection<Product>> SearchProductsAsync(
    string? searchQuery)
        {
            IQueryable<Product> products = _db.Products
                .AsNoTracking()
                .Where(product => product.IsActive);

            var query = searchQuery?.Trim();

            if (!string.IsNullOrWhiteSpace(query))
            {
                products = products.Where(product =>
                    EF.Functions.Like(product.Name, $"%{query}%") ||
                    (product.Description != null &&
                     EF.Functions.Like(product.Description, $"%{query}%")));
            }

            return await products
                .Include(product => product.Category)
                .Include(product => product.Inventory)
                .OrderBy(product => product.Name)
                .ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _db.Products
                .Include(product => product.Category)
                .Include(product => product.Inventory)
                .FirstOrDefaultAsync(product => product.ProductId == id);
        }
        public async Task CreateProductAsync(Product product)
        { 
             
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var product=await _db.Products.FindAsync(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }
        }
    }
}
