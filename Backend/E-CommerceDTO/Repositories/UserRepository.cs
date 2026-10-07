using E_CommerceDTO.Context;
using E_CommerceDTO.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceDTO.Repositories
{
    public class UserRepository
    {
        private readonly ECommerceDBContext _db;
        public UserRepository(ECommerceDBContext db)
        {
            _db = db;
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task RegisterUserAsync(User user)
        {
             await _db.Users.AddAsync(user);
             await _db.SaveChangesAsync();
        }      
    }
}
