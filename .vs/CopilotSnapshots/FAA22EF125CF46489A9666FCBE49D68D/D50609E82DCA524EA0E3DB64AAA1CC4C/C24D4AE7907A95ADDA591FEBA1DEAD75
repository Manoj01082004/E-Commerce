using Microsoft.EntityFrameworkCore;
using E_CommerceDTO.Context;
using E_CommerceDTO.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceDTO.Repositories
{
    public class CategoryRepository
    {
        private readonly ECommerceDBContext _db;
        public CategoryRepository(ECommerceDBContext db)
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

