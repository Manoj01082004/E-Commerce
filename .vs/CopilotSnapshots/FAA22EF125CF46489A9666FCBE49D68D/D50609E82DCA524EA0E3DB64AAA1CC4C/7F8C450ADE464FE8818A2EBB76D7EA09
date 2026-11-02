using E_CommerceDTO.models;
using E_CommerceDTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceBTO.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo;
        public CategoryService(CategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            return await _repo.GetAllCategoriesAsync();
        }
        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _repo.GetCategoryByIdAsync(id);
        }
        public async Task CreateCategoryAsync(Category category)
        {
            await _repo.CreateCategoryAsync(category);
        }
        public async Task UpdateCategoryAsync(Category category)
        {
            await _repo.UpdateCategoryAsync(category);
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var existingCategory = await _repo.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return false;
            }
            await _repo.DeleteCategoryAsync(id);
            return true;
        }
    }
}
