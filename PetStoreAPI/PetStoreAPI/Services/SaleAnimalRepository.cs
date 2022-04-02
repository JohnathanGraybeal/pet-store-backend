using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class SaleAnimalRepository : ISaleAnimalRepository
    {
        private ApplicationDbContext _db;
        public SaleAnimalRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(SaleAnimal saleAnimal)
        {
            if (saleAnimal != null)
            {
                await _db.SaleAnimals.AddAsync(saleAnimal);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int saleId, int animalId)
        {
            var saleAnimal = await ReadAsync(saleId, animalId);

            _db.SaleAnimals.Remove(saleAnimal);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<SaleAnimal>> ReadAllAsync()
        {
            return await _db.SaleAnimals.ToListAsync();
        }

        public async Task<SaleAnimal> ReadAsync(int saleId, int animalId)
        {
            return await _db.SaleAnimals.FirstOrDefaultAsync(a => a.SaleId == saleId && a.AnimalId == animalId);
        }

        public async Task UpdateAsync(int saleId, int animalId, SaleAnimal saleAnimal)
        {
            var toUpdate = await ReadAsync(saleId, animalId);

            if (saleAnimal != null)
            {
                toUpdate.SalePrice = saleAnimal.SalePrice;


                await _db.SaveChangesAsync();
            }
        }
    }
}
