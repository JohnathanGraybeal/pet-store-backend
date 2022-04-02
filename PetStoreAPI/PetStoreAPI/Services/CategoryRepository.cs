using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Category animalcategory)
        {
            if (animalcategory != null)
            {
                await _db.Categories.AddAsync(animalcategory);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string category)
        {
            var cat = await ReadAsync(category);

            _db.Categories.Remove(cat);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> ReadAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> ReadAsync(string category)
        {
            return await _db.Categories.FirstOrDefaultAsync(a => a.AnimalCategory == category);
        }

        public async Task UpdateAsync(Category category)
        {
            var toUpdate = await ReadAsync(category.AnimalCategory);

            if (category != null)
            {
                toUpdate.AnimalCategory = category.AnimalCategory;
                toUpdate.Registration = category.Registration;


                await _db.SaveChangesAsync();
            }
        }
    }
}
