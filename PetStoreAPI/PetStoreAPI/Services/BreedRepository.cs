using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class BreedRepository : IBreedRepository
    {
        private ApplicationDbContext _db;

        public BreedRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Breed breed)
        {
            if (breed != null)
            {
                await _db.Breeds.AddAsync(breed);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Breed breed)
        {
           var animalBreed = await ReadAsync(breed);

            _db.Breeds.Remove(animalBreed);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Breed>> ReadAllAsync()
        {
            return await _db.Breeds.ToListAsync();
        }

        public async Task<Breed> ReadAsync(Breed breed)
        {
            return await _db.Breeds.FirstOrDefaultAsync(a => a.Category == breed.Category && a.AnimalBreed == breed.AnimalBreed);
            
        }

        public async Task UpdateAsync( Breed breed )
        {
             var toUpdate = await ReadAsync(breed);

            if (breed != null)
            {
                toUpdate.Category = breed.Category;
                toUpdate.AnimalBreed = breed.AnimalBreed;

                await _db.SaveChangesAsync();
            }
        }
    }
}
