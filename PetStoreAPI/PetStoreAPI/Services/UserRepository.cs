using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(User user)
        {
            if (user != null)
            {
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await ReadAsync(userId);

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> ReadAsync(int userId)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        Task<User> IUserRepository.ReadAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
