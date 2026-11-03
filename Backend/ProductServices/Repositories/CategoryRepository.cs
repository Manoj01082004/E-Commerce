using Microsoft.EntityFrameworkCore;
using ProductServices.Data;
using ProductServices.Models;
using ProductServices.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _db;
        public CategoryRepository(ProductDbContext db)
        { 
            _db = db;
        }
        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }
        public async Task CreateCategoryAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateCategoryAsync(Category category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
            }
        }
    }
}   

